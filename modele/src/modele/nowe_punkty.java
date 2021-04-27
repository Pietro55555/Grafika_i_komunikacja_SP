
package modele;

import java.io.BufferedWriter;
import java.io.IOException;
import java.util.Scanner;

public class nowe_punkty 
{  
    public static void wyznacz(Scanner s,BufferedWriter buf) throws IOException
    {
            float x=0,y=0,z=0,xx,yy,zz;
            int ilosc = s.nextInt();
             Punkt[][] p=new Punkt[4][4];
            buf.write("x y z"+System.lineSeparator());
            for(int i = 0; i < ilosc; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    for(int k = 0; k < 4; k++)
                    {
                        xx = Float.parseFloat(s.next());
                        yy = Float.parseFloat(s.next());
                        zz = Float.parseFloat(s.next());

                        p[j][k] = new Punkt(xx, yy, zz);
                    }
                }

                for(float v = 0 ; v <= 1; v += 0.02) 
                {
                    for(float w = 0; w <= 1; w += 0.02)
                    {
                        for (int ii = 0; ii <= 3; ii++)
                        {
                            for(int jj = 0; jj <= 3; jj++)
                            {
                                x+= p[ii][jj].x * Math.pow(w,ii) * Math.pow(1-w,3-ii) * Newton(3,ii)* Math.pow(v,jj) * Math.pow(1-v,3-ii) * Newton(3,jj);
                                y+= p[ii][jj].y * Math.pow(w,ii) * Math.pow(1-w,3-ii) * Newton(3,ii)* Math.pow(v,jj) * Math.pow(1-v,3-ii) * Newton(3,jj);
                                z+= p[ii][jj].z * Math.pow(w,ii) * Math.pow(1-w,3-ii) * Newton(3,ii)* Math.pow(v,jj) * Math.pow(1-v,3-ii) * Newton(3,jj);
                            }
                        }
                        buf.write(x+" "+y+" "+z+System.lineSeparator());
                        x = 0;
                        y = 0;
                        z = 0;
                    }
                }
            }
            buf.close(); 
    }

    public static int Newton( int n, int k )
    {
        int  Wynik = 1; 
        int i;
        if( k != 0 || k != n )
        {
            for(i = 1; i <= k; i++) 
            {
            Wynik = Wynik * ( n - i + 1 ) / i;      
            }
            return Wynik;
        }
        else
         return 1;
    }   
}
