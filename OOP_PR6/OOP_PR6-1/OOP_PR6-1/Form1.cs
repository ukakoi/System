using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
namespace OOP_PR6_1
{
    public partial class Form1 : Form
    {

       
        public Graphics tg; //Графика
        public Bitmap tmap; //Битмап
        public Pen tp; //Ручка
        public int iter = 6; //Количество итераций
        //------
        Pen pe;
        SolidBrush fon;
        Graphics gr;

        int i = 15;
        //--------
        Pen pent;
        SolidBrush fo;
        Graphics gra;

        double pi = 3.14;
        //------
        private void H(int x, int y, int razmer)//функция отрисовки одной Н
        {
            //Выбираем перо "myPen" черного цвета Black
            //толщиной в 1 пиксель:
            Pen myPen = new Pen(Color.Black, 1);
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.DrawLine(myPen, x - razmer, y - razmer, x - razmer, y + razmer);
            g.DrawLine(myPen, x - razmer, y, x + razmer, y);
            g.DrawLine(myPen, x + razmer, y - razmer, x + razmer, y + razmer);
        }

        private void H_fractal(int x1, int y1, int razm_f, int minimum)
        {
            //вершины фигуры Н
            int x11; int y11;
            int x01; int y01;
            int x00; int y00;
            int x10; int y10;
            x11 = x1 + razm_f;
            y11 = y1 + razm_f;
            x01 = x1 - razm_f;
            y01 = y1 + razm_f;
            x10 = x1 + razm_f;
            y10 = y1 - razm_f;
            x00 = x1 - razm_f;
            y00 = y1 - razm_f;


            H(x1, y1, razm_f);//рисуем одну фигуру Н
            razm_f = razm_f / 2;//уменьшаем размер в 2 раза
                                // если размер не меньше минимального, то рисуем в 4-х вершинах
            if (razm_f >= minimum)
            {
                H_fractal(x11, y11, razm_f, minimum);
                H_fractal(x01, y01, razm_f, minimum);
                H_fractal(x10, y10, razm_f, minimum);
                H_fractal(x00, y00, razm_f, minimum);
            }
        }

        private int height_;
        private int width_;


        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image =
                   new Bitmap(pictureBox1.Width,
                   pictureBox1.Height);
            //--
            pe = new Pen(Color.Lime, 2);
            fon = new SolidBrush(Color.Black);
            gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //--
            height_ = pictureBox1.Height; //высота элемента pictureBox1
            width_ = pictureBox1.Width; // ширина 
        }
        //00000000000
        void Draw_Pentagon(double x, double y, double r, double angle)
        {
            pent = new Pen(Color.Red, 2);
            gra = pictureBox1.CreateGraphics();
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int i;
            double[] x1 = new double[5];
            double[] y1 = new double[5];

            for (i = 0; i < 5; i++)
            {
                x1[i] = r * Math.Cos(angle + i * pi * 2 / 5);
                y1[i] = r * Math.Sin(angle + i * pi * 2 / 5);
            }

            for (i = 0; i < 4; i++)
            {
                gra.DrawLine(pent, (int)Math.Round(x + x1[i]), (int)Math.Round(y + y1[i]), (int)Math.Round(x + x1[i + 1]), (int)Math.Round(y + y1[i + 1]));
            }
        }

        void Draw_Star(double x, double y, double r, double angle, int d)
        {
            int i;
            double h;

            h = 2 * r * Math.Cos(pi / 5);

            for (i = 0; i < 5; i++)
            {
                Draw_Pentagon(x - h * Math.Cos(angle + i * pi * 2 / 5), y - h * Math.Sin(angle + i * pi * 2 / 5), r, angle + pi + i * pi * 2 / 5);

                if (d > 0)
                    Draw_Star(x - h * Math.Cos(angle + i * pi * 2 / 5), y - h * Math.Sin(angle + i * pi * 2 / 5), r / (2 * Math.Cos(pi / 5) + 1), angle + pi + (2 * i + 1) * pi * 2 / 10, d - 1);
            }
            Draw_Pentagon(x, y, r, angle);

            if (d > 0)
                Draw_Star(x, y, r / (2 * Math.Cos(pi / 5) + 1), angle + pi, d - 1);
        }
        //0000000000000000000

        //..
        Graphics g;
        Pen pen = new Pen(Color.Black);

        void Draw(double x, double y, double l, double u, int t, int q)
        {
            // начало построения ломанных
            if (t > 0)
            {
                if (q == 1)
                {
                    //формулы построения
                    x += l * Math.Cos(u);
                    y -= l * Math.Sin(u);
                    u += Math.PI;
                }
                u -= 2 * Math.PI / 19;//соединение линий
                l /= Math.Sqrt(7); //масштаб
                //функции рисования
                Paint(ref x, ref y, l, u, t - 1, 0);
                Paint(ref x, ref y, l, u + Math.PI / 3, t - 1, 1);
                Paint(ref x, ref y, l, u + Math.PI, t - 1, 1);
                Paint(ref x, ref y, l, u + 2 * Math.PI / 3, t - 1, 0);
                Paint(ref x, ref y, l, u, t - 1, 0);
                Paint(ref x, ref y, l, u, t - 1, 0);
                Paint(ref x, ref y, l, u - Math.PI / 3, t - 1, 1);
            }
            else g.DrawLine(pen, (float)Math.Round(x), (float)Math.Round(y), (float)Math.Round(x + Math.Cos(u) * l), (float)Math.Round(y - Math.Sin(u) * l));
        }

