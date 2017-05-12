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
            int[] spaces2 = new int[] { 115, 37, 15, 47, 79, 811, 196, 211, 554, 53, 35, 82, 71, 287, 353, 47, 59, 41, 1005, 16, 72/*below - end line 1 Output*/,
                                       85, 191, 273, 620, 63, 191, 48, 110, 48};
            int[] spaces = new int[] {115};

            foreach (int i in spaces)
            {
                splitContent[i] = splitContent[i] + " ";
            }

            for (int i = 0; i < splitContent2.Length; i++)
            {
                if (i == 1 || i == 5 || i == 14 || i == 16 || i == 19 || i == 25 || i == 27 || i == 34 || i == 39 || i == 43 || i == 48 || i == 52 || i == 59 ||
                    i == 61 || i == 63 || i == 73 || i == 75 || i == 80 || i == 83 || i == 87 || i == 92 || i == 95 || i == 102 || i == 104 || i == 107 || i == 113 || 
                    i == 116 || i == 125 || i == 133 || i == 142 || i == 149 || i == 151 || i == 154 || i == 161 || i == 166 || i == 171 || i == 174 || i == 179 ||
                    i == 181 || i == 187 || i == 192 || i == 200 /*End of first paragraph*/ || i == 203 || i == 208 || i == 215 || i == 224 || i == 226 || i == 229 || 
                    i == 236 || i == 239 || i == 247 || i == 253 || i == 255 || i == 259 || i == 262 || i == 268 || i == 273 || i == 280 || i == 283 || i == 289 ||
                    i == 295 || i == 297 || i == 303 || i == 312 || i == 315 || i == 323 || i == 331 || i == 334 || i == 340 || i == 343 || i == 347 || i == 350 ||
                    i == 358 || i == 364 || i == 367 || i == 370 || i == 379 || i == 381 || i == 389 || i == 396 || i == 399 || i == 404 || i == 410 || i == 412 ||
                    i == 416 || i == 419 || i == 425 || i == 432 || i == 435 || i == 441 || i == 446 || i == 448 || i == 454 || i == 458 || i == 464 || i == 472 ||
                    i == 474 || i == 476 || i == 481 || i == 483 || i == 491 || i == 493 || i == 497 || i == 511 || i == 514 || i == 520 || i == 522 || i == 530 ||
                    i == 538 || i == 545 /*End of first paragraph*/ || i == 548 || i == 553 || i == 555 || i == 563 || i == 569 || i == 571 || i == 575 || i == 579 ||
                    i == 583 || i == 587 || i == 593 || i == 596 || i == 601 || i == 603 || i == 610 || i == 615 || i == 619 || i == 624 || i == 627 || i == 630 ||
                    i == 637 || i == 641 || i == 643 || i == 648 || i == 653 || i == 656 || i == 659 || i == 666 || i == 670 || i == 676 || i == 681 || i == 687 ||
                    i == 690 || i == 699 || i == 702 || i == 707 || i == 715 || i == 717 || i == 720 || i == 725 || i == 727 || i == 731 || i == 733 || i == 743 ||
                    i == 747 || i == 749 || i == 752 || i == 754 || i == 761 || i == 763)
                    Console.Write(" ");
                if (i == 200 || i == 545)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }


                int pos = Convert.ToInt32(splitContent2[i]);
                Console.Write(splitContent[(pos-1)].Substring(0, 1) );
            }

            Console.ReadLine();
        }
    }
}
