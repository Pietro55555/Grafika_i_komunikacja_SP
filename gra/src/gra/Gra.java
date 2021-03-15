
package gra;

import gra.*;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Random;
import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.Timer;


public class Gra implements ActionListener, MouseListener, KeyListener
{
    
    
	public static Gra game;
        
	public final int WIDTH = 1500, HEIGHT = 400;
        
        public Renderer renderer;
        
        public Rectangle postac,floor,obiekt;
        
        public ArrayList<Rectangle> obiekty;
        
        public int yMotion, xMotion, tick,wynik,kontrol,speed=5;
        
        public Random rand;
        
        public boolean gameover,started;
 
    
    public Gra()
    {
       JFrame jframe = new JFrame();
       Timer timer = new Timer(20, this);
       
       renderer = new Renderer();
       rand = new Random();
       
       jframe.add(renderer);
       jframe.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
       jframe.setSize(WIDTH, HEIGHT);
       jframe.setVisible(true);
       jframe.addMouseListener(this);
       jframe.addKeyListener(this);
       jframe.setResizable(false);
       jframe.setTitle("Gra");
       

       
       postac = new Rectangle (WIDTH /2 - 400, HEIGHT /2 , 60 , 60);
       floor = new Rectangle (0, HEIGHT -100, WIDTH, 65);
       obiekty = new ArrayList<Rectangle>();
      
               
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       dodaj_obiekt(true);
       
       
       timer.start();
       
    }
       
    	public void dodaj_obiekt(boolean start)
	{
            
           int height= 10 +rand.nextInt(80);
            
            if(start)
            {
                obiekty.add(new Rectangle(WIDTH + 300 + obiekty.size() * 200, HEIGHT - height - 150, 60, 60));
            }
            else
            {
               obiekty.add(new Rectangle(obiekty.get(obiekty.size() - 1).x + 200, HEIGHT - height - 150, 60, 60)); 
            }
	}
    
    
    	public void narysuj_obiekt(Graphics g, Rectangle obiekt)
	{
		//g.setColor(Color.green.darker());
		//g.fillRect(obiekt.x, obiekt.y, obiekt.width, obiekt.height);
                g.drawImage(renderer.obiekt,obiekt.x, obiekt.y, obiekt.width, obiekt.height,null);
	}

    
    
public void repaint(Graphics g)
{               g.drawImage(renderer.tlo,0,0,WIDTH,HEIGHT-100,null);
		//g.setColor(Color.cyan);
		//g.fillRect(0, 0, WIDTH, HEIGHT);
                
		//g.setColor(Color.GREEN.darker());
		//g.fillRect(floor.x,floor.y,floor.width,floor.height);
                g.drawImage(renderer.pod,floor.x,floor.y,floor.width,floor.height,null);
                
                g.drawImage(renderer.postac, postac.x, postac.y,postac.width, postac.height, null);
                //g.setColor(Color.red);
                //g.fillRect(postac.x, postac.y, postac.width, postac.height);
                
                
                for (Rectangle obiekt : obiekty)
		{
			narysuj_obiekt(g, obiekt);
		}
                
                g.setColor(Color.white);
                g.setFont(new Font("Arial", 1, 100));
                
                if (!started)
		{
			g.drawString("Naciśnij by zacząć", 75, HEIGHT / 2 - 50);
		}
                
                
                
                if(gameover)
                {
                    g.drawString("Koniec Gry", 100, HEIGHT / 2 - 50);
                    g.setColor(Color.YELLOW);
                    g.setFont(new Font("Arial", 4, 50));
                    g.drawString("Ilość punktów", 645, HEIGHT / 2 - 100);
                    g.setFont(new Font("Arial", 1, 75));
                    g.drawString(String.valueOf(wynik), 800, HEIGHT / 2 - 10);
                }
                
                
                
}
        
