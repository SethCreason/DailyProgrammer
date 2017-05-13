/*
 * DailyProgrammer Challenge #312: L33tspeak Translator
 * reddit.com/r/dailyprogrammer/comments/67dxts
 * Objective:  Translate words to/from "leetspeak"
 * Self-Bonus:  Translate the Gettysburg Address to "leetspeak"
 * Author: Seth Creason
 * Date: 5.13.2017
 */
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace DP274
{
    class Program
    {
        static void Main(string[] args)
        {
            choice();
        }

        static void choice()
        {
            Console.WriteLine(" Would you like to (1) encrypt to leetspeak, (2) decrypt from leetspeak," +
                            "\n (3) try the something a bit more difficult, or (4) Quit?");
            var selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    {
                        Console.WriteLine("\n Please enter a word or phrase to translate to leetspeak:");
                        var word = Console.ReadLine();
                        encrypt(word);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\n Please enter a word or phrase to translate from leetspeak:");
                        var word = Console.ReadLine();
                        decrypt(word);
                        break;
                    }
                case 3:
                    Gettysburg();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    {
                        Console.WriteLine("\n Something bad happened.  Try again.\n");
                        choice();
                        break;
                    }
            }
        }

        static void encrypt(String word)
        {
            String A = "4";
            String B = "6";
            String E = "3";
            String I = "|";
            String L = "1";
            String M = "(V)";
            String N = "(\\)";
            String O = "0";
            String S = "5";
            String T = "7";
            String V = "\\/";
            String W = "`//";

            String[] splitWord = word.Split(new char[0]);
            Console.WriteLine();
            for (int i = 0; i < splitWord.Length; i++)
            {
                Console.Write(splitWord[i] + " -> ");
                splitWord[i] = splitWord[i].Replace("a", A);
                splitWord[i] = splitWord[i].Replace("A", A);
                splitWord[i] = splitWord[i].Replace("b", B);
                splitWord[i] = splitWord[i].Replace("B", B);
                splitWord[i] = splitWord[i].Replace("e", E);
                splitWord[i] = splitWord[i].Replace("E", E);
                splitWord[i] = splitWord[i].Replace("i", I);
                splitWord[i] = splitWord[i].Replace("I", I);
                splitWord[i] = splitWord[i].Replace("l", L);
                splitWord[i] = splitWord[i].Replace("L", L);
                splitWord[i] = splitWord[i].Replace("m", M);
                splitWord[i] = splitWord[i].Replace("M", M);
                splitWord[i] = splitWord[i].Replace("n", N);
                splitWord[i] = splitWord[i].Replace("N", N);
                splitWord[i] = splitWord[i].Replace("o", O);
                splitWord[i] = splitWord[i].Replace("O", O);
                splitWord[i] = splitWord[i].Replace("s", S);
                splitWord[i] = splitWord[i].Replace("S", S);
                splitWord[i] = splitWord[i].Replace("t", T);
                splitWord[i] = splitWord[i].Replace("T", T);
                splitWord[i] = splitWord[i].Replace("v", V);
                splitWord[i] = splitWord[i].Replace("V", V);
                splitWord[i] = splitWord[i].Replace("w", W);
                splitWord[i] = splitWord[i].Replace("W", W);

                Console.Write(" " + splitWord[i] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            choice();
            Console.ReadLine();
        }

        static void decrypt(String word)
        {
            String A = "4";
            String B = "6";
            String E = "3";
            String I = "|";
            String L = "1";
            String M = "(V)";
            String N = "(\\)";
            String O = "0";
            String S = "5";
            String T = "7";
            String V = "\\/";
            String W = "`//";

            String[] splitWord = word.Split(new char[0]);
            Console.WriteLine();
            for (int i = 0; i < splitWord.Length; i++)
            {
                Console.Write(splitWord[i] + " -> ");
                splitWord[i] = splitWord[i].Replace(A, "a");
                splitWord[i] = splitWord[i].Replace(B, "b");
                splitWord[i] = splitWord[i].Replace(E, "e");
                splitWord[i] = splitWord[i].Replace(I, "i");
                splitWord[i] = splitWord[i].Replace(L, "l");
                splitWord[i] = splitWord[i].Replace(M, "m");
                splitWord[i] = splitWord[i].Replace(N, "n");
                splitWord[i] = splitWord[i].Replace(O, "o");
                splitWord[i] = splitWord[i].Replace(S, "s");
                splitWord[i] = splitWord[i].Replace(T, "t");
                splitWord[i] = splitWord[i].Replace(V, "v");
                splitWord[i] = splitWord[i].Replace(W, "w");

                Console.Write(" " + splitWord[i] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            choice();
            Console.ReadLine();
        }

        static void Gettysburg()
        {

            //The Declaration of Independence
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP312%2C%20L33tspeak%20Translator/GettysburgAddress.txt");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            string[] splitContent = content.Split(new char[0]);

            Console.WriteLine("\n Try the Gettysburg Address in l33tspeak?\nY/N");
            String answer = Console.ReadLine().ToUpper();

            switch (answer)
            {
                case "Y":
                    {
                        for (int i = 0; i < splitContent.Length; i++)
                        {
                            splitContent[i] = splitContent[i].Replace("a", "4");
                            splitContent[i] = splitContent[i].Replace("A", "4");
                            splitContent[i] = splitContent[i].Replace("b", "6");
                            splitContent[i] = splitContent[i].Replace("B", "6");
                            splitContent[i] = splitContent[i].Replace("e", "3");
                            splitContent[i] = splitContent[i].Replace("E", "3");
                            splitContent[i] = splitContent[i].Replace("i", "|");
                            splitContent[i] = splitContent[i].Replace("I", "|");
                            splitContent[i] = splitContent[i].Replace("l", "1");
                            splitContent[i] = splitContent[i].Replace("L", "1");
                            splitContent[i] = splitContent[i].Replace("m", "(V)");
                            splitContent[i] = splitContent[i].Replace("M", "(V)");
                            splitContent[i] = splitContent[i].Replace("n", "(\\)");
                            splitContent[i] = splitContent[i].Replace("N", "(\\)");
                            splitContent[i] = splitContent[i].Replace("o", "0");
                            splitContent[i] = splitContent[i].Replace("O", "0");
                            splitContent[i] = splitContent[i].Replace("s", "5");
                            splitContent[i] = splitContent[i].Replace("S", "5");
                            splitContent[i] = splitContent[i].Replace("t", "7");
                            splitContent[i] = splitContent[i].Replace("T", "7");
                            splitContent[i] = splitContent[i].Replace("v", "\\/");
                            splitContent[i] = splitContent[i].Replace("V", "\\/");
                            splitContent[i] = splitContent[i].Replace("w", "`//");
                            splitContent[i] = splitContent[i].Replace("W", "`//");

                            Console.Write(splitContent[i] + " ");
                        }

                        Console.ReadLine();
                        break;
                    }
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    {
                        Console.WriteLine("\n Something bad happened.  Try again.\n");
                        choice();
                        break;
                    }
            }
        }
    }
}
