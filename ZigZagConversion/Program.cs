using System;
using System.Text;

namespace ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "PAYPALISHIRING";
            var str = ConvertVisitByRow(s, 4);
            Console.WriteLine(str);
        }

        public static string Convert(string s, int numRows)
        {
            if(numRows == 1)
            {
                return s;
            }

            char [] strArr = s.ToCharArray();
            int numColumns = s.Length;
            var matrix = new char[numRows, numColumns];
            bool isDiagonal = false;

            for (
                int row = 0, column = 0, strCounter = 0; 
                s.Length > strCounter; 
                row = isDiagonal == false ? ++row : --row , column = isDiagonal == true ? ++column : column, strCounter++
            )
            {
                matrix[row, column] = strArr[strCounter];
                if(row == numRows - 1)
                {
                    isDiagonal = true;
                }
                else if(row == 0 && isDiagonal)
                {
                    isDiagonal = false;
                }
            }

            var resultString = new StringBuilder();
            for (int column  = 0; column < matrix.GetLength(0); column ++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    if(matrix[column, row] != '\x0000')
                    {
                        resultString.Append(matrix[column, row]);
                    }
                }
            }

            return resultString.ToString();
        }

        public static string ConvertVisitByRow(string s, int numRows)
        {
            if (numRows == 1) return s;

            var ret = new StringBuilder();
            int n = s.Length;
            int cycleLen = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j + i < n; j += cycleLen)
                {
                    ret.Append(s[j + i]);
                    if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                        ret.Append(s[j + cycleLen - i]);
                }
            }
            return ret.ToString();
        }
    }
}
