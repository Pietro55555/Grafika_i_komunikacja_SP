package gra;

import java.awt.Graphics;
import java.awt.Image;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;

import javax.swing.JPanel;

public class Renderer extends JPanel
{
    public Image tlo,postac,obiekt,pod;
    public Renderer()
    {
               try {
            tlo= ImageIO.read(new File("D:\\Pulpit\\Java\\PZ9\\src\\obrazy\\tlo.png"));
            postac= ImageIO.read(new File("D:\\Pulpit\\Java\\PZ9\\src\\obrazy\\postac.png"));
            obiekt= ImageIO.read(new File("D:\\Pulpit\\Java\\PZ9\\src\\obrazy\\obiekt.png"));
            pod= ImageIO.read(new File("D:\\Pulpit\\Java\\PZ9\\src\\obrazy\\floor.jpg"));
		} catch (IOException e) {
		System.out.println("Brak pliku");
		}
    }

	private static final long serialVersionUID = 1L;

	@Override
	protected void paintComponent(Graphics g)
	{
            g.drawImage(tlo,100,100,0,0,null);
		super.paintComponent(g);
		Gra.game.repaint(g);
                
	}
	
}
