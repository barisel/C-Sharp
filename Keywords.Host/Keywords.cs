using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Keywords.Host
{
    public class Keywords {
        #region in : o method içerisinde readonly olur. 
        static void Method(int argument){
            argument = 5;
        }

        // İn 
        static void Method(in int argument) {
            //argument = 5; // patlar.
        }

        public static void Run() {
            int i = 42;
            Method(i);
            Method(in i);
            i = 5;
        }

        #endregion


    }
}
