using System;

namespace Common.Generic
{

    public static class Generic
    {
        public static void Test()
        {
            TestClass<int> obj = new TestClass<int>();
            obj.Add(50);    //No boxing
            int x= obj[0]; // No unboxing
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj[i]);   //No unboxing
            }
        }
    }
    class Base { }
    class Test<T, U>
        where U : struct
        where T : Base, new()
    { }

    public class TestClass<T>
    {
        // define an Array of Generic type with length 5
        T[] obj = new T[5];
        int count = 0;

        // adding items mechanism into generic type
        public void  Add(T item)
        {
            //checking length
            if (count + 1 < 6)
            {
                obj[count] = item;

            }
            count++;
        }
        //indexer for foreach statement iteration
        public T this[int index]
        {
            get => obj[index];
            set => obj[index] = value;
        }
    }
}
