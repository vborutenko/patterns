using System;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

#nullable enable
namespace ___Version7
{
    /// <summary>
    /// syntactic elements that can test that a value has a certain “shape”,
    /// and extract information from the value when it does
    /// </summary>
    public static class PatternMatching
    {
        public static void Test()
        {
            //type pattern
            object o = 1;
            if (o is int i)
            {
                Console.WriteLine(i);
            }

            Shape shape = new Rectangle();
            switch(shape)
            {
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default:
                    WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }




        }
    }

    public class Shape
    {

    }

    public class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Height { get; set; }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }
    }
}
