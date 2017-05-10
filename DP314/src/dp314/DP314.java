/*
 * DailyProgrammer Challenge #314: Concatenated Integers
 * reddit.com/r/dailyprogrammer/comments/69y21t
 * Objective:  Print the largest and smallest values obtained from a list of integers
 * Challenge Example Input:  [79, 82, 34, 83, 69] [420, 34, 19, 71, 341] [17, 32, 91, 7, 46]
 * Challenge Example Output:  [3469798283],[8382796934] [193413442071 ],[714203434119] [173246791],[917463217]
 * Author: Seth Creason
 * Date: 5.10.2017
 */
package dp314;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class DP314 {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        body(input);
    }


    public static void body (Scanner input) {
        String min = "";
        String max = "";

        System.out.print("Please enter a list of integers: ");

        while(input.hasNextLine()){

            String userInput = input.nextLine();
            String parsedInput[] = userInput.split(" ");

            for (int i = 0; i < parsedInput.length; i++) {
                parsedInput[i] = parsedInput[i].replaceAll("[^\\w]", "");   
                if (parsedInput[i].startsWith("0") || parsedInput[i].matches(".*[a-z].*")) {
                    System.out.println("\nLeading 0's and characters are not allowed.\n");
                    parsedInput = new String[0];
                    body(input);
                    return;
                }
            }

            Comparator<String> compareString = new Comparator<String>(){
                 public int compare(String o1, String o2) {
                     return (o2 + o1).compareTo(o1 + o2);
                 }
            };

            Arrays.sort(parsedInput,compareString);

            for(String s : parsedInput){
                 max = max + s;
                 min = s + min;
            }

            System.out.println("\nThe lowest possible number is: " + min +
                               "\nThe highest possible number is: " + max);
            break;
        }
    }
}