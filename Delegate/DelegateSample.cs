using System;
using System.Collections.Generic;
using System.Link;
using System.Runtime.ConstrainedExecution;

namespace Delegate
{
    // Simple Delegate
    public static class MathDelegates {
        public delegate int Math(int x);

        public delegate TTo Converter<in T, out TTo>(T input); //where TFrom : struct, IConvertible where TTo : new();

        public static int Square(int x) => x * x;
        public static int Cube(int x) => x * x * x;

        public static string GetString(in int number) {
            string strNumber = number.ToString();
            return $"Number : {strNumber}";
        }

        public static void Calculate() {
            Math square = Square;
            int v1 = square(5);

            Math cube = Cube;
            int v2 = Cube(5);
            List<Test> tests = new List<Test>
            {
                new Test{Name="baris",Surname="elvanoglu",Id=1},
                new Test{Name="tansel",Surname="cetin",Id=2},
                new Test{Name="yunus",Surname="tunc",Id=3}
            };

            tests.MyWhere(test => test.Name == "baris");
            var val = tests.Where(test => test.Name == "yunus").ToList();
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source,Converter<Test, bool> predicate) {
            return source;
        }
    }

    public class Test {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
    }

}
