using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string val = "    -42";
            MyAtoi2(val);
        }

        public static int MyAtoi(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            s = s.TrimStart();
            int factor = 1;
            int startIndex = 0;
            if(s[0] == '-')
            {
                factor = -1;
                startIndex = 1;
            }
            else if(s[0] == '+')
            {
                startIndex = 1;
            }

            var regex = new Regex(@"^\d+$");
            bool isLeadingZeros = true;
            string resultString = null;
            for (int i = startIndex; i < s.Length; i++)
            {
                bool isNumber = regex.IsMatch(s[i].ToString());
                if (s[i] != '0' && isLeadingZeros && isNumber)
                {
                    isLeadingZeros = false;
                    resultString += s[i];
                    continue;
                }

                if (isNumber)
                {
                    resultString += s[i];
                }
                else
                {
                    break;
                }
            }

            if (resultString == null)
                return 0;

            checked
            {
                try
                {
                    int result = int.Parse(resultString);
                    return result * factor; 
                }
                catch(OverflowException ex)
                {
                    if(factor == -1)
                    {
                        return int.MinValue;
                    }
                    else
                    {
                        return int.MaxValue;
                    }
                }
            }
        }

        public static int MyAtoi2(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int index = 0;
            while (index < s.Length && s[index] == ' ')
            {
                index++;
            }

            int factor = 1;
            if (s[index] == '-')
            {
                factor = -1;
                index++;
            }
            else if (s[index] == '+')
            {
                index++;
            }

            while (index < s.Length && s[index] == '0')
            {
                index++;
            }

            byte[] ASCIIValues = Encoding.ASCII.GetBytes(s);
            string resultString = null;
            while (index < s.Length && (ASCIIValues[index] >= 48 && ASCIIValues[index] <= 57))
            {
                char symbol = Convert.ToChar(ASCIIValues[index]);
                resultString += symbol;
                index++;
            }

            if (resultString == null)
                return 0;
            int result;
            if(int.TryParse(resultString, out result))
            {
                return result * factor;
            }

            if (factor == -1)
            {
                return int.MinValue;
            }
            else
            {
                return int.MaxValue;
            }
        }

    }
}
