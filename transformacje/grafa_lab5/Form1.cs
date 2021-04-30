using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafa_lab5
{
    public partial class Form1 : Form
    {
        int szer = 0, wys = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //zmiana jasności///////////////////////////////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color p;
            int wartosc = (int)numericUpDown1.Value;
            int wspolczynnik = (int)numericUpDown2.Value;
            for (int x=0;x<szer;x++)
            {
                for(int y=0;y<wys;y++)
                {
                    p = photo1.GetPixel(x, y);
                    if ((wspolczynnik * p.R) + wartosc < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);    
                    }
                    else if((wspolczynnik * p.R) + wartosc > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb((wspolczynnik *p.R) + wartosc, p.G, p.B);

                        if ((wspolczynnik * p.G) + wartosc < 0)
                        {
                            p = Color.FromArgb(p.R, 0, p.B);
                        }
                        else if ((wspolczynnik * p.G) + wartosc > 255)
                        {
                            p = Color.FromArgb(p.R, 255, p.B);
                        }
                        else
                            p = Color.FromArgb(p.R, (wspolczynnik * p.G) + wartosc, p.B);

                    if ((wspolczynnik * p.B) + wartosc < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if ((wspolczynnik * p.B) + wartosc > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, (wspolczynnik * p.B) + wartosc);

                    photo2.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }

        ///zapisz///////////////////////////////////////////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }
        }

        //negatyw//////////////////////////////////////////////////////
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color p;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);

                    if ((-1) * p.R + 255 < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if ((-1) * p.R + 255 > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb((-1) * p.R + 255, p.G, p.B);

                            if ((-1) * p.G + 255 < 0)
                            {
                                p = Color.FromArgb(p.R, 0, p.B);
                            }
                            else if ((-1) * p.R + 255 > 255)
                            {
                                p = Color.FromArgb(p.R, 255, p.B);
                            }
                            else
                                p = Color.FromArgb(p.R, (-1) * p.G + 255, p.B);

                    if ((-1) * p.B + 255 < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if ((-1) * p.B + 255 > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, (-1) * p.B + 255);


                    photo2.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }

        //prznies z prawo na lewo do 1//////////////////////////////////////
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
            pictureBox1.Invalidate();
        }

        //potegowa zmiana jasnosci///////////////////////////////////////
        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color p;
            int wartosc = (int)numericUpDown1.Value;
            int wspolczynnik = (int)numericUpDown2.Value;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    if (wspolczynnik* (int)Math.Pow(p.R,wartosc) < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (wspolczynnik * (int)Math.Pow(p.R, wartosc) > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(wspolczynnik * (int)Math.Pow(p.R, wartosc), p.G, p.B);

                    if (wspolczynnik * ((int)Math.Pow(p.G, wartosc)) < 0)
                    {
                        p = Color.FromArgb(p.R, 0, p.B);
                    }
                    else if (wspolczynnik * (int)Math.Pow(p.G, wartosc) > 255)
                    {
                        p = Color.FromArgb(p.R, 255, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R, wspolczynnik * (int)Math.Pow(p.G, wartosc) + wartosc, p.B);

                    if (wspolczynnik * (int)Math.Pow(p.B, wartosc) < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (wspolczynnik * (int)Math.Pow(p.B, wartosc) > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, wspolczynnik * (int)Math.Pow(p.B, wartosc));

                    photo2.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //przypadkowa funkcja która nic nie robi ale żeby ja usunąć trzeba
        //znaleźć mikroskopijny panel który jest pod panelem 
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //wczytaj zdjecie 2////////////////////////////////////////
        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Load(openFileDialog1.FileName);
            }
        }

        //przenies z prawo na lewo 2//////////////////////////////////////////
        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = pictureBox2.Image;
            pictureBox3.Invalidate();
        }
        //suma///////////////////////////////////////////////////////
        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p,q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for(int x=0;x<szer;x++)
            {
                for(int y=0;y<wys;y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (p.R + q.R < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (p.R + q.R > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R + q.R, p.G, p.B);

                            if (p.G + q.G < 0)
                            {
                                p = Color.FromArgb(p.R, 0, p.B);
                            }
                            else if (p.G + q.G > 255)
                            {
                                p = Color.FromArgb(p.R, 255, p.B);
                            }
                            else
                                p = Color.FromArgb(p.R, p.G + q.G, p.B);

                    if (p.B + q.B < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (p.B + q.B > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, p.B+q.B);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //odejmowanie//////////////////////////////////////////////////////
        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (p.R + q.R -1 < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (p.R + q.R - 1 > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R + q.R - 1, p.G, p.B);

                    if (p.G + q.G - 1 < 0)
                    {
                        p = Color.FromArgb(p.R, 0, p.B);
                    }
                    else if (p.G + q.G - 1 > 255)
                    {
                        p = Color.FromArgb(p.R, 255, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G + q.G - 1, p.B);

                    if (p.B + q.B - 1 < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (p.B + q.B -1 > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, p.B + q.B - 1);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //roznica//////////////////////////////////////////////////////////
        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (Math.Abs(p.R-q.R)< 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (Math.Abs(p.R - q.R) > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(Math.Abs(p.R - q.R), p.G, p.B);

                    if (Math.Abs(p.G - q.G) < 0)
                    {
                        p = Color.FromArgb(p.R, 0, p.B);
                    }
                    else if (Math.Abs(p.G - q.G) > 255)
                    {
                        p = Color.FromArgb(p.R, 255, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R, Math.Abs(p.G - q.G), p.B);

                    if (Math.Abs(p.B - q.B) < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (Math.Abs(p.B - q.B) > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, Math.Abs(p.B - q.B));

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //mnozenie/////////////////////////////////////////////////////////
        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (p.R * q.R  < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (p.R * q.R > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R * q.R , p.G, p.B);

                    if (p.G * q.G < 0)
                    {
                        p = Color.FromArgb(p.R, 0, p.B);
                    }
                    else if (p.G * q.G > 255)
                    {
                        p = Color.FromArgb(p.R, 255, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G * q.G, p.B);

                    if (p.B * q.B < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (p.B * q.B > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, p.B * q.B);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //negacja//////////////////////////////////////////////////////////
        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (1-Math.Abs(1-p.R-q.R) < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (1 - Math.Abs(1 - p.R - q.R) > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(1 - Math.Abs(1 - p.R - q.R), p.G, p.B);

                            if (1 - Math.Abs(1 - p.G - q.G) < 0)
                            {
                                p = Color.FromArgb(p.R, 0, p.B);
                            }
                            else if (1 - Math.Abs(1 - p.G - q.G) > 255)
                            {
                                p = Color.FromArgb(p.R, 255, p.B);
                            }
                            else
                                p = Color.FromArgb(p.R, 1 - Math.Abs(1 - p.G - q.G), p.B);

                    if (1 - Math.Abs(1 - p.B - q.B) < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (1 - Math.Abs(1 - p.B - q.B) > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, 1 - Math.Abs(1 - p.B - q.B));

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //mnozenie_odwrotne///////////////////////////////////////////////
        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if ((1-(1-p.R)*(1-q.R)) < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if ((1 - (1 - p.R) * (1 - q.R)) > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb((1 - (1 - p.R) * (1 - q.R)), p.G, p.B);

                    if ((1 - (1 - p.G) * (1 - q.G)) < 0)
                    {
                        p = Color.FromArgb(p.R, 0, p.B);
                    }
                    else if ((1 - (1 - p.G) * (1 - q.G)) > 255)
                    {
                        p = Color.FromArgb(p.R, 255, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R, (1 - (1 - p.G) * (1 - q.G)), p.B);

                    if ((1 - (1 - p.B) * (1 - q.B)) < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if ((1 - (1 - p.B) * (1 - q.B)) > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, (1 - (1 - p.B) * (1 - q.B)));

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //darken/////////////////////////////////////////////////////////
        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (p.R > q.R)
                        p = Color.FromArgb(q.R,p.G,p.B);
                    if (p.G > q.G)
                        p = Color.FromArgb(p.R, q.G, p.B);
                    if (p.B > q.B)
                        p = Color.FromArgb(p.R, p.G, q.B);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //lighten/////////////////////////////////////////////////////
        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (p.R < q.R)
                        p = Color.FromArgb(q.R, p.G, p.B);
                    if (p.G < q.G)
                        p = Color.FromArgb(p.R, q.G, p.B);
                    if (p.B < q.B)
                        p = Color.FromArgb(p.R, p.G, q.B);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //wyłączenie////////////////////////////////////////////////////
        private void button17_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (p.R + q.R - 2*p.R*q.R < 0)
                    {
                        p = Color.FromArgb(0, p.G, p.B);
                    }
                    else if (p.R + q.R - 2 * p.R * q.R > 255)
                    {
                        p = Color.FromArgb(255, p.G, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R + q.R - 2 * p.R * q.R, p.G, p.B);

                    if (p.G + q.G - 2 * p.G * q.G < 0)
                    {
                        p = Color.FromArgb(p.R, 0, p.B);
                    }
                    else if (p.G + q.G - 2 * p.G * q.G > 255)
                    {
                        p = Color.FromArgb(p.R, 255, p.B);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G + q.G - 2 * p.G * q.G, p.B);

                    if (p.B + q.B - 2 * p.B * q.B < 0)
                    {
                        p = Color.FromArgb(p.R, p.G, 0);
                    }
                    else if (p.B + q.B - 2 * p.B * q.B > 255)
                    {
                        p = Color.FromArgb(p.R, p.G, 255);
                    }
                    else
                        p = Color.FromArgb(p.R, p.G, p.B + q.B - 2 * p.B * q.B);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //nakładka///////////////////////////////////////////////////////
        private void button18_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);

                    if(p.R<127)
                    {
                        if (2 * p.R * q.R < 0)
                            p = Color.FromArgb(0, p.G, p.B);
                        else if (2 * p.R * q.R > 255)
                            p = Color.FromArgb(255, p.G, p.B);
                        else
                            p = Color.FromArgb(2 * p.R * q.R, p.G, p.B);
                    }
                    else
                    {
                        if (1-2*(1-p.R)*(1-q.R) < 0)
                            p = Color.FromArgb(0, p.G, p.B);
                        else if (1 - 2 * (1 - p.R) * (1 - q.R) > 255)
                            p = Color.FromArgb(255, p.G, p.B);
                        else
                            p = Color.FromArgb(1 - 2 * (1 - p.R) * (1 - q.R), p.G, p.B);
                    }

                    if (p.G < 127)
                    {
                        if (2 * p.G * q.G < 0)
                            p = Color.FromArgb(p.R,0, p.B);
                        else if (2 * p.G * q.G > 255)
                            p = Color.FromArgb(p.R, 255, p.B);
                        else
                            p = Color.FromArgb(p.R, 2 * p.G * q.G, p.B);
                    }
                    else
                    {
                        if (1 - 2 * (1 - p.G) * (1 - q.G) < 0)
                            p = Color.FromArgb(p.R, 0, p.B);
                        else if (1 - 2 * (1 - p.G) * (1 - q.G) > 255)
                            p = Color.FromArgb(p.R, 255, p.B);
                        else
                            p = Color.FromArgb(p.R, 1 - 2 * (1 - p.G) * (1 - q.G), p.B);
                    }

                    if (p.B < 127)
                    {
                        if (2 * p.B * q.B < 0)
                            p = Color.FromArgb(p.R, p.G, 0);
                        else if (2 * p.B * q.B > 255)
                            p = Color.FromArgb(p.R, p.G, 255);
                        else
                            p = Color.FromArgb(p.R, p.G,2 * p.B * q.B);
                    }
                    else
                    {
                        if (1 - 2 * (1 - p.B) * (1 - q.B) < 0)
                            p = Color.FromArgb(p.R, p.G, 0);
                        else if (1 - 2 * (1 - p.B) * (1 - q.B) > 255)
                            p = Color.FromArgb(p.R, p.G, 255);
                        else
                            p = Color.FromArgb(p.R, p.G, 1 - 2 * (1 - p.B) * (1 - q.B));
                    }


                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //osre światło//////////////////////////////////////////////////
        private void button19_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);

                    if (q.R < 127)
                    {
                        if (2 * p.R * q.R < 0)
                            p = Color.FromArgb(0, p.G, p.B);
                        else if (2 * p.R * q.R > 255)
                            p = Color.FromArgb(255, p.G, p.B);
                        else
                            p = Color.FromArgb(2 * p.R * q.R, p.G, p.B);
                    }
                    else
                    {
                        if (1 - 2 * (1 - p.R) * (1 - q.R) < 0)
                            p = Color.FromArgb(0, p.G, p.B);
                        else if (1 - 2 * (1 - p.R) * (1 - q.R) > 255)
                            p = Color.FromArgb(255, p.G, p.B);
                        else
                            p = Color.FromArgb(1 - 2 * (1 - p.R) * (1 - q.R), p.G, p.B);
                    }

                    if (q.G < 127)
                    {
                        if (2 * p.G * q.G < 0)
                            p = Color.FromArgb(p.R, 0, p.B);
                        else if (2 * p.G * q.G > 255)
                            p = Color.FromArgb(p.R, 255, p.B);
                        else
                            p = Color.FromArgb(p.R, 2 * p.G * q.G, p.B);
                    }
                    else
                    {
                        if (1 - 2 * (1 - p.G) * (1 - q.G) < 0)
                            p = Color.FromArgb(p.R, 0, p.B);
                        else if (1 - 2 * (1 - p.G) * (1 - q.G) > 255)
                            p = Color.FromArgb(p.R, 255, p.B);
                        else
                            p = Color.FromArgb(p.R, 1 - 2 * (1 - p.G) * (1 - q.G), p.B);
                    }

                    if (q.B < 127)
                    {
                        if (2 * p.B * q.B < 0)
                            p = Color.FromArgb(p.R, p.G, 0);
                        else if (2 * p.B * q.B > 255)
                            p = Color.FromArgb(p.R, p.G, 255);
                        else
                            p = Color.FromArgb(p.R, p.G, 2 * p.B * q.B);
                    }
                    else
                    {
                        if (1 - 2 * (1 - p.B) * (1 - q.B) < 0)
                            p = Color.FromArgb(p.R, p.G, 0);
                        else if (1 - 2 * (1 - p.B) * (1 - q.B) > 255)
                            p = Color.FromArgb(p.R, p.G, 255);
                        else
                            p = Color.FromArgb(p.R, p.G, 1 - 2 * (1 - p.B) * (1 - q.B));
                    }


                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //łagodne światło///////////////////////////////////////////////////
        private void button20_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);

                    if (q.R < 127)
                    {
                        if (2 * p.R * q.R + Math.Pow(p.R,2)*(1-2*q.R)< 0)
                            p = Color.FromArgb(0, p.G, p.B);
                        else if (2 * p.R * q.R + Math.Pow(p.R, 2) * (1 - 2 * q.R) > 255)
                            p = Color.FromArgb(255, p.G, p.B);
                        else
                            p = Color.FromArgb( 2 * p.R * q.R + (int)Math.Pow(p.R, 2) * (1 - 2 * q.R), p.G, p.B);
                    }
                    else
                    {
                        if (Math.Sqrt(p.R)*(2*q.R-1)+(2*p.R)*(1-q.R) < 0)
                            p = Color.FromArgb(0, p.G, p.B);
                        else if (Math.Sqrt(p.R) * (2 * q.R - 1) + (2 * p.R) * (1 - q.R) > 255)
                            p = Color.FromArgb(255, p.G, p.B);
                        else
                            p = Color.FromArgb((int)Math.Sqrt(p.R) * (2 * q.R - 1) + (2 * p.R) * (1 - q.R), p.G, p.B);
                    }

                                if (q.G < 127)
                                {
                                    if (2 * p.G * q.G + Math.Pow(p.G, 2) * (1 - 2 * q.G) < 0)
                                        p = Color.FromArgb(p.R, 0, p.B);
                                    else if (2 * p.G * q.G + Math.Pow(p.G, 2) * (1 - 2 * q.G) > 255)
                                        p = Color.FromArgb(0, 255, p.B);
                                    else
                                        p = Color.FromArgb(p.R, 2 * p.G * q.G + (int)Math.Pow(p.G, 2) * (1 - 2 * q.G), p.B);
                                }
                                else
                                {
                                    if (Math.Sqrt(p.G) * (2 * q.G - 1) + (2 * p.G) * (1 - q.G) < 0)
                                        p = Color.FromArgb(p.R, 0, p.B);
                                    else if (Math.Sqrt(p.G) * (2 * q.G - 1) + (2 * p.G) * (1 - q.G) > 255)
                                        p = Color.FromArgb(p.R, 255, p.B);
                                    else
                                        p = Color.FromArgb(p.R, (int)Math.Sqrt(p.G) * (2 * q.G - 1) + (2 * p.G) * (1 - q.G), p.B);
                                }


                    if (q.B < 127)
                    {
                        if (2 * p.B * q.B + Math.Pow(p.B, 2) * (1 - 2 * q.B) < 0)
                            p = Color.FromArgb(p.R, p.G, 0);
                        else if (2 * p.B * q.B + Math.Pow(p.B, 2) * (1 - 2 * q.B) > 255)
                            p = Color.FromArgb(0, p.G, 255);
                        else
                            p = Color.FromArgb(p.R, p.G, 2 * p.B * q.B + (int)Math.Pow(p.B, 2) * (1 - 2 * q.B));
                    }
                    else
                    {
                        if (Math.Sqrt(p.B) * (2 * q.B - 1) + (2 * p.B) * (1 - q.B) < 0)
                            p = Color.FromArgb(p.R, p.G, 0);
                        else if (Math.Sqrt(p.B) * (2 * q.B - 1) + (2 * p.B) * (1 - q.B) > 255)
                            p = Color.FromArgb(p.R, p.G, 255);
                        else
                            p = Color.FromArgb(p.R, p.G, (int)Math.Sqrt(p.B) * (2 * q.B - 1) + (2 * p.B) * (1 - q.B));
                    }


                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //rozcieńczenie/////////////////////////////////////////////////////
        private void button21_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if(1-q.R != 0)
                    {
                        if (p.R/(1-q.R) < 0)
                        {
                            p = Color.FromArgb(0, p.G, p.B);
                        }
                        else if (p.R / (1 - q.R) > 255)
                        {
                            p = Color.FromArgb(255, p.G, p.B);
                        }
                        else
                            p = Color.FromArgb(p.R / (1 - q.R), p.G, p.B);
                    }

                    if (1 - q.G != 0)
                    {
                        if (p.G / (1 - q.G) < 0)
                        {
                            p = Color.FromArgb(p.R, 0, p.B);
                        }
                        else if (p.G / (1 - q.G) > 255)
                        {
                            p = Color.FromArgb(p.R, 255, p.B);
                        }
                        else
                            p = Color.FromArgb(p.R, p.G / (1 - q.G), p.B);
                    }
                    if (1 - q.B != 0)
                    {
                        if (p.B / (1 - q.B) < 0)
                        {
                            p = Color.FromArgb(p.R, p.G, 0);
                        }
                        else if (p.B / (1 - q.B) > 255)
                        {
                            p = Color.FromArgb(p.R, p.G, 255);
                        }
                        else
                            p = Color.FromArgb(p.R, p.G, p.B / (1 - q.B));
                    }
                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //wypalenie/////////////////////////////////////////////////////////
        private void button22_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (q.R != 0)
                    {
                        if (1-(1 - q.R)/q.R < 0)
                        {
                            p = Color.FromArgb(0, p.G, p.B);
                        }
                        else if (1 - (1 - q.R) / q.R > 255)
                        {
                            p = Color.FromArgb(255, p.G, p.B);
                        }
                        else
                            p = Color.FromArgb(1 - (1 - q.R) / q.R, p.G, p.B);
                    }

                    if (q.G != 0)
                    {
                        if (1 - (1 - q.G) / q.G < 0)
                        {
                            p = Color.FromArgb(p.R, 0, p.B);
                        }
                        else if (1 - (1 - q.G) / q.G > 255)
                        {
                            p = Color.FromArgb(p.R, 255, p.B);
                        }
                        else
                            p = Color.FromArgb(p.R, 1 - (1 - q.G) / q.G, p.B);
                    }
                    if (q.B != 0)
                    {
                        if (1 - (1 - q.B) / q.B < 0)
                        {
                            p = Color.FromArgb(p.R, p.G, 0);
                        }
                        else if (1 - (1 - q.B) / q.B > 255)
                        {
                            p = Color.FromArgb(p.R, p.G, 255);
                        }
                        else
                            p = Color.FromArgb(p.R, p.G, 1 - (1 - q.B) / q.B);
                    }
                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //reflect_mode//////////////////////////////////////////////////////
        private void button23_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    if (1 - q.R != 0)
                    {
                        if (Math.Pow(p.R,2)/(1-q.R) < 0)
                        {
                            p = Color.FromArgb(0, p.G, p.B);
                        }
                        else if (Math.Pow(p.R, 2) / (1 - q.R) > 255)
                        {
                            p = Color.FromArgb(255, p.G, p.B);
                        }
                        else
                            p = Color.FromArgb((int)Math.Pow(p.R, 2) / (1 - q.R), p.G, p.B);
                    }

                    if (1 - q.G != 0)
                    {
                        if (Math.Pow(p.G, 2) / (1 - q.G) < 0)
                        {
                            p = Color.FromArgb(p.R, 0, p.B);
                        }
                        else if (Math.Pow(p.G, 2) / (1 - q.G) > 255)
                        {
                            p = Color.FromArgb(p.R, 255, p.B);
                        }
                        else
                            p = Color.FromArgb(p.R, (int)Math.Pow(p.G, 2) / (1 - q.G), p.B);
                    }


                    if (1 - q.B != 0)
                    {
                        if (Math.Pow(p.B, 2) / (1 - q.B) < 0)
                        {
                            p = Color.FromArgb(p.R, p.G, 0);
                        }
                        else if (Math.Pow(p.B, 2) / (1 - q.B) > 255)
                        {
                            p = Color.FromArgb(p.R, p.G, 255);
                        }
                        else
                            p = Color.FromArgb(p.R, p.G, (int)Math.Pow(p.B, 2) / (1 - q.B));
                    }


                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }
        //przezroczystość////////////////////////////////////////////////
        private void button24_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox3.Image;
            Bitmap photo3 = (Bitmap)pictureBox2.Image;
            Color p, q;
            int alfa;

            if (photo1.Width <= photo2.Width)
                szer = photo1.Width;
            else
                szer = photo2.Width;

            if (photo1.Height <= photo2.Height)
                wys = photo1.Height;
            else
                wys = photo2.Height;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    p = photo1.GetPixel(x, y);
                    q = photo2.GetPixel(x, y);
                    alfa = (int)numericUpDown3.Value;
                        p = Color.FromArgb((1 - alfa) * q.R + alfa * p.R, (1 - alfa) * q.G + alfa * p.G, (1 - alfa) * q.B + alfa * p.B);

                    photo3.SetPixel(x, y, p);
                }
            }
            pictureBox2.Invalidate();
        }

        //wczytywanie zdjecia 1/////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }
    }
}
