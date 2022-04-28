using System;
using System.Collections.Generic;
using System.Text;

namespace Version8
{
    public static class IndicesAndRanges
    {
        public static void Test()
        {
            var words = new string[]
            {
                // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0

            Console.WriteLine(words[^1]);

            var list = new List<string>{"a", "b", "c"};

            Console.WriteLine(list[^1]);

            var quickBrownFox = words[1..4];

            var allWords = words[..]; // contains "The" through "dog".
            var firstPhrase = words[..4]; // contains "The" through "fox"
            var lastPhrase = words[6..]; // contains "the", "lazy" and "dog"

            //You can also declare ranges as variables:

            Range phrase = 1..4;

            Index i = ^1;


            Console.WriteLine(list[i]);
        }
    }



}
