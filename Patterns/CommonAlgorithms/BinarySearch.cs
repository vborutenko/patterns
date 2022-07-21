using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithms
{
    public static class BinarySearch
    {
        public static int SearchInsert(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l < r)
            {
                int mid = (l + (r - 1)) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] > target)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }


            }

            return nums[l] < target ? l + 1 : l;
        }
    }
}
