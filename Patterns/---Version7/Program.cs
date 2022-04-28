using System;
using System.Threading.Tasks;

namespace ___Version7
{
    class Program
    {
        //async main
        static async Task Main(string[] args)
        {
            //Tuples
            Tuples.Test();
            //PatterMatching
            PatternMatching.Test();
            //Local functions
            LocalFunctions.Test();

            //Ref locals and returns
            RefReturnsAndLocals.Test();

            Common.Main();
        }
    }


    public static class Common
    {
        
        public static void Main()
        {
            //Out variables
            int.TryParse("1", out int result);

            //Binary Literals and Digit Separators
            var d = 123_456;
            var b = 0b1010_1011_1100_1101_1110_1111;

            // Throw in literals
            var a = d < 9 ? 0 : throw new ArgumentException();

            //Discards
            var (_, _, c) = LookupName(1);

            if (DateTime.TryParse("dateString", out _))
                Console.WriteLine($"'{"dateString"}': valid");

            //Initializers on stackalloc arrays.
            Span<int> numbers = stackalloc int[3];
        }

        static (string first, string, string)  LookupName(long id) // tuple return type
        {
            return ("a", "b", "c"); // tuple literal
        }
    }
}
