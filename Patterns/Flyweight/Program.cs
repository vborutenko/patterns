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

    public static class FlyweightFactory
    {
        private static Dictionary<char, CharacterFlyweight> _cache = new Dictionary<char, CharacterFlyweight>();

        public static CharacterFlyweight GetCharacterFlyweight(char symbol)
        {
            CharacterFlyweight character = null;
            if (_cache.ContainsKey(symbol))
            {
                character = _cache[symbol];
            }
            else
            {
                switch (symbol)
                {
                    case 'A': character = new CharacterFlyweight('A', 5, 5); break;
                    case 'B': character = new CharacterFlyweight('B', 7, 7); break;
                    //...
                    case 'Z': character = new CharacterFlyweight('Z', 1, 2); break;
                }
            }


            return character;
        }

    }


    public class CharacterFlyweight
    {

        //Intrinsic-shared-immutable
        public char Symbol { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public CharacterFlyweight(char symbol, int height, int width)
        {
            Symbol = symbol;
            Height = height;
            Width = width;
        }
    }



    // Unoptimized

    public class Character_Unoptimized
    {
        //Intrinsic-shared-immutable
        public char Symbol { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        //Extrinsic-mutable 
        public int X { get; set; }
        public int Y { get; set; }

        public void Display()
        {
            Console.WriteLine($"Displating character {Symbol} to postiiton x {X} and y {Y} ");
        }
    }
}
