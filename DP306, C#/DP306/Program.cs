/*
 * DailyProgrammer Challenge #306: Pandigital Roman Numbers
 * reddit.com/r/dailyprogrammer/comments/5z4f3z
 * Objective:  Find the pandigital Roman numbers (numbers which use each of the symbols I, V, X, L, C, and M at least once), up to 2000
 * Challenge Output:  1444, 1446, 1464, 1466, 1644, 1646, 1664, 1666
 * Author: Seth Creason
 * Date: 5.10.2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP306
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 2000; i++)
            {
                String result = ToRoman(i);

                if (result.Contains("I") && (result.Count(f => f == 'I') == 1) &&
                    result.Contains("V") && (result.Count(f => f == 'V') == 1) &&
                    result.Contains("X") && (result.Count(f => f == 'X') == 1) &&
                    result.Contains("L") && (result.Count(f => f == 'L') == 1) &&
                    result.Contains("C") && (result.Count(f => f == 'C') == 1) &&
                    result.Contains("D") && (result.Count(f => f == 'D') == 1) &&
                    result.Contains("M") && (result.Count(f => f == 'M') == 1))
                { 
                    Console.WriteLine(i + ": " + result);
                }
            }
            Console.ReadLine();
        }

        public static string ToRoman(int number)
        {
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
