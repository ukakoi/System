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
    public partial class Form2 : Form
    {
        //public Form2()
        //{
        //    InitializeComponent();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region Fields

        // Задаем диапазон значений для точек
        private const float MinX = -6;
        private const float MaxX = 6;
        private const float MinY = 0.1f;
        private const float MaxY = 10;
        // Количество точек для отрисовки
        private const int PointNumber = 200000;
        // Массив коэффциентов вероятностей
        private float[] _probability = new float[4]
        {
            0.01f,
            0.06f,
            0.08f,
            0.85f
        };

        // Матрица коэффициентов
        private float[,] _funcCoef = new float[4, 6]
        {
            //a      b       c      d      e  f
            {0, 0, 0, 0.16f, 0, 0}, // 1 функция
            {-0.15f, 0.28f, 0.26f, 0.24f, 0, 0.44f}, // 2 функция
            {0.2f, -0.26f, 0.23f, 0.22f, 0, 1.6f}, // 3 функция
            {0.85f, 0.04f, -0.04f, 0.85f, 0, 1.6f} // 4 функция
        };

        // коэффициент масштабируемости высоты и ширины
        // изображения фрактала для высоты и ширины нашей формы
        private int _width;
        private int _height;
        // Bitmap для папоротника
        private Bitmap _fern;
        // используем для отрисовки на PictureBox
        private Graphics _graph;

        #endregion

        #region Initialization

         public Form2()

        {
            InitializeComponent();

            // вычисляем коэффициент
            _width = (int)(FernPictureBox.Width / (MaxX - MinX));
            _height = (int)(FernPictureBox.Height / (MaxY - MinY));
            // создаем Bitmap для папоротника
            _fern = new Bitmap(FernPictureBox.Width, FernPictureBox.Height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _graph = Graphics.FromImage(_fern);
            // устанавливаем фон
            _graph.Clear(Color.Black);

            DrawFern();
        }

        #endregion

        #region Draw Method

        private void DrawFern()
        {
            Random rnd = new Random();
            // будем начинать рисовать с точки (0, 0)
            float xtemp = 0, ytemp = 0;
            // переменная хранения номера функции для вычисления следующей точки
            int func_num = 0;

            for (int i = 1; i <= PointNumber; i++)
            {
                // рандомное число от 0 до 1
                var num = rnd.NextDouble();
                // проверяем какой функцией воспользуемся для вычисления следующей точки
                for (int j = 0; j <= 3; j++)
                {
                    // если рандомное число оказалось меньше или равно
                    // заданного коэффициента вероятности,
                    // задаем номер функции
                    num = num - _probability[j];
                    if (num <= 0)
                    {
                        func_num = j;
                        break;
                    }
                }

                // вычисляем координаты
                var x = _funcCoef[func_num, 0] * xtemp + _funcCoef[func_num, 1] * ytemp + _funcCoef[func_num, 4];
                var y = _funcCoef[func_num, 2] * xtemp + _funcCoef[func_num, 3] * ytemp + _funcCoef[func_num, 5];

                // сохраняем значения для следующей итерации
                xtemp = x;
                ytemp = y;
                // вычисляем значение пикселя
                x = (int)(xtemp * _width + FernPictureBox.Width / 2);
                y = (int)(ytemp * _height);
                // устанавливаем пиксель в Bitmap
                _fern.SetPixel((int)x, (int)y, Color.LawnGreen);
            }
            // Отображаем результат
            FernPictureBox.BackgroundImage = _fern;
        }

        #endregion
    }
}
