using System;
using System.Collections.Generic;

namespace LongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "";
            int result = LengthOfLongestSubstring(test);
            Console.WriteLine(result);
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int result = 0;
            char[] strArr = s.ToCharArray();
            int length = strArr.Length;
            var mappings = new Dictionary<char, int>(length);
            for (int i = 0, j = 0; j < length; j++)
            {
                char currentChar = strArr[j];
                if (mappings.ContainsKey(currentChar))
                {
                    i = Math.Max(mappings[currentChar], i);
                }

                result = Math.Max(result, j - i + 1);
                mappings[currentChar] = j + 1;
            }

            return result;
        }
    }
}
