using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Version6
{
    class Program
    {
        //https://www.c-sharpcorner.com/UploadFile/8ef97c/full-C-Sharp-6-0-in-single-article-on-visual-studio-2015-preview/
        static void Main(string[] args)
        {

            ExceptionFilter.When();



            //1.Using static
            var a = PI * 3;

            
            //3. Dictionary Initializer

            var dict = new Dictionary<string, string>
            {
                ["a"] = "abc"
            };

            //4. nameof Expression
            string dictName = nameof(dict);


            //5.Exception filters
            try  
            {  

                var i = int.Parse("1");
            }  
            catch (Exception ex) when (ex.Message == "abc")  
            {  
                Console.WriteLine("1");
            }  
            catch (Exception ex)  
            {  
                Console.WriteLine("2"); 
            } 
            
            //6.String Interpolation
            //var a6 = $"{a} - pi";

            //7.Await in catch/finally Block

            //8 Null Conditional 
            // hero?.SuperPower ?? "You aint a super hero."

        }
        
        //2.Auto property initializer
        public string Name { get; set; } = "Valera";
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

        public static void When()
        {
            try
            {
                A();
            }
            catch (Exception exception) when (exception.Log())
            {
            }
        }

        public static void When2()
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
