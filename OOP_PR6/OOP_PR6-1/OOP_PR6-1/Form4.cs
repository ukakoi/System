using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_PR6_1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        struct Complex
        {

            public double x;
            public double y;

        };

        public void draw_fractal(int Width, int Height, Pen drw_pen, Graphics g)
        {
            int iterations = 50, max = 3;
            int xc, yc;
            int x, y, n;
            double p, q;
            Complex z, c;
            xc = (Width - 10) / 2;
            yc = (Height - 10) / 2;

            for (y = -yc; y < yc; y++)
            {
                for (x = -xc; x < xc; x++)
                {
                    n = 0;
                    c.x = x * 0.01 + 1;
                    c.y = y * 0.01;

                    z.x = 0.5;
                    z.y = 0;

                    while ((z.x * z.x + z.y * z.y < max) && (n < iterations))
                    {
                        p = z.x - z.x * z.x + z.y * z.y;
                        q = z.y - 2 * z.x * z.y;
                        z.x = c.x * p - c.y * q;
                        z.y = c.x * q + c.y * p;
                        n++;
                    }
                    if (n < iterations)
                    {
                        drw_pen.Color = Color.FromArgb(255, 0, (n * 15) % 255, (n * 20) % 255);
                        g.DrawRectangle(drw_pen, xc + x, yc + y, 1, 1);
                    }

                }
            }
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
int Width = 1027, Height = 510;

            Pen drw_pen = new Pen(Color.Black, 1);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            draw_fractal(Width, Height, drw_pen, g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
