/*
 * DailyProgrammer Challenge #277: Simplifying Fractions
 * reddit.com/r/dailyprogrammer/comments/4uhqdb
 * Objective:  Simplify fractions
 * Author: Seth Creason
 * Date: 5.11.2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP277
{
    class Program
    {
        static void Main(string[] args)
        {
            simplify(4, 8); // 1 2
            simplify(1536, 78360); // 64 3265
            simplify(51478, 5536); // 25739 2768
            simplify(46410, 119340); // 7 18
            simplify(7673, 4729); // 7673 4729
            simplify(4096, 1024); // 4 1
            Console.ReadLine();
        }

        public static void simplify(float numerator, float denominator)
        {
            for (float i = numerator; i > 0; i--)
            {
                if ((numerator / i % 1 == 0) && (denominator / i % 1 == 0))
                {
                    Console.WriteLine(numerator+"/"+denominator+" simplified: "+(numerator/i)+"/"+(denominator / i));
                    return;
                }
            }
        }
    }
}
