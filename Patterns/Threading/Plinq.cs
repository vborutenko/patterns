using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    /// <summary>
    /// PLINQ automatically parallelizes local LINQ queries.
    /// </summary>
    public static class Plinq
    {
        public static void Test()
        {
            IEnumerable<int> numbers = Enumerable.Range (3, 100000-3);

            var result = numbers.AsParallel().Select(n => n.ToString());

            //if you need order preservation
            var result2 = numbers.AsParallel().AsOrdered().Select(n => n.ToString());

        }
    }
}