        @Override
    public void actionPerformed(ActionEvent e)
    { 
        tick++;
        if(tick %2 == 0 && yMotion < 16)
        {
            yMotion += 4;           //grawitacja
        }
        postac.y += yMotion;
        postac.x -= xMotion;
        
        if(postac.intersects(floor))
        {
            postac.y = floor.y-postac.height;         //kolizja z podłożem
        }    
        
        if(started)
        {
        
///////////////////////////////// PRZESZKODY /////////////////////////////////

			for (int i = 0; i < obiekty.size(); i++)
			{
				Rectangle obiekt = obiekty.get(i);

				obiekt.x -= speed;
                                
                            if(obiekt.intersects(postac))
                            {
                               kolizja(obiekt) ;            
                            }
                            
			}
                        
                            

			for (int i = 0; i < obiekty.size(); i++)
			{
                            
				Rectangle obiekt = obiekty.get(i);

					if (obiekt.x <= (obiekt.width)*(-1) && gameover == false)
					{
                                            obiekty.remove(obiekt);
                                            wynik++;
                                            kontrol++;
                                            if(kontrol == 5)
                                            {
                                            speed+=(int)(Math.log(wynik));
                                            kontrol=0;
                                            }
                                            
                                            System.out.println(speed);
						dodaj_obiekt(false);
					}
                                        else
                                        if (obiekt.x <= (obiekt.width)*(-1) && gameover)
                                        {
                                            obiekty.remove(obiekt);
                                        }
                                            
                                            
                                     
			}
                        
 ///////////////////////////// POSTAC /////////////////////////////////////                     
           for (Rectangle obie : obiekty)
           {
               if(postac.x<= (postac.width*(-1)) || postac.x>=WIDTH+postac.width)
               {
                   gameover = true;
               }
           }

        renderer.repaint();
   
    }

    
    
/////////////////////////////////////////////////////////////////////////////////
  }  
    public static void main(String[] args) 
    {
       game = new Gra();
       
    }  

        @Override
	public void mouseClicked(MouseEvent e)
	{
	}
        
        @Override
	public void keyReleased(KeyEvent e)
	{
            
                if(e.getKeyCode() == KeyEvent.VK_D || e.getKeyCode() == KeyEvent.VK_RIGHT)
                {
                        xMotion = 0;
                }

                if(e.getKeyCode() == KeyEvent.VK_A || e.getKeyCode() == KeyEvent.VK_LEFT)
                {
                        xMotion = 0;
                }
        
	}
        
        
        
        @Override
	public void keyPressed(KeyEvent e)
	{
            if(e.getKeyCode() == KeyEvent.VK_W || e.getKeyCode() == KeyEvent.VK_UP) //skok
            {
            	if (yMotion > 0 && (postac.y == floor.y-postac.width))
                {
                    yMotion = 0;
                    yMotion -= 20;
                }
                
                        if(!started)
                        {
                            started = true;
                        }
                
            }

            
            if(xMotion >=-10)
            {
                if(e.getKeyCode() == KeyEvent.VK_D || e.getKeyCode() == KeyEvent.VK_RIGHT) //prawo
                {
                   xMotion -= 10; 
                   
                        if(!started)
                        {
                            started = true;
                        }
                }
            }
            
            if(xMotion <=10)
            {
                if(e.getKeyCode() == KeyEvent.VK_A || e.getKeyCode() == KeyEvent.VK_LEFT) //lewo
                {
                   xMotion += 10; 
                   
                       if(!started)
                       {
                           started = true;
                       }
                }
            }
	}
        
        
        
	@Override
	public void mousePressed(MouseEvent e)
	{
	}
        
        @Override
	public void mouseReleased(MouseEvent e)
	{
	}

        @Override
	public void mouseEntered(MouseEvent e)
	{
	}

        @Override
	public void mouseExited(MouseEvent e)
	{
	}

        @Override
	public void keyTyped(KeyEvent e)
	{   
	}



     public void kolizja(Rectangle ob)
 {
        if(!(postac.intersects(ob)))
        {
            return ;
        }
     
     
           if(postac.y < ob.y && ob.y !=postac.y) // kolizja góry obiektu (NIE postaci)
        {
            
             postac.y = ob.y-ob.width;
        }
              
            
        if(postac.y > ob.y-ob.width && ob.y !=postac.y ) // kolzija dołu obiektu //wykrywa że gracz jest niżej niz blok
        {
            if(ob.y<=postac.y+ob.width && ob.x != postac.x && ob.y+ob.width <= 240)        //kolizja właściwa
             postac.y = ob.y+ob.width;
                
        }
        
            
        if(postac.x <= ob.x && postac.y==240 )          // kolizja lewej ściany obiektu
        {
           postac.x = ob.x-ob.width;         
        }
        
        
            
        if(postac.x >= ob.x && postac.y==240)         //kolizja prawej ściany obiektu
        {
           postac.x = ob.x+ob.width;  
        }
 }
    
    
    
}
