using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filtry
{
    public partial class Form1 : Form
    {
        private int szer = 0, wys = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //zapisz/////////////////////////////////////////////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }
        }
        //przenies z dolu na gore//////////////////////////////////////////////
        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
            pictureBox1.Invalidate();
        }
        //roberts pozio//////////////////////////////////////////////////////////
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            maska[0, 0] = 0;
            maska[0, 1] = 0;
            maska[0, 2] = 0;

            maska[1, 0] = 0;
            maska[1, 1] = 1;
            maska[1, 2] = -1;

            maska[2, 0] = 0;
            maska[2, 1] = 0;
            maska[2, 2] = 0;

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
        //roberts pion////////////////////////////////////////////////////////
        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            maska[0, 0] = 0;
            maska[0, 1] = 0;
            maska[0, 2] = 0;

            maska[1, 0] = 0;
            maska[1, 1] = 1;
            maska[1, 2] = 0;

            maska[2, 0] = 0;
            maska[2, 1] = -1;
            maska[2, 2] = 0;

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
        //prewitta pozio///////////////////////////////////////////////////
        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            maska[0, 0] = 1;
            maska[0, 1] = 1;
            maska[0, 2] = 1;

            maska[1, 0] = 0;
            maska[1, 1] = 0;
            maska[1, 2] = 0;

            maska[2, 0] = -1;
            maska[2, 1] = -1;
            maska[2, 2] = -1;

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
        //prewitta pion/////////////////////////////////////////////////////
        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            maska[0, 0] = 1;
            maska[0, 1] = 0;
            maska[0, 2] = -1;

            maska[1, 0] = 1;
            maska[1, 1] = 0;
            maska[1, 2] = -1;

            maska[2, 0] = 1;
            maska[2, 1] = 0;
            maska[2, 2] = -1;

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
        //sobela pozio////////////////////////////////////////////////////
        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            maska[0, 0] = 1;
            maska[0, 1] = 2;
            maska[0, 2] = 1;

            maska[1, 0] = 0;
            maska[1, 1] = 0;
            maska[1, 2] = 0;

            maska[2, 0] = -1;
            maska[2, 1] = -2;
            maska[2, 2] = -1;

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
        //sobel pion//////////////////////////////////////////////////////
        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            maska[0, 0] = 1;
            maska[0, 1] = 0;
            maska[0, 2] = -1;

            maska[1, 0] = 2;
            maska[1, 1] = 0;
            maska[1, 2] = -2;

            maska[2, 0] = 1;
            maska[2, 1] = 0;
            maska[2, 2] = -1;

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
        //laplace
        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];

            if (radioButton1.Checked == true)
            { 
            maska[0, 0] = 0;
            maska[0, 1] = -1;
            maska[0, 2] = 0;

            maska[1, 0] = -1;
            maska[1, 1] = 4;
            maska[1, 2] = -1;

            maska[2, 0] = 0;
            maska[2, 1] = -1;
            maska[2, 2] = 0;
            }
            else
            if (radioButton2.Checked == true)
            {
                maska[0, 0] = -1;
                maska[0, 1] = -1;
                maska[0, 2] = -1;

                maska[1, 0] = -1;
                maska[1, 1] = 8;
                maska[1, 2] = -1;

                maska[2, 0] = -1;
                maska[2, 1] = -1;
                maska[2, 2] = -1;
            }
            else
            if (radioButton3.Checked == true)
            {
                maska[0, 0] = -2;
                maska[0, 1] = 1;
                maska[0, 2] = -2;

                maska[1, 0] = 1;
                maska[1, 1] = 4;
                maska[1, 2] = 1;

                maska[2, 0] = -2;
                maska[2, 1] = 1;
                maska[2, 2] = -2;
            }
            else
            {
                maska[0, 0] = 0;
                maska[0, 1] = 0;
                maska[0, 2] = 0;

                maska[1, 0] = 0;
                maska[1, 1] = 1;
                maska[1, 2] = 0;

                maska[2, 0] = 0;
                maska[2, 1] = 0;
                maska[2, 2] = 0;
            }


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
        //min/////////////////////////////////////////////////////////////////
        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;

            int min_r,min_g,min_b;
            Color k;
            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    min_r=min_g=min_b=255;
                    for(int i=0;i<3;i++)
                    {
                        for(int j=0;j<3;j++)
                        {
                            k = photo1.GetPixel(x + i - 1, y + j - 1);
                            if (k.R < min_r)
                                min_r = k.R;
                            if (k.G < min_g)
                                min_g = k.G;
                            if (k.B < min_b)
                                min_b = k.B;
                        }
                    }
                    photo2.SetPixel(x, y, Color.FromArgb(min_r, min_g, min_b));
                }
            }
            pictureBox2.Invalidate();
        }
        //max///////////////////////////////////////////////////////////////////////
        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;

            int max_r, max_g, max_b;
            Color k;
            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    max_r = max_g = max_b = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            k = photo1.GetPixel(x + i - 1, y + j - 1);
                            if (k.R > max_r)
                                max_r = k.R;
                            if (k.G > max_g)
                                max_g = k.G;
                            if (k.B > max_b)
                                max_b = k.B;
                        }
                    }

                    photo2.SetPixel(x, y, Color.FromArgb(max_r, max_g, max_b));
                }
            }
            pictureBox2.Invalidate();
        }
        //mediana
        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;

            // List<int> ls_r = new List<int>();
            //List<int> ls_g = new List<int>();
            //List<int> ls_b = new List<int>();
            int[] tab_r = new int[9];
            int[] tab_g = new int[9];
            int[] tab_b = new int[9];
            int miejsce = 0;

            Color k;
            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    miejsce = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            k = photo1.GetPixel(x + i - 1, y + j - 1);
                            tab_r[miejsce] = k.R;
                            tab_g[miejsce] = k.G;
                            tab_b[miejsce] = k.B;
                            miejsce++;
                        }
                    }
                    Array.Sort(tab_r);
                    Array.Sort(tab_g);
                    Array.Sort(tab_b);
                    photo2.SetPixel(x, y, Color.FromArgb(tab_r[4],tab_g[4],tab_b[4]));
                }
            }
            pictureBox2.Invalidate();
        }

        //wczytaj/////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }
    }
}
