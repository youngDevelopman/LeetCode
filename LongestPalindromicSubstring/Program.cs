using System;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "cbbd";
            string result = ExpandAroundCenter(test);
            Console.WriteLine(result);
        }

        public static string ExpandAroundCenter(string s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundZero(s, i, i);
                int len2 = ExpandAroundZero(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if(len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            int substLen = end - start + 1;
            return s.Substring(start, substLen);
        }

        public static int ExpandAroundZero(string s, int left, int right)
        {
            while((left >= 0 && right < s.Length) && (s[left] == s[right]))
            {
                left--;
                right++;
            }

            return right - left - 1;
        }

        public static string BruteForce(string str)
        {
            int length = str.Length;
            int best_palindrome_length = 0;
            string best_palindrome_substr = "";
            for (int left = 0; left < length; left++)
            {
                for (int right = left; right < length; right++)
                {
                    int endIndex = right - left + 1;
                    string currentSubstring = str.Substring(left, endIndex);
                    int currentSubstrLength = currentSubstring.Length;
                    if (currentSubstrLength > best_palindrome_length && IsPalindrome(currentSubstring))
                    {
                        best_palindrome_substr = currentSubstring;
                        best_palindrome_length = currentSubstrLength;
                    }
                }
            }

            return best_palindrome_substr;
        }

        public static bool IsPalindrome(string str)
        {
            char[] reversedArr = str.ToCharArray();
            Array.Reverse(reversedArr);
            string reversed = new string(reversedArr);
            
            return str == reversed;
        }
    }
}
