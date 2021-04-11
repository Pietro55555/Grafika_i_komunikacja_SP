package inicjaly;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JPanel;

  public  class Paint extends JPanel{

    @Override
    public void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        int punkty_kontr=3; //liczba wierzcholkow dla jednej krzywej
        int n=10000; //liczba punktow łuku krzywej do zlepienia
        int lk=16;
        int[]x_do =new int[lk*n]; //współrzędne x punktow do zlepienia
        int[]y_do =new int[lk*n]; //współrzędne y punktow do zlepienia
        double[] xk =new double[punkty_kontr]; //współrzędne x jednego łuku krzywej
        double[] yk =new double[punkty_kontr]; //współrzędne y jednego łuku krzywej
        double[] x =new double[lk*n]; //współrzędne rzeczywiste x punktow krzywej zlepianej
        double[] y =new double[lk*n]; //współrzędne rzeczywiste y punktow krzywej zlepianej
       double[] xb = {346,  347, 273  , 251  ,229, 191  , 175 , 164, 179  , 217  ,231,
           303  , 356  ,371, 407  , 413  ,415, 368  , 339  ,327, 258  , 234  ,221, 202,
           207  ,216, 296  , 324 , 335, 352  , 356  ,369, 305  , 287  ,275, 214  , 180  ,
           147, 137  , 139  ,144 , 223  , 239  ,253, 344  , 357  ,368, 359  , 350 ,346 }; //wspolrzedne X wierzcholkow wszystkich wielobokow Bezier'a(lk*lw wspolrzednych)
        double[] yb = {114, 126, 83, 87, 91 ,133, 149 ,160, 230, 243 ,248, 253, 265 ,
            268 ,288, 347 ,362 ,387 ,410 , 419, 393, 380 ,373 ,366 ,352 ,325, 393 ,367 ,
            357, 347, 332 ,280, 300, 288 ,280, 297 ,273 ,250, 145, 139 ,125, 60, 55 ,
            51 ,78, 85 ,91 ,126, 115 ,114};//wspolrzedne Y wierzcholkow wszystkich wielobokow Bezier'a(lk*lw wspolrzednych)

        int i,j,k,m,lzk,kk;
        double t;

        double sk=1./(n-1);   
        for(k=0,lzk=0;lzk<lk;lzk++) 
        {
            for(kk=0,t=0;kk<n;kk++,k++,t+=sk)
            {
                for(i=0;i<punkty_kontr;i++)
                {
                    xk[i]=xb[punkty_kontr*lzk+i]; yk[i]=yb[punkty_kontr*lzk+i];
                }

                m=punkty_kontr-1;

                for(i=0;i<punkty_kontr-1;i++)
                {
                    for(j=0;j<m;j++)
                    {
                    xk[j]=xk[j]+t*(xk[j+1]-xk[j]);
                    yk[j]=yk[j]+t*(yk[j+1]-yk[j]);
                    }
                    m--;
                }
                x[k]=xk[0];
                y[k]=yk[0];
            }
        }

        
        pasowanie pas = new pasowanie();
        int[] row = {30,30,470,470};    //okno
        pas.dopasuj(k, this.getHeight(), x, y, row, x_do, y_do);

        //narysowanie linii
        g.setColor(Color.blue);
        for(i=1;i<lk*n;i++)
        {
        g.drawLine(x_do[i-1], y_do[i-1], x_do[i], y_do[i]);
        }
        
        //######################################## LITERA P ##############################################
        //P jest odwrócone w ramach duszy i pomysłu artystycznego !!!
     
        punkty_kontr=3; //liczba wierzcholkow dla jednej krzywej
        n=10000; //liczba punktow łuku krzywej do zlepienia
        lk=5;
        int[]x_do_P =new int[lk*n]; //współrzędne x punktow do zlepienia
        int[]y_do_P =new int[lk*n]; //współrzędne y punktow do zlepienia
        double[] xk_P =new double[punkty_kontr]; //współrzędne x jednego łuku krzywej
        double[] yk_P =new double[punkty_kontr]; //współrzędne y jednego łuku krzywej
        double[] x_P =new double[lk*n]; //współrzędne rzeczywiste x punktow krzywej zlepianej
        double[] y_P =new double[lk*n]; //współrzędne rzeczywiste y punktow krzywej zlepianej
       double[] xb_P = {224 ,329 , 143 , 220 ,272 , 345 , 387 ,433 , 441 , 440  ,440 , 445 , 395  ,380 , 245 , 230  }; //wspolrzedne X wierzcholkow wszystkich wielobokow Bezier'a(lk*lw wspolrzednych)
       double[] yb_P = {414 , 460 ,111 , 104 , 99 , 102 , 102 , 102 , 117 , 171 , 186 , 249 , 256 , 258 , 258 , 258 };//wspolrzedne Y wierzcholkow wszystkich wielobokow Bezier'a(lk*lw wspolrzednych)

        sk=1./(n-1);   
        for(k=0,lzk=0;lzk<lk;lzk++) 
        {
            for(kk=0,t=0;kk<n;kk++,k++,t+=sk)
            {
                for(i=0;i<punkty_kontr;i++)
                {
                    xk_P[i]=xb_P[punkty_kontr*lzk+i]; yk_P[i]=yb_P[punkty_kontr*lzk+i];
                }

                m=punkty_kontr-1;

                for(i=0;i<punkty_kontr-1;i++)
                {
                    for(j=0;j<m;j++)
                    {
                    xk_P[j]=xk_P[j]+t*(xk_P[j+1]-xk_P[j]);
                    yk_P[j]=yk_P[j]+t*(yk_P[j+1]-yk_P[j]);
                    }
                    m--;
                }
                x_P[k]=xk_P[0];
                y_P[k]=yk_P[0];
            }
        }

        
        pasowanie pas_P = new pasowanie();
        pas_P.dopasuj(k, this.getHeight(), x_P, y_P, row, x_do_P, y_do_P);
        //narysowanie linii
        g.setColor(Color.red);
        for(i=1;i<lk*n;i++)
        {
        g.drawLine(x_do_P[i-1]+250, y_do_P[i-1], x_do_P[i]+260, y_do_P[i]+10);
        }
        
        
    }
}
