using System;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int area = MaxArea2(arr);
            Console.WriteLine(area);
        }

        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int side1 = Math.Min(height[i], height[j]);
                    int side2 = j - i;
                    int area = side1 * side2;
                    maxArea = Math.Max(area, maxArea);
                }
            }

            return maxArea;
        }

        public static int MaxArea2(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;
            while (left != right)
            {
                int side1 = Math.Min(height[left], height[right]);
                int side2 = right - left;
                int area = side1 * side2;
                maxArea = Math.Max(area, maxArea);

                if(height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return maxArea;
        }
    }
}