        void Paint(ref double x, ref double y, double l, double u, int t, int q)
        {
            Draw(x, y, l, u, t, q);
            x += l * Math.Cos(u);
            y -= l * Math.Sin(u);
        }
        //...
        //====
        void Draw_Levy(Graphics gr, Pen p, SolidBrush fon, int x1, int x2, int y1, int y2, int i)
        {
            if (i == 0)
            {
                gr.DrawLine(p, x1, y1, x2, y2);
            }
            else
            {
                int x3 = (x1 + x2) / 2 + (y2 - y1) / 2;
                int y3 = (y1 + y2) / 2 - (x2 - x1) / 2;

                Draw_Levy(gr, p, fon, x1, x3, y1, y3, i - 1);
                Draw_Levy(gr, p, fon, x3, x2, y3, y2, i - 1);
            }
        }
        //===

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
           
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int l = Convert.ToInt32(textBox3.Text);

            Color cl = pictureBox2.BackColor;
 
            int type;
            if (radioButton1.Checked)
            {
                type = 1;
            }
            else if (radioButton2.Checked)
            {
                type = 2;
            }
            else if (radioButton3.Checked)
            {
                type = 3;
               
            }
            else if (radioButton4.Checked)
            {
                type = 4;
            }
            else
            {
                type = 5;
            }
            Fig figura = new Fig(x, y,  l,
                 cl, pictureBox1, type);

            figura.Show();

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;

            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;

            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);

            Draw_Levy(gr, pe, fon, 250 / 7, 400 / 7, 160 / 7, 160 / 7, i); // Строим кривую Леви
            Draw_Levy(gr, pe, fon, 400 / 7, 400 / 7, 160 / 7, 310 / 7, i); // на каждой
            Draw_Levy(gr, pe, fon, 400 / 7, 250 / 7, 310 / 7, 310 / 7, i); // стороне 
            Draw_Levy(gr, pe, fon, 250 / 7, 250 / 7, 310 / 7, 160 / 7, i); // квадрата
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g = Graphics.FromHwnd(pictureBox1.Handle);
            Draw(150, 150, 300 / 5, 0, 3, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;

            fo = new SolidBrush(Color.Black);
            gra = pictureBox1.CreateGraphics();
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            gra.FillRectangle(fo, 0, 0, pictureBox1.Width, pictureBox1.Height);

            Draw_Star(300 / 3, 250 / 3, 85 / 3, pi / 2, 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            tmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
            tg = Graphics.FromImage(tmap); //Подключаем графику
            tg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Включаем сглаживание
            tp = new Pen(Color.Green);  //Зеленая ручка
            tg.Clear(Color.Black);      //Черный фон

            //Присваеваем размеры picturebox в отдельные переменные, для простоты обращения
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;

            //Выберем начальные точки
            PointF A = new PointF(w * 3 / 4, h * 3 / 4);
            PointF B = new PointF(w / 4, h * 3 / 4);
            PointF C = new PointF(w / 2, h / 4);


            //Рисуем изначальный треугольник
            tg.DrawLine(tp, A.X, A.Y, B.X, B.Y);
            tg.DrawLine(tp, B.X, B.Y, C.X, C.Y);
            tg.DrawLine(tp, A.X, A.Y, C.X, C.Y);


            //Вызываем рекурсивную функцию отрисовки фрактала
            drawMCTriangle(A, B, C, iter);

            //Переносим изображение из битмапа на picturebox
            pictureBox1.BackgroundImage = tmap;

        }
        public int drawMCTriangle(PointF A, PointF B, PointF C, int iter)
        {
            //Параметры: точки А В С начального треугольника и кол-во итераций iter

            //База рекурсии
            if (iter == 0) //если итераций 0 - то выход
                return 0;

            PointF D = new PointF();    //Точка центра масс
            PointF v1 = new PointF();   //Вектор AB
            PointF v2 = new PointF();   //Вектор AC

            //Вектор АB
            v1.X = B.X - A.X;
            v1.Y = B.Y - A.Y;

            //Вектор AC
            v2.X = C.X - A.X;
            v2.Y = C.Y - A.Y;

            D.X = A.X + (v1.X + v2.X) / 3;     //К точке А прибавим сумму векторов AВ и AC, деленную на 3
            D.Y = A.Y + (v1.Y + v2.Y) / 3;     //и получим координаты центра масс

            tg.DrawLine(tp, A.X, A.Y, D.X, D.Y);    //Рисуем отрезки от вершин к центру масс
            tg.DrawLine(tp, B.X, B.Y, D.X, D.Y);
            tg.DrawLine(tp, C.X, C.Y, D.X, D.Y);

            drawMCTriangle(A, B, D, iter - 1);    //Вызываем рекурсивно процендуру для полученных 
            drawMCTriangle(B, C, D, iter - 1);    //треугольников, с итерацией, меньшей на 1
            drawMCTriangle(A, C, D, iter - 1);

            return 0;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            H_fractal(width_ / 2, height_ / 2, 128, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
Form2 f = new Form2(); f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
Form3 f = new Form3();f.Show();  
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(); f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
Form5 f = new Form5(); f.Show();
        }
    }
    }
// 
        

