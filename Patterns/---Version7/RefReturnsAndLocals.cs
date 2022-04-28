using System;
using System.Collections.Generic;
using System.Text;

namespace ___Version7
{
    public class RefReturnsAndLocals
    {
        public static void Test()
        {
            //1
            int a = 10;
            ref int b = ref a;
            b = 20;
            Console.WriteLine("{0}", a); // display 20

            //2

            var coordinate = new Coordinate();
            var pointStruct = coordinate.PointStruct;
            pointStruct.X = 20;  //coordinate.PointStruct.X == 10

            //

            ref PointStruct  pointStructRef = ref coordinate.PointStructRef;


            pointStructRef.X = 100; //coordinate.PointStruct.X = 100

            
            //3




        }
    }


    public class PointClass
    {
        public int X { get; set; }
    }

    public struct PointStruct
    {
        public int X { get; set; }
    }

    public class Coordinate
    {
        private PointClass _pointClass;
        private PointStruct _pointStruct = new PointStruct{X = 10};

        public PointClass PointClass => _pointClass;

        public PointStruct PointStruct => _pointStruct;

        public ref PointStruct PointStructRef => ref _pointStruct;
    }
}
