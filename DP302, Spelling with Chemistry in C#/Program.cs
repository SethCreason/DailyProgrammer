/*
 * DailyProgrammer Challenge #302: Spelling with Chemistry
 * reddit.com/r/dailyprogrammer/comments/5seexn
 * Objective:  Write a program which takes an input word, and substitutes
 *             the letters within with the name of the element which shares
 *             the letter(s) in its symbol on the IUPAC Periodic Table of Elements 
 * Author: Seth Creason
 * Date: 5.14.2017
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DP302
{
    class Program
    {
        static void Main(string[] args)
        {
            chemSpell("functions");
            chemSpell("bacon");
            chemSpell("poison");
            chemSpell("sickness");
            chemSpell("ticklish");
            Console.ReadLine();
        }

        static void chemSpell(String word)
        {
            var filePath = (@"C:\Users\Seth\Documents\Visual Studio 2015\Projects\DP302\DP302\bin\Debug\elements.csv");
            var dictionary = File.ReadLines(filePath).Select(line => line.Split(',')).ToDictionary(data => data[0], data => data[1]);

            
            char[] wordSplit = word.ToLower().ToCharArray();

            for (int i = 0; i < wordSplit.Length; i++)
            {
                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    if (wordSplit[i].ToString().Equals(kvp.Key.ToLower()))
                    {
                        Console.Write(kvp.Key);
                        break;
                    }
                    else if (i < (wordSplit.Length - 1) && wordSplit[i].ToString() != kvp.Key.ToLower() && (wordSplit[i].ToString() + wordSplit[i + 1].ToString()).Equals(kvp.Key.ToLower()))
                    {
                        Console.Write(kvp.Key);
                        i++;
                        break;
                    }
                }
            }

            Console.Write(" (");

            for (int i = 0; i < wordSplit.Length; i++)
            {
                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    if (wordSplit[i].ToString().Equals(kvp.Key.ToLower()))
                    {
                        Console.Write(" " + kvp.Value);
                        break;
                    }
                    else if (i < (wordSplit.Length - 1) && wordSplit[i].ToString() != kvp.Key.ToLower() && (wordSplit[i].ToString() + wordSplit[i + 1].ToString()).Equals(kvp.Key.ToLower()))
                    {
                        Console.Write(" " + kvp.Value);
                        i++;
                        break;
                    }
                }
                Console.Write(" ");
            }

            Console.Write(")");
            Console.WriteLine();
        }
    }
}
