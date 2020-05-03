using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes
{
    class Tuple {
        public static void MainTest() {
            var aa = GetKeyValue();
            aa.key = 4;
            aa.value = "asd";
        }

        public static (int key, string value) GetKeyValue()
        {
            return (5, "baris");
        }
    }
}
