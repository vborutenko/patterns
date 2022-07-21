using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public static class QuickSort
    {
        private static int Partition(int[] arr, int low, int high)
        {
            // pivot
            int pivot = arr[high];
     
            // Index of smaller element and
            // indicates the right position
            // of pivot found so far
            int i = (low - 1);
 
            for(int j = low; j <= high - 1; j++)
            {
         
                // If current element is smaller
                // than the pivot
                if (arr[j] < pivot)
                {
             
                    // Increment index of
                    // smaller element
                    i++;

                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i+1], arr[high]) = (arr[high], arr[i+1]);
            return (i + 1);
        }

        public static void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
         
                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = Partition(arr, low, high);
 
                // Separately sort elements before
                // partition and after partition
                Sort(arr, low, pi - 1);
                Sort(arr, pi + 1, high);
            }
        }
    }
}
