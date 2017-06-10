using System;
using ClassLibrary;
using DynamicQuery;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace 基础 {
    class Program {
        static Model dbdontext = new Model();
        static void Main(string[] args) {

            //ReflectionHelper.test();
            //ReflectionHelper.PrintMothods(typeof(string));
            //ReflectionHelper.GetProperty<int>();

            QueryDescriptor queryDescriptor = new QueryDescriptor();
            queryDescriptor.Conditions = new List<QueryCondition>();
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Name", Operator = QueryOperator.EQUAL, Value = "赞赏34", ValueType = "string" });
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Age", Operator = QueryOperator.IN, Value = "13,NULL,19,15", ValueType = "int" });
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Sex", Operator = QueryOperator.IN, Value = "1", ValueType = "int" });


            //var s = dbdontext.People.Query(queryDescriptor);
            var queryable = dbdontext.People.Where(c => c.Age == 18 || c.Age == 19 || c.Age == 20).ToList();

            //Person p = new Person() { Name = "王政元", Scores = new Score() };
            //dbdontext.People.Add(p);
            //dbdontext.SaveChanges();

            Console.WriteLine();
        }


    }
}
