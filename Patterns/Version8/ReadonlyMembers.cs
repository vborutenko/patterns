using System;
using System.Collections.Generic;
using System.Text;

namespace Version8
{

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        public override readonly string ToString()
        {
            //X += 1;  cannot assign because it is readonly
            return $"({X}, {Y}) is {Distance} from the origin";
        }
           
    }

    /// <summary>
    /// This feature lets you specify your design intent so the compiler can enforce it,
    /// and make optimizations based on that intent.
    /// </summary>
    public static class ReadonlyMembers
    {
        public static void Test()
        {

        }
    }
}
