using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Version8
{
    public static class AsynchronousStreams
    {
        public static async void Test()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }


        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            yield return 1;
            await Task.Delay(100);
            yield return 2;
            await Task.Delay(100);
            yield return 3;
        }

        public static  IEnumerable<int> GenerateSequenceSync()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }


    }


}
