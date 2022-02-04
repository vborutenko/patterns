using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// Singleton is a creational design pattern that lets you ensure that a class has only one instance,
    /// while providing a global access point to this instance.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public sealed class BestSingleton
    {
        private static readonly Lazy<BestSingleton> lazy =
            new Lazy<BestSingleton>(() => new BestSingleton());

        public static BestSingleton Instance => lazy.Value;

        private BestSingleton()
        {
        }
    }

    public sealed class Singleton2
    {
        private static readonly Singleton2 instance = new Singleton2();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton2()
        {
        }

        private Singleton2()
        {
        }

        public static Singleton2 Instance
        {
            get
            {
                return instance;
            }
        }
    }


    //  First version - not thread-safe
    public sealed class Singleton
    {
        private static Singleton instance = null;

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

}
