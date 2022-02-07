using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }




    //optimized

    public static class ParticipleFactory
    {
        private static Dictionary<string, ParticipleType> _cache = new Dictionary<string, ParticipleType>();

        public static ParticipleType GetParticipleType(string type, int weight)
        {
            if (_cache.ContainsKey(type))
            {
                return _cache[type];
            }

            var participleType = new ParticipleType(type, weight);

            return participleType;
        }


    }


    public class ParticipleType
    {
        public ParticipleType(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        //Intrinsic-shared-immutable
        public string Type { get; }   // A (Weight = 10),B(Weight = 20),C(Weight = 30)
        public int Weight { get; }
    }

    public class Participle
    {
        public ParticipleType ParticipleType { get; }

        //Extrinsic-mutable 
        public int Speed { get; set; }
        public int GeoLocation { get; set; }

        public Participle(string type, int weight, int speed, int geolocation)
        {
            ParticipleType = ParticipleFactory.GetParticipleType(type, weight);
            Speed = speed;
            GeoLocation = GeoLocation;
        }
    }



    // Unoptimized

    public class ParticipleUnoptimized
    {
        //Intrinsic-shared-immutable
        public string Type { get; set; }   // A (Weight = 10),B(Weight = 20),C(Weight = 30)
        public int Weight { get; set; }

        //Extrinsic-mutable 
        public int Speed { get; set; }
        public int GeoLocation { get; set; }
    }
}
