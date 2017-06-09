using System;
using ClassLibrary;
using DynamicQuery;
using System.Collections.Generic;
using System.Linq;



namespace 基础 {
    class Program {
        static void Main(string[] args) {

            //ReflectionHelper.test();

            //ReflectionHelper.PrintMothods(typeof(string));

            //ReflectionHelper.GetProperty<int>();

            var query = new Person[]{
                new Person { Age = null,Name = "赞赏34",   Sex = 1, Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 19,  Name = "赞赏22",   Sex = 1, Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 12,  Name = "赞赏33",   Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 13,  Name = "赞赏34",   Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 14,  Name = "赞赏35",   Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 15,  Name = "赞赏33",   Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } }
            }.AsQueryable();

            QueryDescriptor queryDescriptor = new QueryDescriptor();
            queryDescriptor.Conditions = new List<QueryCondition>();
            //queryDescriptor.Conditions.Add(new QueryCondition { Key = "Name", Operator = QueryOperator.EQUAL, Value = "赞赏34", ValueType = "string" });
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Age", Operator = QueryOperator.IN, Value = "13,NULL,19,15", ValueType = "int" });
            queryDescriptor.Conditions.Add(new QueryCondition { Key = "Sex", Operator = QueryOperator.IN, Value = "1", ValueType = "int" });

            var lst = query.Query(queryDescriptor).ToList();

            //var ints = new List<int>() {  };
            //int sum = ints.Aggregate((a, b) => a + b);

            Console.WriteLine();
        }


    }
}
