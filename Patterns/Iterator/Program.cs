using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    /// <summary>
    /// Iterator is a behavioral design pattern that lets you traverse
    /// elements of a collection without exposing its underlying representation (list, stack, tree, etc.).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var customClass = new CustomClass();

            var iterator = customClass.CreateIterator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }

            Console.ReadKey();
        }
    }

    public class CustomClass : IContainer
    {
        private int _a = 1;
        private int _b = 2;
        public IIterator CreateIterator()
        {
            return new CustomClassIterator(_a,_b);
        }
    }

    public class CustomClassIterator : IIterator
    {
        private int _a;
        private int _b;
        private int _current = 0;
        private int _index = 0;
        public CustomClassIterator(int a,int b)
        {
            _a = a;
            _b = b;
        }
        public bool MoveNext()
        {
            if (_index == 0)
            {
                _current = _a;
                _index++;
                return true;
            }
            if (_index == 1)
            {
                _current = _b;
                _index++;
                return true;
            }

            return false;
        }

        public object Current => _current;
    }



    /// <summary>
    /// IEnumerator
    /// </summary>
    public interface IIterator
    {
        bool MoveNext();

        object Current { get; }
    }

    /// <summary>
    /// IEnumerable
    /// </summary>
    public interface IContainer
    {
        IIterator CreateIterator();
    }



}
