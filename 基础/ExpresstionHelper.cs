using DynamicQuery;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace 基础 {
    class ExpresstionHelper {
        static Model DBContext = new Model();
        public static void Parse() {
            var array = new Person []{
                new Person { Age = 18, Name = "赞赏11", Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 19, Name = "赞赏22", Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 12, Name = "赞赏33", Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 13, Name = "赞赏33", Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 14, Name = "赞赏33", Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 15, Name = "赞赏33", Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } }
            };

            //IQueryable<Person> queryable = array.AsQueryable();
            //var parameter = Expression.Parameter(typeof(Person));
            //var condation = Expression.GreaterThanOrEqual(Expression.Property(parameter, "Age"), Expression.Constant(1));
            //var lambda = Expression.Lambda<Func<Person, bool>>(condation, parameter);
            //var result = queryable.Where(lambda);

            IQueryable<Person> queryable = array.AsQueryable();
            var parameter = Expression.Parameter(typeof(Person));

            // 访问属性中的属性 可以直接循环访问即可
            Expression p = Expression.Property(parameter, "Scores");
            p = Expression.Property(p, "EnglishScore");

            // 最后一个问题 怎么实现多个属性的条件???
            //Expression p = Expression.Property(parameter, "Age");
            //p = Expression.Property(p, "1");

            var condation = Expression.GreaterThanOrEqual(p, Expression.Constant(1));
            var lambda = Expression.Lambda<Func<Person, bool>>(condation, parameter);
            var result = queryable.Where(lambda);


            Expression body = lambda.Body;
            ReadOnlyCollection<ParameterExpression> parms = lambda.Parameters;
            Type returnType = lambda.ReturnType;

            //var query = queryable.WhereIn<Person, int>(c => c.Age, new int[] { 18,12 });


            Console.WriteLine();

        }

        public static void ParseAndExucute() {
            QueryDescriptor queryDescriptor = new QueryDescriptor();
            queryDescriptor.Conditions = new List<QueryCondition>();
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Name", Operator = QueryOperator.EQUAL, Value = "赞赏34", ValueType = "string" });
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Age", Operator = QueryOperator.IN, Value = "13,NULL,19,15", ValueType = "int" });
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Sex", Operator = QueryOperator.IN, Value = "1", ValueType = "int" });
            var queryable = DBContext.People.Where(c => c.Age == 18 || c.Age == 19 || c.Age == 20).ToList();

            //Person p = new Person() { Name = "王政元", Scores = new Score() };
            //dbdontext.People.Add(p);
            //dbdontext.SaveChanges();
        }
    }
}
