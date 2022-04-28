using System;
using System.Threading.Tasks;

namespace Equals
{
    class Program
    {
        /// <summary>
        /// static bool ReferenceEquals - just compare links
        /// static bool Equals(object? objA, object? objB) - wrapper on virtual equal, check
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var obj1 = new TestClass
            {
                Count = 2
            };
            var obj2 = new TestClass
            {
                Count = 2
            };

            //compare links in heap

            Console.WriteLine(obj1 == obj2); // false
            Console.WriteLine(obj1.Equals(obj2)); //false
            Console.WriteLine(object.ReferenceEquals(obj1, obj2)); // false
            Console.WriteLine(object.Equals(obj1, obj2)); // false




            Console.WriteLine("-----------------------------------------"); // false

            var obj3 = new TestClass2
            {
                Count = 2
            };
            var obj4 = new TestClass2
            {
                Count = 2
            };

            Console.WriteLine(obj3 == obj4); // false
            Console.WriteLine(obj3.Equals(obj4)); //false
            Console.WriteLine(ReferenceEquals(obj3, obj4)); // false




            Console.WriteLine(obj1.Equals(null));
            Console.WriteLine(Equals(obj1, null)); 

            Console.ReadKey();
        }
    }
    class TestClass
    {
        public int Count { get; set; }
    }

    class TestClass2
    {
        public int Count { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is TestClass2 objectType)
            {
                return this.Count == objectType.Count;
            }
            return false;
        }
    }

}
