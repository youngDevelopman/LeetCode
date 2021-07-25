using System;
using System.Collections.Generic;

namespace _3SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test =  new[] { -1, 0, 1, 2, -1, -4 };
            var result = ThreeSum(test);
            foreach (var arr1 in result)
            {
                foreach (var val in arr1)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum > 0)
                    {
                        k--;
                    }
                    else if(sum < 0)
                    {
                        j++;
                    }
                    else
                    {
                        result.Add(new []{ nums[i], nums[j], nums[k] });
                        j++;
                        while (j < k && nums[j] == nums[j - 1])
                        {
                            j++;
                        }
                    }
                }
            }

            return result;
        }
    }
}
