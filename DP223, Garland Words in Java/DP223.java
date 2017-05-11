/*
 * DailyProgrammer Challenge #223: Garland Words
 * reddit.com/r/dailyprogrammer/comments/3d4fwj
 * Objective 1:  Write a function that returns a word's "garland degree" if it's a garland word, 0 otherwise
 * Objective 2:  Print out a garland world several times
 * Objective 3:  Find the largest garland word in a given Enlish word list
 * Objective 4:  Find a garland word with a higher degree in another language
 * Example Garland Word: onion (ONiON), Degree: 2
 * Author: Seth Creason
 * Date: 5.11.2017
 */
package dp223;

import java.io.*;
import java.net.*;
import java.util.*;

public class DP223 {
    
    public static List<String> maxWord = new ArrayList<String>();
    public static int maxLength = 0;

    public static void main(String[] args) {
        System.out.println("programmer: " + garland("programmer"));
        System.out.println("ceramic: " + garland("ceramic"));
        System.out.println("onion: " + garland("onion"));
        System.out.println("alfalfa: " + garland("alfalfa"));
        System.out.println();
        
        System.out.println(DP223.repeat("benzeneazobenzene", 3));
    
        Map<String, String> urlList = new HashMap<String, String>();

        //OP's provided English list: undergrounder: 5
        urlList.put("opEnglish" , "https://storage.googleapis.com/google-code-archive-downloads/v2/code.google.com/dotnetperls-controls/enable1.txt"); 

        //My English list:  benzeneazobenzene: 7
        urlList.put("myEnglish" , "https://raw.githubusercontent.com/dwyl/english-words/master/words.txt");   

        //Latin:  quantarumquantarum: 9
        urlList.put("Latin" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/latin/latin.txt");

        //Swiss German: helfershelfer: 6, zinseszinses: 6
        urlList.put("swissGerman" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/swiss/swiss.txt"); 

        //German: helfershelfer: 6, zinseszinses: 6
        urlList.put("German" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/deutsch/deutsch.txt"); 

        //Dutch: ietsjepietsje: 6
        urlList.put("Dutch" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/nederlands/dutch.txt"); 

        //French: soufrent de soufre: 6
        urlList.put("French" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/francais/francais.txt"); 

        //Danish: ingeni�rgerningen: 5
        urlList.put("Danish" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/dansk/dansk.txt"); 

        //Spanish: adoradora: 5, alfalfal: 5
        urlList.put("Spanish" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/espanol/espanol.txt"); 

        //Italian: fuggifuggi: 5, restereste: 5
        urlList.put("Italian" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/italiano/italiano.txt"); 

        //Norwegian: abrakadabra: 4, barnebarn: 4, entente: 4, erverve: 4, gongong: 4
        urlList.put("Norwegian" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/norsk/norsk.txt"); 

        //Polish: CIE�CIE�: 4, CIE�CIE�: 4, DZIADZIA: 4, DZIUMDZIU: 4, NIE�NIE�: 4, OBY�OBY�: 4, PRZEPRZE: 4, ROWEROWE: 4, TACHTACH: 4, WA�OWA�O: 4, WSZYWSZY: 4, �CIE�CIE: 4, �NIE�NIE: 4
        urlList.put("Polish" , "https://raw.githubusercontent.com/SethCreason/DailyProgrammer/master/DP223%2C%20Garland%20Words%20in%20Java/lang/polish/polski.txt");
        
        try {
            URL myURL = new URL(urlList.get("Latin"));
            Scanner in = new Scanner(myURL.openStream());
            while (in.hasNext()) {
                String line = in.nextLine();
                garlandDictionary(line);
                System.out.println();
            }
        }
        catch(IOException e) {
            System.err.format("Something bad happened.\n");
            e.printStackTrace();
        }
    }
    
    public static String repeat(String word, int rep) {
        String ss = word.substring(garland(word));
        for(int i = 1; i < rep; i++) {
            word += ss;
        }
        return word;
    }
    public static int garland(String word) {
        int len = 0;
        for (int i = 1; i < word.length(); i++) {
            if (word.substring(0, i).equals(word.substring(word.length() - i, word.length()))) {
                len = i;
            }
        }
        return len;
    }
    public static void garlandDictionary(String word) {
        int len = 0;
        for (int i = 1; i < word.length(); i++) {
            if (word.substring(0, i).equals(word.substring(word.length() - i, word.length()))) {
                len = i;
            }
        }
        if (len > maxLength && len != 0){
            maxWord.clear();
            maxLength = len;
            maxWord.add(word + ": " + maxLength);
        }
        if (len == maxLength && len != 0){
            maxLength = len;
            maxWord.add(word + ": " + maxLength);
        }

        List<String> unique = removeDuplicates(maxWord);
        for (String element : unique) {
            System.out.print(element+" ");
        }
    }
    
    static List<String> removeDuplicates(List<String> list) {
        ArrayList<String> result = new ArrayList<>();
        HashSet<String> set = new HashSet<>();

        for (String item : list) {
            if (!set.contains(item)) {
                result.add(item);
                set.add(item);
            }
        }
        return result;
    }
}