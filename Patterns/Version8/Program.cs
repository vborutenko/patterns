using System;

namespace Version8
{
    class Program
    {
        static void Main(string[] args)
        {
            //readonly members
            ReadonlyMembers.Test();

            //Default Interface Methods
            DefaultInterfaceMethods.Test();

            //pattern matching
            PatternMatching.Test();

            //Using declarations
            using var file = new System.IO.StreamWriter("WriteLines2.txt");

            //Static local functions
            StaticLocalFunctions();

            //Indices and ranges
            IndicesAndRanges.Test();

            //IndicesAndRanges
            IndicesAndRanges.Test();

            //Null-coalescing assignment
            int? a = 1;
            a ??= 18;


            //Asynchronous Streams
            AsynchronousStreams.Test();

            //Stackalloc in nested expressions
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            Console.WriteLine(ind);  // output: 1



            //Nullable Reference Types


        }



        /// <summary>
        /// You can now add the static modifier to local functions
        /// to ensure that local function doesn't capture (reference) any variables from the enclosing scope
        /// </summary>
        /// <returns></returns>
        static int StaticLocalFunctions()
        {
            int y;
            LocalFunction();
            return y;

            /*static*/ void LocalFunction() => y = 0;
        }
    }
}
