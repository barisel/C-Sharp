using System;
using ValueType;

namespace ValueTypes
{
    public class Program {
        public static void Main() {
            var aa = GetKeyValue();
            aa.key = 4;
            aa.value = "asd";
        }

        public static (int key,string value) GetKeyValue()
        {
            return (5,"baris");
        }
    }
}