using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace DynamicQuery
{
    public class QueryExpressionParser<T>
    {
        public Expression<Func<T, bool>> Parse(QueryDescriptor descriptor)
        {
            var query = ParseInternal(descriptor.Conditions);

            return Expression.Lambda<Func<T, bool>>(query, parameter);
        }

        ParameterExpression parameter = Expression.Parameter(typeof(T));

        private Expression ParseInternal(IEnumerable<QueryCondition> conditions)
        {
            if (conditions == null || conditions.Count() == 0)
            {
                return Expression.Constant(true, typeof(bool));
            }
            else if (conditions.Count() == 1)
            {
                return ParseSingle(conditions.First());
            }
            else
            {
                Expression a = ParseSingle(conditions.First());
                Expression b = ParseInternal(conditions.Skip(1));
                return Expression.AndAlso(a, b);
            }
        }

        private Expression ParseSingle(QueryCondition condition)
        {
            ParameterExpression p = parameter;
            Expression key = ParseKey(p, condition);
            Expression value = ParseValue(condition);
            Expression method = ParseMethod(key, value, condition);
            return method;
        }

        private Expression ParseKey(ParameterExpression parameter, QueryCondition condition)
        {
            Expression p = parameter;
            var properties = condition.Key.Split('.');
            foreach (var property in properties)
                p = Expression.Property(p, property);
            return p;
        }

        private Expression ParseValue(QueryCondition condition)
        {
            Expression value = Expression.Constant(condition.Value);
            return value;
        }

        private Expression ParseMethod(Expression key, Expression value, QueryCondition condition)
        {
            switch (condition.Operator)
            {
                case QueryOperator.CONTAINS:
                    return Expression.Call(key, typeof(string).GetMethod("Contains"), value);
                case QueryOperator.EQUAL:
                    return Expression.Equal(key, Expression.Convert(value, key.Type)); //黎又铭 update 2016.5.27 修复类型 Nullable
                case QueryOperator.GERATER:
                    return Expression.GreaterThan(key, Expression.Convert(value, key.Type));
                case QueryOperator.GREATEROREQUAL:
                    return Expression.GreaterThanOrEqual(key, Expression.Convert(value, key.Type));
                case QueryOperator.LESS:
                    return Expression.LessThan(key, Expression.Convert(value, key.Type));
                case QueryOperator.LESSOREQUAL:
                    return Expression.LessThanOrEqual(key, Expression.Convert(value, key.Type));
                case QueryOperator.NotEqual:
                    return Expression.NotEqual(key, Expression.Convert(value, key.Type));
                case QueryOperator.IN:
                    ConstantExpression constand = value as ConstantExpression;
                    string[] names = constand.Value.ToString().Split(',');
                    var equals = new List<BinaryExpression>() { // 创建一个永远不可能为true的表达式,如果equals count = 0, Aggregate将会报错
                        Expression.MakeBinary(ExpressionType.Equal, Expression.Constant(false), Expression.Constant(true))
                    };
                    foreach (var item in names) {
                        int result;
                        if (int.TryParse(item, out result)) {
                            var t = Expression.Equal(key, Expression.Convert(Expression.Constant(Convert.ToInt32(item)), key.Type));
                            equals.Add(t);
                        } else if (item.ToLower() == "null") { // nullable<>, class 等类型才可能有NULL
                            equals.Add(Expression.Equal(key, Expression.Constant(null)));
                        }
                    }

                    //Expression body = Expression.Constant(false); // or操作必须用flase 否则可能有意外成功
                    //if (equals.Any()) {  // 如果equals.count=0,Aggregate会报错
                    //    body = equals.Aggregate<Expression>((acc,condation) => Expression.OrElse(acc,condation));

                    //    // 手写Aggregate()方法的实现
                    //    //Expression body2 = Expression.Constant(false);
                    //    //foreach (var item in equals) {
                    //    //    body2 = Expression.OrElse(body2, item);
                    //    //}
                    //    //body = body2;
                    //}

                    var body = equals.Aggregate<Expression>((acc, condation) => Expression.OrElse(acc, condation));
                    return body;
                default:
                    throw new NotImplementedException();   //Operator IN is difficult to implenment. Wait a sec.....                
            }

        }
    }
}
