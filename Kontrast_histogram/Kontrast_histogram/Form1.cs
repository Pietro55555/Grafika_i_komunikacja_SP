using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrast_histogram
{
    public partial class Form1 : Form
    {
        private int szer = 0, wys = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //zapisz zdjęcie/////////////////////////////////////////////////////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image.Save(saveFileDialog1.FileName);
            }
        }
        //zmniejszanie kontrastu/////////////////////////////////////////////////////////
        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color k;
            int c = (int)numericUpDown2.Value, r_prym, g_prym, b_prym;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = photo1.GetPixel(x, y);
                    r_prym = (int)(((float)(127 + c) / 127) * (float)(k.R - c));
                    g_prym = (int)(((float)(127 + c) / 127) * (float)(k.G - c));
                    b_prym = (int)(((float)(127 + c) / 127) * (float)(k.B - c));
                    if (r_prym >= 0 && r_prym <= 255)
                        k = Color.FromArgb(r_prym, k.G, k.B);
                    if (g_prym >= 0 && g_prym <= 255)
                        k = Color.FromArgb(k.R, g_prym, k.B);
                    if (b_prym >= 0 && b_prym <= 255)
                        k = Color.FromArgb(k.R, k.G, b_prym);
                    photo2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Invalidate();
            histogram();
        }
        //zwiększanie kontrastu///////////////////////////////////////////////////////////////
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color k;
            int c = (int)numericUpDown1.Value,r_prym,g_prym,b_prym;

            for(int x=0;x<szer;x++)
            {
                for(int y=0;y<wys;y++)
                {
                    k = photo1.GetPixel(x, y);
                    r_prym = (int)((float)(127 / (127 - c)) * (float)(k.R - c));
                    g_prym = (int)((float)(127 / (127 - c)) * (float)(k.G - c));
                    b_prym = (int)((float)(127 / (127 - c)) * (float)(k.B - c));
                    if (r_prym >= 0 && r_prym <= 255)
                        k = Color.FromArgb(r_prym, k.G, k.B);
                    if (g_prym >= 0 && g_prym <= 255)
                        k = Color.FromArgb(k.R, g_prym, k.B);
                    if (b_prym >= 0 && b_prym <= 255)
                        k = Color.FromArgb(k.R, k.G, b_prym);
                    photo2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Invalidate();
            histogram();
        }
        //zwiększanie kontrastu oddzielnie//////////////////////////////////////////////////////
        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color k;
            int c = (int)numericUpDown4.Value;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = photo1.GetPixel(x, y);
                    int r_prym = k.R, g_prym = k.G, b_prym = k.B;

                    if (k.R < 127)
                        r_prym = (int)(((float)(127 - c) / 127) * (float)k.R);
                    else if (k.R >= 127)
                        r_prym = (int)(((float)(127 - c) / 127) * (float)k.R + (float)(2 * c));

                    if (k.G < 127)
                        g_prym = (int)(((float)(127 - c) / 127) * (float)k.G);
                    else if (k.G >= 127)
                        g_prym = (int)(((float)(127 - c) / 127) * (float)k.G + (float)(2 * c));

                    if (k.B < 127)
                        b_prym = (int)(((float)(127 - c) / 127) * (float)k.B);
                    else if (k.B >= 127)
                        b_prym = (int)(((float)(127 - c) / 127) * (float)k.B + (float)(2 * c));


                    if (r_prym >= 0 && r_prym <= 255)
                        k = Color.FromArgb(r_prym, k.G, k.B);
                    if (g_prym >= 0 && g_prym <= 255)
                        k = Color.FromArgb(k.R, g_prym, k.B);
                    if (b_prym >= 0 && b_prym <= 255)
                        k = Color.FromArgb(k.R, k.G, b_prym);
                    photo2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Invalidate();
            histogram();
        }
        //zmniejszanie kontrastu oddzielnie////////////////////////////////////////////////////////
        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap photo1 = (Bitmap)pictureBox1.Image;
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            Color k;
            int c = (int)numericUpDown3.Value;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = photo1.GetPixel(x, y);
                    int r_prym = k.R, g_prym = k.G, b_prym = k.B;

                    if (k.R < 127 + c)
                        r_prym = (int)(((float)127 / (float)(127 + c)) * (float)k.R);
                    else if (k.R > 127 - c)
                        r_prym = (int)((float)(127 * k.R + 255 * c) / (float)(127 + c));
                    else
                        r_prym = 127;

                    if (k.G < 127 + c)
                        g_prym = (int)(((float)127 / (float)(127 + c)) * (float)k.G);
                    else if (k.G > 127 - c)
                        g_prym = (int)((float)(127 * k.G + 255 * c) / (float)(127 + c));
                    else
                        g_prym = 127;

                    if (k.B < 127 + c)
                        b_prym = (int)(((float)127 / (float)(127 + c)) * (float)k.B);
                    else if (k.B > 127 - c)
                        b_prym = (int)((float)(127 * k.B + 255 * c) / (float)(127 + c));
                    else
                        b_prym = 127;


                    if (r_prym >= 0 && r_prym <= 255)
                        k = Color.FromArgb(r_prym, k.G, k.B);
                    if (g_prym >= 0 && g_prym <= 255)
                        k = Color.FromArgb(k.R, g_prym, k.B);
                    if (b_prym >= 0 && b_prym <= 255)
                        k = Color.FromArgb(k.R, k.G, b_prym);
                    photo2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Invalidate();
            histogram();
        }
        //funkcja do rysowania histogramu
        private void histogram()
        {
            Bitmap photo2 = (Bitmap)pictureBox2.Image;
            int[] r_his = new int[256];
            int[] g_his = new int[256];
            int[] b_his = new int[256];
            float maxr = 0, maxg = 0, maxb = 0;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    int redValue = photo2.GetPixel(x, y).R;//r
                    r_his[redValue]++;
                    if (maxr < r_his[redValue])
                        maxr = r_his[redValue];
                }
            }


            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    int greenValue = photo2.GetPixel(x, y).G;
                    g_his[greenValue]++;
                    if (maxg < g_his[greenValue])
                        maxg = g_his[greenValue];
                }
            }


            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    int blueValue = photo2.GetPixel(x, y).B;
                    b_his[blueValue]++;
                    if (maxb < b_his[blueValue])
                        maxb = b_his[blueValue];
                }
            }

            int hist_wys = 127;
            Bitmap histogram_r = new Bitmap(256, hist_wys);
            Bitmap histogram_g = new Bitmap(256, hist_wys);
            Bitmap histogram_b = new Bitmap(256, hist_wys);
            Graphics gr = Graphics.FromImage(histogram_r);
            Graphics gg = Graphics.FromImage(histogram_g);
            Graphics gb = Graphics.FromImage(histogram_b);

            for (int i = 0; i < r_his.Length; i++)
                {
                    float pkt = r_his[i] / maxr;
                    gr.DrawLine(Pens.Red,new Point(i, histogram_r.Height - 5),new Point(i, histogram_r.Height - 5 - (int)(pkt * hist_wys)));
                }
            {
                for (int i = 0; i < g_his.Length; i++)
                {
                    float pkt = g_his[i] / maxg;
                    gg.DrawLine(Pens.Green, new Point(i, histogram_g.Height - 5), new Point(i, histogram_g.Height - 5 - (int)(pkt * hist_wys)));
                }
            }
            {
                for (int i = 0; i < b_his.Length; i++)
                {
                    float pkt = b_his[i] / maxb;
                    gb.DrawLine(Pens.Blue, new Point(i, histogram_b.Height - 5), new Point(i, histogram_b.Height - 5 - (int)(pkt * hist_wys)));
                }
            }
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            pictureBox3.Image = histogram_r;
            pictureBox4.Image = histogram_g;
            pictureBox5.Image = histogram_b;
            pictureBox3.Invalidate();
            pictureBox4.Invalidate();
            pictureBox5.Invalidate();
        }
        //zapisz r///////////////////////////////////////////////////////////////
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image.Save(saveFileDialog1.FileName);
            }
        }
        //zapisz g///////////////////////////////////////////////////////////////////
        private void button8_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image.Save(saveFileDialog1.FileName);
            }
        }
        //zapisz b///////////////////////////////////////////////////////////////////
        private void button9_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image.Save(saveFileDialog1.FileName);
            }
        }
        //przenies z prawo na lewo///////////////////////////////////////////////
        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
            pictureBox1.Invalidate();
        }

        //wczytaj zdjęcie///////////////////////////////////////////////////////////////////////
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
