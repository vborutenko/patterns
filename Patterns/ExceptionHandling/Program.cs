using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ExceptionFilter.Throw();
                //ExceptionFilter.ThrowE();



                //This magic here is called stack unwinding: exception filter does not unwind the stack, and catch block does unwind.
                //When executing catch block, this catch block’s method becomes the top frame of the stack.
                //As a result, all the methods called by current method are removed from the stack



                //ExceptionFilter.WhenWithFilter();
                ExceptionFilter.WhenWithoutFilter();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    internal static partial class ExceptionFilter
    {
        private static void A() => B();

        private static void B() => C();

        private static void C() => D();

        private static void D()
        {
            int localVariable1 = 1;
            int localVariable2 = 2;
            int localVariable3 = 3;
            int localVariable4 = 4;
            int localVariable5 = 5;
            throw new OperationCanceledException(nameof(ExceptionFilter));
        }

        private static bool Log(this object message, bool result = false)
        {
            Trace.WriteLine(message);
            return result;
        }

        
        public static void Throw()
        {
            try
            {
                A();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public static void ThrowE()
        {
            try
            {
                A();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }



        public static void WhenWithFilter()
        {
            try
            {
                A();
            }
            catch (Exception exception) when (exception.Log())
            {
            }
        }

        public static void WhenWithoutFilter()
        {
            try
            {
                A();
            }
            catch (Exception exception)
            {
                exception.Log();
                throw;
            }
        }
    }
}
