using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp19
{
    class TFigura
    {
        public int x, y, dx, dy, l;
        public int typeFigura;//тип фигуры
        public Color myColor;
        public PictureBox pb;
        public int napr;

        public TFigura(int newX, int newY,
           int newdx, int newdy,
           int newl, Color newColor,
           PictureBox newpb, int newType, int newNapr)
        {
            x = newX;
            y = newY;
            dx = newdx;
            dy = newdy;
            l = newl;
            myColor = newColor;
            pb = newpb;
            typeFigura = newType;
            napr = newNapr;
        }

        public void Show()
        {
            Graphics g = Graphics.FromImage(pb.Image);
            SolidBrush br = new SolidBrush(myColor);
            if (typeFigura == 1)
            {
                g.FillRectangle(br, x, y, l, l);
            }
            else if (typeFigura == 2)
            {
                g.FillEllipse(br, x, y, l, l);

            }
            else if (typeFigura == 3)
            {
                g.FillPolygon(br,   new Point[] {
new Point(x,y+l),
new Point(x+l,y+l),
new Point(x+l/2,y) })   ;

            }

            pb.Refresh();

           
        }
        //переопределение метода TOSTRING
        public override string ToString()
        {
            return x.ToString() + " " + y.ToString()
                + myColor.ToString();
        }

        public void Move()
        {
            if (napr == 1)
            {
                int dx2 = x + dx;
                if (dx2 < 0 || dx2 > (pb.Width - l))
                {
                    dx = -dx;
                }
                x = x + dx;
            }
            else if (napr == 2)
            {
                int dy2 = y + dy;
                if (dy2 < 0 || dy2 > (pb.Width - l))
                {
                    dy = -dy;
                }
                y = y + dy;

            }
        }
        public void Stir()
        {
            SolidBrush s = new SolidBrush(pb.BackColor);
            Graphics g = Graphics.FromImage(pb.Image);
            SolidBrush br = new SolidBrush(myColor);
            if (typeFigura == 1)
            {
                g.FillRectangle(s, x, y, l, l);
            }

            else if (typeFigura == 2)
            {
                g.FillEllipse(s, x, y, l, l);
            }

            else if (typeFigura == 3)
            {
                g.FillRectangle(s, x, y, l, l);
            }
            pb.Refresh();//обновление области рисования
        }
    }
}
