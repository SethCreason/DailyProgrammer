/*
 * DailyProgrammer Challenge #274: The Beale Cipher
 * reddit.com/r/dailyprogrammer/comments/4r8fod
 * Objective:  Write a program to decipher Thomas Jefferson Beale's message
 * Details:  Beale's message, a list of numbers, corresponds to the Declaration
 *           of Independance.  Each number is that nth word's first letter, and 
 *           the cominbation of those letters represent Beale's true message.
 * Author: Seth Creason
 * Date: 5.12.2017
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
            //The Declaration of Independence
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP274%2C%20Beales%20Cipher%20in%20C%23/DeclarationText.txt");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            string[] splitContent = content.Split(new char[0]);

            //Beale's message (list of numbers)
            Stream stream2 = client.OpenRead("https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP274%2C%20Beales%20Cipher%20in%20C%23/Cipher.txt");
            StreamReader reader2 = new StreamReader(stream2);
            String content2 = reader2.ReadToEnd();
            string[] splitContent2 = content2.Replace(" ", "").Split(",".ToArray());

            //Correcting errors in the cipher per Wiki @ unmuseum.org/bealepap.htm
            var correctionList = splitContent.ToList();
            correctionList.Insert(155, "a");
            correctionList.RemoveAt(241);
            correctionList.RemoveRange(490, 9);
            correctionList.RemoveAt(635);
            correctionList.RemoveAt(700);
            splitContent = correctionList.ToArray();
            splitContent[810] = "yundamentally"; splitContent[1004] = "xave";
            splitContent2[165] = "7"; splitContent2[222] = "85"; splitContent2[252] = "35"; splitContent2[366] = "7"; splitContent2[530] = "54";
            splitContent2[636] = "35"; splitContent2[696] = "18"; splitContent2[697] = "7"; splitContent2[698] = "110"; splitContent2[701] = "85";
            splitContent2[722] = "239";

            //Formatting. Unnecessary for challenge.
            int[] spaces = new int[] { 1,5,14,16,19,25,27,34,39,43,48,52,59,61,63,73,75,80,83,87,92,95,102,104,107,116,116,125,113,142,149,151,154,
                                       161,166,171,174,179,181,187,192,200,203,208,215,224,226,229,236,239,247,253,255,259,262,268,273,280,283,289,
                                       295,297,303,312,315,323,331,334,340,343,347,350,358,364,367,370,379,381,389,396,399,404,410,412,416,419,425,
                                       432,435,441,446,448,454,458,464,472,474,476,481,483,491,493,497,511,514,520,522,530,538,545,548,553,555,563,
                                       569,571,575,579,583,587,593,596,601,603,610,615,619,624,627,630,637,641,643,648,653,656,659,666,670,676,681,
                                       687,690,699,702,707,715,717,720,725,727,731,733,743,747,749,752,754,761,763,150 };
            int[] commas = new int[] { 34, 59, 80, 113, 133, 259, 303, 315, 350, 367, 419, 511, 579, 624, 653 };
            int[] periods = new int[] { 331, 545, 593, 676 };
            //Formatting. Unnecessary for challenge.

            for (int i = 0; i < splitContent2.Length; i++)
            {
                //Formatting. Unnecessary for challenge.
                if (commas.Contains(i))
                    Console.Write(",");
                if (periods.Contains(i))
                    Console.Write(".");
                if (i == 200)
                    Console.Write(":");
                if (i == 454)
                    Console.Write(";");
                if (spaces.Contains(i))
                    Console.Write(" ");
                if (i == 200 || i == 545)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
                //Formatting. Unnecessary for challenge.

                int pos = Convert.ToInt32(splitContent2[i]);
                Console.Write(splitContent[(pos-1)].Substring(0, 1) );
            }

            Console.ReadLine();
        }
    }
}
