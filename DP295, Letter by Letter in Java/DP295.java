/*
 * DailyProgrammer Challenge #295: Letter by Letter
 * reddit.com/r/dailyprogrammer/comments/5hy8sm
 * Objective:  Change one sentence or string to another, one letter at a time
 * Author: Seth Creason
 * Date: 5.10.2017
 */
package dp295;

import java.lang.StringBuilder;

public class DP295 {

    public static void main(String[] args) {
        
        StringBuilder floor = new StringBuilder("floor");
        String brake = "brake";
        LetterByLetter(floor,brake);
        Sleep(1000);
        
        StringBuilder wood = new StringBuilder("wood");
        String book = "book";
        LetterByLetter(wood,book);
        Sleep(1000);
        
        StringBuilder fall = new StringBuilder("a fall to the floor");
        String door = "braking the door in";
        LetterByLetter(fall,door);
    }
    
    public static void LetterByLetter(StringBuilder first, String second) {
        System.out.println(first);
        Sleep(250);
        for (int i = 0; i < second.length(); i++) {
            first.setCharAt(i,second.charAt(i));
            System.out.println(first);
            Sleep(250);
        }
        System.out.println();
    }
    
    public static void Sleep(int time) {
        try {
            Thread.sleep(time);
        } catch(InterruptedException ex) {
            Thread.currentThread().interrupt();
        }
    }
}
