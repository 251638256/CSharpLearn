using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 基础 {
    class ReflectionHelper {
        static public void test() {
            PropertyInfo[] propertys = typeof(Person).GetProperties();
            foreach (var item in propertys) {
                Console.WriteLine(item.Name + "==" + item.PropertyType);
            }

            Console.WriteLine("=======");
            Type type = Type.GetType("System.String", false, true);
            PropertyInfo[] stringPropertys = type.GetProperties();
            foreach (var item in stringPropertys) {
                Console.WriteLine($"{item.Name}=={item.PropertyType}");
            }

            Type basicType = typeof(Person);
            //basicType.GetInterfaces.basicType.
            //basicType.GetMethods(BindingFlags.SetField);


        }

        static public void PrintMothods(Type type) {
            Console.WriteLine("Methons begin......");
            MethodInfo[] methods = type.GetMethods();
            foreach (var item in methods) {
                string returnTypeName = item.ReturnType.FullName;
                string methonName = item.Name;
                string parms = string.Join(" ,", item.GetParameters().Select(c => $"{c.ParameterType.FullName} {c.Name}"));
                Console.WriteLine($"{returnTypeName} {methonName}( {parms} )");
            }
            Console.WriteLine("Methons end");
        }

        static public void GetProperty<T>() {
            Person p = new Person { Age = 18, Name = "赞赏", Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } };
            Type type = typeof(Person);
            PropertyInfo info = type.GetProperty("Scores");
            var value = info.GetValue(p);

            //Type intType = ;

            string parm = "Scores.EnglishScore";
            //string allowChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789_";

            var array = parm.Split('.');
            object obj = p;
            for (int i = 0; i < array.Length; i++) {
                if (obj.GetType().GetProperties().Select(c => c.Name).Contains(array[i])) {
                    obj = obj.GetType().GetProperty(array[i]).GetValue(obj);
                } else {
                    throw new Exception($"类型:  {obj.GetType()}不包含这个属性:  {array[i]}");
                }
            }
            Console.WriteLine();

        }
    }
}
