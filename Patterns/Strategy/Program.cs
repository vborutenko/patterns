using System;

namespace Strategy
{
    /// <summary>
    /// Strategy is a behavioral design pattern that lets you define a family of algorithms,
    /// put each of them into a separate class, and make their objects interchangeable.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var smsSender = new SmsSender();
            var context = new Context(smsSender);
            context.Do();
            Console.ReadKey();
        }
    }


    public class Context
    {
        private readonly ISender _sender;
        public Context(ISender sender)
        {
            _sender = sender;
        }

        public void Do()
        {
            //doing some work
            
            _sender.Send();
        }
    }


    public interface ISender
    {
        void Send();
    }

    public class EmailSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("Send to email");
        }
    }

    public class SmsSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("Send to sms");
        }
    }
}
