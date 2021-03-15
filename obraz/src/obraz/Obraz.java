
package obraz;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
import javax.swing.JFrame;

public class Obraz {

    public Rectangle kwadrat;
            
    public Obraz()
    {
        JFrame jframe = new JFrame() 
               {
          @Override public void paint(Graphics g) 
          {
             //owal 1
             g.setColor(new Color(80,0,0));
             g.fillOval(200, 30, 750, 750);
             //kwadrat 1
             g.setColor(new Color(100,0,0));
             g.fillRect(310, 145, 530, 525);
             //owal 2 
             g.setColor(new Color(120,0,0));
             g.fillOval(310, 145, 530, 525);
             //kwadrat 2
             g.setColor(new Color(140,0,0));
             g.fillRect(390, 220, 370,375);
             //owal 3
             g.setColor(new Color(160,0,0));
             g.fillOval(390, 220, 370,375);
             //kwadrat 3
             g.setColor(new Color(180,0,0));
             g.fillRect(450, 270, 250,275);
             //owal 4
             g.setColor(new Color(200,0,0));
             g.fillOval(450, 270, 250,275);
             //kwadrat 3
             g.setColor(new Color(220,0,0));
             g.fillRect(488, 310, 175,195);
             //owal 4
             g.setColor(new Color(240,0,0));
             g.fillOval(488, 310, 175,195);
          }
        };
        
       jframe.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
       jframe.setSize(1200,800);
       jframe.setVisible(true);
       jframe.setResizable(false);
       jframe.setTitle("Obraz");
    }
    
    public static void main(String[] args) 
    {
        Obraz ob=new Obraz();
    }
    
}
