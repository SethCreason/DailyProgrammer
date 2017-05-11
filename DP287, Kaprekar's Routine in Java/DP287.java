/*
 * DailyProgrammer Challenge #287: Kaprekar's Routine
 * reddit.com/r/dailyprogrammer/comments/56tbds
 * Objective 1:  Write a function that returns the largest single digit in a number
 * Objective 2:  Write a function that returns a number's digits in descending order
 * Objective 3:  Write a function that returns how many times Kaprekar's Routine was used to reach the Kaprekar Constant 
 * Author: Seth Creason
 * Date: 5.10.2017
 */
package dp287;

import java.util.Arrays;
import java.util.Collections;

public class DP287 {

    public static void main(String[] args) {
        
        largest_digit(1234);
        largest_digit(3253);
        largest_digit(9800);
        largest_digit(3333);
        largest_digit(120);
        
        System.out.println();
        
        descending_digits(1234);
        descending_digits(3253);
        descending_digits(9800);
        descending_digits(3333);
        descending_digits(120);
        
        System.out.println();
        
        kaprekar(6589);
        kaprekar(5455);
        kaprekar(6174);
        
    }
    
    public static void largest_digit(int number){
        
        int[] newNumber = new int[4];
        
        while (number > 0) {
            for (int i = 0; i < 4; i++) {
                newNumber[i] = (number % 10);
                number = number / 10;
            }
        }
        
        int largest = Integer.MIN_VALUE;

        for(int i = 0; i < newNumber.length; i++) {
              if(newNumber[i] > largest) {
                 largest = newNumber[i];
              }
        }
        
        System.out.println(largest);
    }
    
    public static int descending_digits(int number){
        
        int[] newNumber = new int[4];
        
        while (number > 0) {
            for (int i = 0; i < 4; i++) {
                newNumber[i] = (number % 10);
                number = number / 10;
            }
        }
        
        String splitNumber[] = new String[4];
        
        for (int i = 0; i < newNumber.length; i++) {
            splitNumber[i] = Integer.toString(newNumber[i]);
        }
        
        Arrays.sort(splitNumber, Collections.reverseOrder());
        for (int i = 0; i < splitNumber.length; i++) {
            System.out.print(splitNumber[i]);
        }
        System.out.println();
        return number;
    }
        
    static int count = 0;
    
    public static void kaprekar(int number){
        
        final int kaprekar_const = 6174;
        
        if (number == kaprekar_const) {
            //count = 0;
            System.out.println(count);
            return;
        }
        
        int[] newNumber = new int[4];
        
        while (number > 0) {
            for (int i = 0; i < 4; i++) {
                newNumber[i] = (number % 10);
                number = number / 10;
            }
        }
        
        String splitNumber[] = new String[4];
        
        for (int i = 0; i < newNumber.length; i++) {
            splitNumber[i] = Integer.toString(newNumber[i]);
        }
        
        Arrays.sort(splitNumber, Collections.reverseOrder());        
        String desc = splitNumber[0] + splitNumber[1] + splitNumber[2] + splitNumber[3];        
        int desc_int = Integer.parseInt(desc);
        
        Arrays.sort(splitNumber);
        String asc = splitNumber[0] + splitNumber[1] + splitNumber[2] + splitNumber[3];         
        int asc_int = Integer.parseInt(asc);
        
        int result = desc_int - asc_int;
        if (result == kaprekar_const) {
            count++;
            System.out.println(count);
            count = 0;
            return;
        } else {
            count++;
            kaprekar(result);
        }
    }
}