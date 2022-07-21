using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    class BinarySearch
    {
        public int SearchInsert(int[] nums, int target)
        {
            int min = 0;
            int max = nums.Length - 1;

            while (max > min)
            {
                var mid = (min + max) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] > target)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }


            return -1;
        }
    }
}
