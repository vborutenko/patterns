using System.Collections.Generic;
using System.Linq;

namespace Command
{
    //Command is a behavioral design pattern that turns a request into a stand-alone object that contains
    //all information about the request. This transformation lets you pass requests as a method arguments,
    //delay or queue a request’s execution, and support undoable operations.
    class Program
    {
        static void Main(string[] args)
        {
            //create invoker
            var transactionManager = new TransactionManager();

            //create receiver
            var account = new Account("Ivan", 100);

            var depositCommand = new Deposit(account, 100);

            transactionManager.AddTransaction(depositCommand);

            transactionManager.ProcessPendingTransactions();

        }
    }


    public class Account // receiver
    {
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
 
        public Account(string ownerName, decimal balance)
        {
            OwnerName = ownerName;
            Balance = balance;
        }
    }


    public interface ITransaction // command
    {
        bool IsCompleted { get; set; }
        void Execute();
    }

    public class Deposit : ITransaction // concrete command
    {
        private readonly Account _account;
        private readonly decimal _amount;
 
        public bool IsCompleted { get; set; }
 
        public Deposit(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
 
            IsCompleted = false;
        }
 
        public void Execute()
        {
            _account.Balance += _amount;
 
            IsCompleted = true;
        }
    }

    public class TransactionManager // invoker
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();
 
        public bool HasPendingTransactions
        {
            get { return _transactions.Any(x => !x.IsCompleted); }
        }
 
        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }
 
        public void ProcessPendingTransactions()
        {
            // Apply transactions in the order they were added.
            foreach(ITransaction transaction in _transactions.Where(x => !x.IsCompleted))
            {
                transaction.Execute();
            }
        }
    }
}
