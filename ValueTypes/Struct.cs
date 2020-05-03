using System;
using System.Collections.Generic;
using System.Text;

namespace ValueType {
    public ref struct Coords {
        public Coords(double x, double y, double a, double b)
        {
            X = x;
            Y = y;
            A = a;
            B = b;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double A { get; set; }
        public double B { get; set; }

        public override string ToString() => $"({X}, {Y})";
    }

    public class StructTest{
        public void Test() {
            Coords cords = new Coords();
            cords.X = 5;
        }
    }
}
