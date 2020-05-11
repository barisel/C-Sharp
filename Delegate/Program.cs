using System;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument);     // value is still 44
            MathDelegates.Calculate();



        }

        static void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            // number = 19;

            int i = number;
        }
    }
}
