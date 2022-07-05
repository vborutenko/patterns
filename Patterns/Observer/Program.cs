using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    //Observer is a behavioral design pattern that lets you define a subscription mechanism
    //to notify multiple objects about any events that happen to the object they’re observing.
    class Program
    {
        static void Main(string[] args)
        {
            var concreteObservable = new ConcreteObservable();
            concreteObservable.AddObserver(new ConcreteObserver1());
            concreteObservable.AddObserver(new ConcreteObserver2());
            concreteObservable.NotifyObservers();
            Console.ReadKey();
        }
    }
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    class ConcreteObservable : IObservable
    {
        private List<IObserver> observers;
        public ConcreteObservable()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }

    interface IObserver
    {
        void Update();
    }
    class ConcreteObserver1 : IObserver
    {
        public void Update()
        {
            Console.WriteLine("The first observer got update");
        }
    }
    class ConcreteObserver2 : IObserver
    {
        public void Update()
        {
            Console.WriteLine("The second observer got update");
        }
    }
}
