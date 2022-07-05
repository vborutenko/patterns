using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SemaphoreAndSemaphoreSlim.Test();
            Plinq.Test();
        }
    }


    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }
}
