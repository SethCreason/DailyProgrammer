/*
 * DailyProgrammer Challenge #296: The Twelve Days of Christmas
 * reddit.com/r/dailyprogrammer/comments/5j6ggm
 * Objective:  Print out the lyrics of The Twelve Days of Christmas
 * Author: Seth Creason
 * Date: 5.10.2017
 */
package dp296;

public class DP296 {

    public static void main(String[] args) {
        String[] day = new String[]{"first", "second", "third", "fourth", "fifth", "sixth",
                                    "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"};
        
        String[] gifts = new String[]{"A Partridge in a Pear Tree", "Two Turtle Doves\n", "Three French Hens\n",
               "Four Calling Birds\n", "Five Golden Rings\n", "Six Geese a Laying\n",
               "Seven Swans a Swimming\n", "Eight Maids a Milking\n", "Nine Ladies Dancing\n",
               "Ten Lords a Leaping\n", "Eleven Pipers Piping\n", "Twelve Drummers Drumming\n"};     
        
        for (int i = 0; i < 12; i++) {
            System.out.println("\nOn the " + day[i] + " of Christmas,\nMy true love sent to me:");
            for (int j = i; j >= 0; j--) {
                if (j>0) gifts[0] = "And a Partridge in a Pear Tree";
                System.out.print(gifts[j]);
            }
            System.out.println();
        }
    }
}