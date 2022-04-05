using System;

namespace BitOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = 0b_0000_1010;
            int b = ~val;
            string binaryNumberString = Convert.ToString(101, 2);

            uint val2 = 29; 

            uint result = val2 & 10; // 8 (1000)
            result     = val2 | 10; // 31 (11111)
            result     = ~val2 ; // 2 (10)
            result     = val2 ^ 10 ; // 2 (10)

            byte byteValue = 1;
            for (int i = 0; i < 2000; i++)
            {
                byteValue = (byte)(byteValue << 1);
                binaryNumberString = Convert.ToString(byteValue, 2);
                Console.WriteLine(binaryNumberString);
            }

            result = result << 1;


            byte[] bytes = BitConverter.GetBytes(val);
        }
    }
}
