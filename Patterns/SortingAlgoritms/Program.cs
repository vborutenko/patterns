using System;
using SortingAlgorithms;

namespace SortingAlgoritms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bubble sort
            int[] arr = { 2, 1, 0, 5, 7, 1 };



            //BubbleSort.Sort(arr);

            QuickSort.Sort(arr,0,arr.Length - 1);


        }
    }
}
