
package inicjaly;
import java.awt.*;
import javax.swing.*;

public class Inicjaly 
{
    public static void main(String[] args) 
    {
    JFrame window = new JFrame();
    window.setVisible(true);
    window.setSize(800, 700);
    window.setTitle("Inicjały");
    window.setResizable(false);
    window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    window.setBackground(Color.white);
    Paint rysuj = new Paint();
    window.getContentPane().add(rysuj);
    }
}


