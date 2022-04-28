using System;
using System.Collections.Generic;
using System.Text;

namespace Version8
{
    public static class DefaultInterfaceMethods
    {
        public static void Test()
        {
            IOutput output = new ConsoleOutput();

            output.PrintException(new ArgumentException("abc"));
        }
    }

    interface IOutput
    {
        void PrintMessage(string message);

        void PrintException(Exception exception)
            => PrintMessage($"Exception: {exception}");
    }

    class ConsoleOutput : IOutput
    {
        public void PrintMessage(string message)
            => Console.WriteLine(message);
    }
}
