using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Common
{
    public class PatternMatching
    {
        public  void Test()
        {
            //Constant pattern----------------------------------------------
            var vehicle = new Car();
            if (vehicle is not null)
            {
                
            }
            object o = 1;
            if (o is 1)
            {
                
            }

            int visitorCount = 5;
            var a = visitorCount switch
            {
                1 => 12.0m,
                2 => 20.0m,
                3 => 27.0m,
                4 => 32.0m,
                0 => 0.0m,
                _ => throw new ArgumentException($"Not supported number of visitors: {visitorCount}",
                    nameof(visitorCount)),
            };
            //-------------------------------------------------------------


            //Declaration pattern----------------------------------------------

            object greeting = "Hello, World!";
            if (greeting is string message)
            {
                Console.WriteLine(message.ToLower());  // output: hello, world!
            }

            int? xNullable = 7;
            int y = 23;
            object yBoxed = y;
            if (xNullable is int a1 && yBoxed is int b)
            {
                Console.WriteLine(a1 + b);  // output: 30
            }

            //-------------------------------------------------------------


            //Relational pattern----------------------------------------------

            var measurement = 5.0;
            var t = measurement switch
            {
                < -4.0 => "Too low",
                > 10.0 => "Too high",
                7 => "Exact",
                double.NaN => "Unknown",
                _ => "Acceptable",
            };

            var l = DateTime.UtcNow.Month switch
            {
                >= 3 and < 6 => "spring",
                >= 6 and < 9 => "summer",
                >= 9 and < 12 => "autumn",
                12 or (>= 1 and < 3) => "winter",
                _ => throw new ArgumentOutOfRangeException("nameof(date)", $"Date with unexpected month: {1}."),
            };

            var m = 7;
            if (m is ( > 3 and < 9))
            {
                
            }

            //-------------------------------------------------------------


            //Logical pattern----------------------------------------------

            // You can use NOT , AND , OR

            var h = measurement switch
            {
                < -40.0 => "Too low",
                >= -40.0 and < 0 => "Low",
                >= 0 and < 10.0 => "Acceptable",
                >= 10.0 and < 20.0 => "High",
                >= 20.0 and < 40 => "Too high",
                41 or 42 or 45 => "XX",
                double.NaN => "Unknown",
            };

            //-------------------------------------------------------------


            // Property pattern--------------------------------------------

            bool q  = DateTime.UtcNow is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };
            object input = "";
            var _t = input switch
            {
                string { Length: >= 5 } s => s.Substring(0, 5),
                string s => s,

                ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
                ICollection<char> symbols => new string(symbols.ToArray()),

                null => throw new ArgumentNullException(nameof(input)),
                _ => throw new ArgumentException("Not supported input type."),
            };

            // Positional pattern--------------------------------------------
            Point point = new Point(1,2);
            var _y = point switch
            {
                (0, 0) => "Origin",
                (1, 0) => "positive X basis end",
                (0, 1) => "positive Y basis end",
                _ => "Just a point",
            };

            decimal LocalFunction (int groupSize, DateTime visitDate) => (groupSize, visitDate.DayOfWeek) switch
            {
                (<= 0, _) => throw new ArgumentException("Group size must be positive."),
                (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
                (>= 5 and < 10, DayOfWeek.Monday) => 20.0m,
                (>= 10, DayOfWeek.Monday) => 30.0m,
                (>= 5 and < 10, _) => 12.0m,
                (>= 10, _) => 15.0m,
                _ => 0.0m,
            };

            //-------------------------------------------------------------


            // var pattern--------------------------------------------

            // temprorary varibale in bool expression
            //allLists.Where(list => list.Count() is var count && count >= min && count <= max)

            //-------------------------------------------------------------
            static bool IsAcceptable(int id, int absLimit) =>
                SimulateDataFetch(id) is var results 
                && results.Min() >= -absLimit 
                && results.Max() <= absLimit;

            static int[] SimulateDataFetch(int id)
            {
                var rand = new Random();
                return Enumerable
                    .Range(start: 0, count: 5)
                    .Select(s => rand.Next(minValue: -10, maxValue: 11))
                    .ToArray();
            }


        }



    }

    public abstract class Vehicle {}
    public class Car : Vehicle {}
    public class Truck : Vehicle {}

    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }


}
