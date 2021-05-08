using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modyfikacja_histogramu
{
    public partial class Form1 : Form
    {
        private int szer = 0, wys = 0;
        private int[] red = null;
        private int[] green = null;
        private int[] blue = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] tonred = tablica_tonalna(red, szer * wys);
            int[] tongreen = tablica_tonalna(green, szer * wys);
            int[] tonblue = tablica_tonalna(blue, szer * wys);
            Color k,j;
           Bitmap photo1=(Bitmap)pictureBox1.Image;
           Bitmap photo2 = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    j = photo1.GetPixel(x, y);
                    k = Color.FromArgb(tonred[j.R], tongreen[j.G], tonblue[j.B]);
                    photo2.SetPixel(x, y, k);     
                }
            }
            pictureBox2.Invalidate();

        }

        private int[] tablica_tonalna(int[] values, int size)
        {
            //poszukaj wartości minimalnej
            double minValue = 0;
            for (int i = 0; i < 256; i++)
            {
                if (values[i] != 0)
                {
                    minValue = values[i];
                    break;
                }
            }

            int[] result = new int[256];
            double sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += values[i];
                result[i] = (int)(((sum - minValue) / (size - minValue)) * 255.0);
            }

            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int prom = (int)numericUpDown1.Value;
            int[,] maska = new int[3, 3];

            maska[0, 0] = prom;
            maska[0, 1] = prom;
            maska[0, 2] = prom;

            maska[1, 0] = prom;
            maska[1, 1] = prom;
            maska[1, 2] = prom;

            maska[2, 0] = prom;
            maska[2, 1] = prom;
            maska[2, 2] = prom;

            int norm = 0;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];        //normowanie maski

            int r, g, b;
            Color k;
            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    r = g = b = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            k = photo1.GetPixel(x + i - 1, y + j - 1);
                            r += k.R * maska[i, j];
                            g += k.G * maska[i, j];
                            b += k.B * maska[i, j];
                        }
                    }
                    if (norm != 0)
                    {
                        r /= norm;
                        g /= norm;
                        b /= norm;
                    }

                    if (r < 0)
                        r = 0;

                    if (r > 255)
                        r = 255;

                    if (g < 0)
                        g = 0;

                    if (g > 255)
                        g = 255;

                    if (b < 0)
                        b = 0;

                    if (b > 255)
                        b = 255;

                    photo2.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }
            pictureBox2.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int prom = (int)numericUpDown1.Value;
            int[,] maska = new int[3, 3];

            maska[0, 0] = maska[1, 0] / 2;
            maska[0, 1] = prom/2;
            maska[0, 2] = maska[1, 2]/2;

            maska[1, 0] = prom / 2;
            maska[1, 1] = prom;
            maska[1, 2] = prom / 2;

            maska[2, 0] = maska[1, 0] / 2;
            maska[2, 1] = prom/2;
            maska[2, 2] = maska[1, 2] / 2;

            int norm = 0;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    norm += maska[i, j];        //normowanie maski

            int r, g, b;
            Color k;
            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    r = g = b = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            k = photo1.GetPixel(x + i - 1, y + j - 1);
                            r += k.R * maska[i, j];
                            g += k.G * maska[i, j];
                            b += k.B * maska[i, j];
                        }
                    }
                    if (norm != 0)
                    {
                        r /= norm;
                        g /= norm;
                        b /= norm;
                    }

                    if (r < 0)
                        r = 0;

                    if (r > 255)
                        r = 255;

                    if (g < 0)
                        g = 0;

                    if (g > 255)
                        g = 255;

                    if (b < 0)
                        b = 0;

                    if (b > 255)
                        b = 255;

                    photo2.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }
            pictureBox2.Invalidate();
        }


        //wczytaj///////////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);

                //Obliczam histogram
                red = new int[256];
                green = new int[256];
                blue = new int[256];
                for (int x = 0; x < szer; x++)
                {
                    for (int y = 0; y < wys; y++)
                    {
                        Color pixel = ((Bitmap)pictureBox1.Image).GetPixel(x, y);
                        red[pixel.R]++;
                        green[pixel.G]++;
                        blue[pixel.B]++;
                    }
                }
            }
        }
    }
}
