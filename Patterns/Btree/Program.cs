using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            var node = new Node
            {
                Value = 1,
                Left = new Node
                {
                    Value = 2,
                    Left = new Node
                    {
                        Value = 4
                    },
                    Right = new Node
                    {
                        Value = 5,
                        Right = new Node { Value = 7 }
                    }
                },
                Right = new Node
                {
                    Value = 3
                }
            };

            TraversePreorder(node);
            Console.ReadKey();


        }

        //(Root, Left, Right) : 1 2 4 5 3 
        public static void TraversePreorder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.Value);
            TraversePreorder(node.Left);
            TraversePreorder(node.Right);

        }

        //(Left, Right, Root) : 4 5 2 3 1
        public static void TraversePostorder(Node node)
        {
            if (node == null)
            {
                return;
            }

            TraversePreorder(node.Left);
            TraversePreorder(node.Right);
            Console.WriteLine(node.Value);
        }

    }

    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}
