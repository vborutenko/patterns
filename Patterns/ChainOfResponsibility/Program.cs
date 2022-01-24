using System;

namespace ChainOfResponsibility
{
    public class Program
    {
        /// <summary>
        /// Chain of Responsibility is a behavioral design pattern that lets you pass requests
        /// along a chain of handlers. Upon receiving a request, each handler decides either to process
        /// the request or to pass it to the next handler in the chain.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Approver director = new Director();
            Approver vicePresident = new VicePresident();
            Approver president = new President();
            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);
            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Supplies");
            director.ProcessRequest(p);
            p = new Purchase(2035, 32590.10, "Project X");
            director.ProcessRequest(p);
            p = new Purchase(2036, 122100.00, "Project Y");
            director.ProcessRequest(p);
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    public abstract class Approver
    {
        protected Approver successor;
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    purchase.Number);
            }
        }
    }
    /// <summary>
    /// Class holding request details
    /// </summary>
    public class Purchase
    {
        int number;
        double amount;
        string purpose;
        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this.number = number;
            this.amount = amount;
            this.purpose = purpose;
        }
        // Gets or sets purchase number
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        // Gets or sets purchase amount
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        // Gets or sets purchase purpose
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }
    }
}
