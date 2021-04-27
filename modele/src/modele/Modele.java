
package modele;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class Modele 
{

    public static void main(String[] args) throws IOException 
    {
     Scanner s1, s2, s3;
     BufferedWriter buf1, buf2, buf3;
     File in1, out1, in2, out2, in3, out3;
       in1=new File("src\\modele\\czajnik_input.txt");
       in2=new File("src\\modele\\kubek_input.txt");
       in3=new File("src\\modele\\lyzka_input.txt");  
       out1=new File("src\\modele\\czajnik_output.txt");
       out2=new File("src\\modele\\kubek_output.txt");
       out3=new File("src\\modele\\lyzka_output.txt");  
        s1 = new Scanner(in1);
        buf1 = new BufferedWriter(new FileWriter(out1));
        s2 = new Scanner(in2);
        buf2 = new BufferedWriter(new FileWriter(out2));
        s3 = new Scanner(in3);
        buf3 = new BufferedWriter(new FileWriter(out3));    
        nowe_punkty.wyznacz(s1,buf1);
        nowe_punkty.wyznacz(s2,buf2);
        nowe_punkty.wyznacz(s3,buf3);
    }
    
}
