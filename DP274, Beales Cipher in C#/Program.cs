/*
 * DailyProgrammer Challenge #274: The Beale Cipher
 * reddit.com/r/dailyprogrammer/comments/4r8fod
 * Objective:  Write a program to decipher Thomas Jefferson Beale's message
 * Details:  Beale's message, a list of numbers, corresponds to the Declaration
 *           of Independance.  Each number is the nth word, and that word's first 
 *           letter represents Beale's plaintext.
 * Author: Seth Creason
 * Date: 5.12.2017
 */
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DP274
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP274%2C%20Beales%20Cipher%20in%20C%23/DeclarationText.txt");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            string[] splitContent = content.Split(new char[0]);

            Stream stream2 = client.OpenRead("https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP274%2C%20Beales%20Cipher%20in%20C%23/Cipher.txt");
            StreamReader reader2 = new StreamReader(stream2);
            String content2 = reader2.ReadToEnd();
            string[] splitContent2 = content2.Replace(" ", "").Split(",".ToArray());

            Stream stream3 = client.OpenRead("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt");
            StreamReader reader3 = new StreamReader(stream3);
            String content3 = reader3.ReadToEnd();
            string[] splitContent3 = content3.Split("\n".ToArray());

            //Correcting errors in the cipher per Wiki @ unmuseum.org/bealepap.htm
            var correctionList = splitContent.ToList();
            correctionList.Insert(155, "a");
            correctionList.RemoveAt(241);
            correctionList.RemoveRange(490, 9);
            correctionList.RemoveAt(635);
            correctionList.RemoveAt(700);
            splitContent = correctionList.ToArray();
            splitContent[810] = "yundamentally";
            splitContent[1004] = "xave";

            //Spacing between words
            //splitContent[114] = splitContent[114] + " ";
            //splitContent[37] = splitContent[37] + " ";
            //splitContent[15] = splitContent[15] + " ";
            //words which should be followed by spaces:
            String[] spacing = new String[]
            {
                "115", "37", "15", "47", "79", "811", "196", "211", "554", "53", "82", "118"
            };

            for (int i = 0; i < splitContent2.Length; i++)
            {
                if (splitContent[i].Contains(" "))
                    Console.Write(splitContent[(Convert.ToInt32(splitContent2[i]) - 1)].Substring(0, 1) + " ");
                else
                    Console.Write(splitContent[(Convert.ToInt32(splitContent2[i]) - 1)].Substring(0, 1) );
            }
            Console.ReadLine();
        }
    }
}
