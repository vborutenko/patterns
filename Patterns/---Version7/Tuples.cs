using System;
using System.Collections.Generic;
using System.Text;

namespace ___Version7
{
    public static class Tuples
    {
        static (string first, string, string)  LookupName(long id) // tuple return type
        {
            return ("a", "b", "c"); // tuple literal
        }

        public static void Test()
        {
            var t = LookupName(4);
            var g = t.Item3 + t.Item2;


            //deconstruction

            (string first, string middle, string last) = LookupName(1); 
            var ( f,  m,  l) = LookupName(1);
            var (x, y) = new Point(1,2);


        }

        class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) { X = x; Y = y; }
            public void Deconstruct(out int x, out int y) { x = X; y = Y; }
        }
    }
}
