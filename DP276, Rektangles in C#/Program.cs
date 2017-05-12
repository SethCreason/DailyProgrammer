/*
 * DailyProgrammer Challenge #276: Rektangles
 * reddit.com/r/dailyprogrammer/comments/4tetif
 * Objective:  Given a word and some dimensions, print the word as a rectangle with the given dimensions
 * Example:  REKT, 1, 1:
 *                          R E K T
 *                          E     K
 *                          K     E
 *                          T K E R
 * Exmaple2: REKT, 2, 2:
 *                          T K E R E K T
 *                          K     E     K          
 *                          E     K     E
 *                          R E K T K E R
 *                          E     K     E
 *                          K     E     K
 *                          T K E R E K T
 * Author: Seth Creason
 * Date: 5.12.2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP276
{
    class Program
    {
        static void Main(string[] args)
        {

            Rektangles();
        }

        static void Rektangles()
        {
            Console.WriteLine("Please enter a word:");
            String word = Console.ReadLine();
            Console.WriteLine("Please enter the desired width:");
            int dim = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n"+word+" "+dim+"x"+dim+":\n");

            string output = "";
            int wordLength = word.Length - 1;
            int len = wordLength * dim + 1;
            int dir = dim % 2;

            if (!(dim >= 1))
            {
                Console.WriteLine("Something bad happened.");
                TryAgain();
            }

            try
            {
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (i % wordLength == 0 || j % wordLength == 0)
                        {
                            int k = (j + i) % wordLength;
                            if (j / wordLength % 2 != dir ^ i / wordLength % 2 == 0)
                                k = wordLength - k;
                            output += word[k] + " ";
                        }
                        else
                            output += "  ";
                    }
                    output += "\n";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something bad happened.");
            }

            Console.WriteLine(output);
            TryAgain();
            Console.ReadLine();
        }

        static void TryAgain()
        {
            Console.WriteLine("Would you like to try another word?\nY/N");
            String answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                Console.WriteLine();
                Rektangles();
            }
            else
                System.Environment.Exit(1);
        }
    }

}
