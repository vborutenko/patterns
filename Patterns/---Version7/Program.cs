using System;

namespace ___Version7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tuples
            Tuples.Test();
            //PatterMatching
            PatternMatching.Test();
            //Local functions
            LocalFunctions.Test();

            //Ref locals and returns

        }
    }


    public class Common
    {
        
        public void Main()
        {
            //Out variables
            int.TryParse("1", out int result);

            //Binary Literals and Digit Separators
            var d = 123_456;
            var b = 0b1010_1011_1100_1101_1110_1111;
        }
    }
}
