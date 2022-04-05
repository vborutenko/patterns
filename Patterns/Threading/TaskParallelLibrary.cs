using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    public static class TaskParallelLibrary
    {
        public static void Main2()
        {
            Thread.CurrentThread.Name = "Main";

            // Create a task and supply a user delegate by using a lambda expression.
            Task<int> taskA = new Task<int>( () =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Hello from task");

                return 1;
            });
            // Start the task.
            taskA.Start();

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                Thread.CurrentThread.Name);

            var res = taskA.Result;

            Console.ReadKey();


        }
    }
}
