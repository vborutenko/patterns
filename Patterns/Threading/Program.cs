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
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++) {
                taskArray[i] = Task.Factory.StartNew( (object obj) => {
                        var data = new CustomData
                        {
                            Name = i, CreationTime = DateTime.Now.Ticks,
                            ThreadNum = Thread.CurrentThread.ManagedThreadId
                        };
                        Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                            data.Name, data.CreationTime, data.ThreadNum);
                    },
                    i );
            }

            taskArray[0].GetAwaiter();
             await Task.WhenAll(taskArray);




            // Create the task object by using an Action(Of Object) to pass in custom data
            // to the Task constructor. This is useful when you need to capture outer variables
            // from within a loop.
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++) {
                taskArray[i] = Task.Factory.StartNew( (Object obj ) => {
                        CustomData data = obj as CustomData;
                        if (data == null)
                            return;

                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                        Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                            data.Name, data.CreationTime, data.ThreadNum);
                    },
                    new CustomData() {Name = i, CreationTime = DateTime.Now.Ticks} );
            }
            Task.WaitAll(taskArray);


            Console.ReadKey();
        }
    }


    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }
}
