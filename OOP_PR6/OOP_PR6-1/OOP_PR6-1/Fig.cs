using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace OOP_PR6_1
{//   g.Clear(Color.White);   g.FillRectangle(br, x, y, l, l);
    class Fig
    {
        public int x, y, l;
        public int typeFigura;//тип фигуры
        public Color myColor;
        public PictureBox pb;

        public Fig(int newX, int newY,
          int newl, Color newColor,
          PictureBox newpb, int newType)
        {
            x = newX;
            y = newY;
            l = newl;
            myColor = newColor;
            pb = newpb;
            typeFigura = newType;
        }

        public void Show()
        {
            Graphics s = Graphics.FromImage(pb.Image);

            Graphics g = Graphics.FromImage(pb.Image);
            SolidBrush br = new SolidBrush(myColor);
            SolidBrush br1 = new SolidBrush(Color.Yellow);
            SolidBrush br2 = new SolidBrush(Color.Blue);

            Pen pe = new Pen(Color.Black, 1);

            if (typeFigura == 1)
            {
//                g.FillPolygon(br2, new Point[] {
//new Point(x,y+l),
//new Point(x+l,y+l),
//new Point(x+l/2,y) });

//                g.DrawPolygon(pe, new Point[] {
//new Point(x,y+l),
//new Point(x+l,y+l),
//new Point(x+l/2,y) }); 
            }
            else if (typeFigura == 2)
            {
                //g.FillEllipse(br1, x+50, y+50, l+5, l+5);
                //g.DrawEllipse(pe, x + 50, y + 50, l + 5, l + 5);

            }
            else if (typeFigura == 3)
            {
                g.Clear(Color.White);
                Pen p = new Pen(Color.Black, 2);
                Pen p1 = new Pen(Color.Black, 1);

                SolidBrush l1 = new SolidBrush(Color.White);
                s.FillEllipse(l1, 145/3, 241 / 3, 40 / 3, 30 / 3);
                s.DrawEllipse(p, 145 / 3, 241 / 3, 40 / 3, 30 / 3);

                SolidBrush l2 = new SolidBrush(Color.White);
                s.FillEllipse(l2, 72 / 3, 241 / 3, 40 / 3, 30 / 3);
                s.DrawEllipse(p, 72 / 3, 241 / 3, 40 / 3, 30 / 3);

                SolidBrush com1 = new SolidBrush(Color.White);
                s.FillEllipse(com1, 80 / 3, 170 / 3, 100 / 3, 100 / 3);
                s.DrawEllipse(p, 80 / 3, 170 / 3, 100 / 3, 100 / 3);

                SolidBrush r1 = new SolidBrush(Color.White);
                s.FillEllipse(r1, 80 / 3, 117 / 3, 30 / 3, 30 / 3);
                s.DrawEllipse(p, 80 / 3, 117 / 3, 30 / 3, 30 / 3);

                SolidBrush r2 = new SolidBrush(Color.White);
                s.FillEllipse(r2, 150 / 3, 117 / 3, 30 / 3, 30 / 3);
                s.DrawEllipse(p, 150 / 3, 117 / 3, 30 / 3, 30 / 3);
                //met



                SolidBrush com2 = new SolidBrush(Color.White);
                s.FillEllipse(com2, 92 / 3, 95 / 3, 75 / 3, 75 / 3);
                s.DrawEllipse(p, 92 / 3, 95 / 3, 75 / 3, 75 / 3);

                SolidBrush com3 = new SolidBrush(Color.White);
                s.FillEllipse(com3, 107 / 3, 50 / 3, 45 / 3, 45 / 3);
                s.DrawEllipse(p, 107 / 3, 50 / 3, 45 / 3, 45 / 3);

                SolidBrush ug1 = new SolidBrush(Color.Black);
                s.FillEllipse(ug1, 120 / 3, 65 / 3, 10 / 3, 10 / 3);
                SolidBrush ug2 = new SolidBrush(Color.Black);
                s.FillEllipse(ug2, 135 / 3, 65 / 3, 10 / 3, 10 / 3);

                SolidBrush m = new SolidBrush(Color.Red);
                s.FillPolygon(m, new Point[] {
new Point(125/3,80/3),
new Point(135/3,80/3),
new Point(150/3,90/3) });

                s.DrawPolygon(p1, new Point[] {
new Point(125/3,80/3),
new Point(135/3,80/3),
new Point(150/3,90/3) });

                SolidBrush met = new SolidBrush(Color.Red);
                s.FillRectangle(met, 174 / 3, 73 / 3, 3 / 3, 200 / 3);
                s.DrawRectangle(p, 174 / 3, 73 / 3, 3 / 3, 200 / 3);



                SolidBrush pu1 = new SolidBrush(Color.Silver);
                s.FillEllipse(pu1, 125 / 3, 110 / 3, 9 / 3, 9 / 3);
                s.DrawEllipse(p1, 125 / 3, 110 / 3, 9 / 3, 9 / 3);

                SolidBrush pu2 = new SolidBrush(Color.Silver);
                s.FillEllipse(pu2, 125 / 3, 125 / 3, 9 / 3, 9 / 3);
                s.DrawEllipse(p1, 125 / 3, 125 / 3, 9 / 3, 9 / 3);

                SolidBrush pu3 = new SolidBrush(Color.Silver);
                s.FillEllipse(pu3, 125 / 3, 140 / 3, 9 / 3, 9 / 3);
                s.DrawEllipse(p1, 125 / 3, 140 / 3, 9 / 3, 9 / 3);

                SolidBrush pu4 = new SolidBrush(Color.Silver);
                s.FillEllipse(pu4, 125 / 3, 155 / 3, 9 / 3, 9 / 3);
                s.DrawEllipse(p1, 125 / 3, 155 / 3, 9 / 3, 9 / 3);

            }
            else if (typeFigura == 4)
            { 
                Pen p = new Pen(Color.Black, 1);
                SolidBrush b2 = new SolidBrush(Color.Green);

                SolidBrush b3 = new SolidBrush(Color.Brown);
                SolidBrush col1 = new SolidBrush(Color.Blue);
              g.FillEllipse(col1, 94/8, 209 / 8, 50 / 8, 50 / 8);
                g.DrawEllipse(p, 94 / 8, 209 / 8, 50 / 8, 50 / 8);
                SolidBrush col2 = new SolidBrush(Color.Blue);
                g.FillEllipse(col2, 294 / 8, 209 / 8, 50 / 8, 50 / 8);
                g.DrawEllipse(p, 294 / 8, 209 / 8, 50 / 8, 50 / 8);

              g.FillPolygon(b2, new Point[] {
new Point(210/8,207/8),
new Point(210/8,110/8),
new Point(410/8,110/8),
new Point(410/8,207/8) });

                g.DrawPolygon(p, new Point[] {
new Point(210/8,207/8),
new Point(210/8,110/8),
new Point(410/8,110/8),
new Point(410/8,207/8) });




                g.FillPolygon(b3, new Point[] {

new Point(25/8,207/8),
new Point(25/8,110/8),
new Point(100/8,110/8),
new Point(100/8,57/8),
new Point(200/8,57/8),
new Point(200/8,207/8) });

                g.DrawPolygon(p, new Point[] {

new Point(25/8,207/8),
new Point(25/8,110/8),
new Point(100/8,110/8),
new Point(100/8,57/8),
new Point(200/8,57/8),
new Point(200/8,207/8) });


     
            }
            else if (typeFigura == 5)
            {

                Pen p = new Pen(Color.Black, 1);
                SolidBrush a = new SolidBrush(Color.Gray);
                g.FillRectangle(a, 200/4, 100 / 4, 90 / 4, 180 / 4);
                g.DrawRectangle(p, 200 / 4, 100 / 4, 90 / 4, 180 / 4);
                SolidBrush b = new SolidBrush(Color.White);
                g.FillRectangle(b, 210 / 4, 195 / 4, 71 / 4, 90 / 4);
                g.DrawRectangle(p, 210 / 4, 195 / 4, 71 / 4, 90 / 4);

                SolidBrush c = new SolidBrush(Color.Gray);
                g.FillRectangle(c, 185 / 4, 270 / 4, 60 / 4, 20 / 4);
                g.DrawRectangle(p, 185 / 4, 270 / 4, 60 / 4, 20 / 4);

                SolidBrush d = new SolidBrush(Color.Gray);
              g.FillRectangle(d, 245 / 4, 270 / 4, 60 / 4, 20 / 4);
                g.DrawRectangle(p, 245 / 4, 270 / 4, 60 / 4, 20 / 4);

                SolidBrush k1 = new SolidBrush(Color.Gray);
             g.FillPolygon(k1, new Point[] {
new Point(200/4,250/4),
new Point(200/4,170/4),
new Point(180/4,210/4) });

              g.DrawPolygon(p, new Point[] {
new Point(200/4,250/4),
new Point(200/4,170/4),
new Point(180/4,210/4) });

                SolidBrush k2 = new SolidBrush(Color.Gray);
              g.FillPolygon(k2, new Point[] {
new Point(290/4,250/4),
new Point(290/4,170/4),
new Point(310/4,210/4) });

               g.DrawPolygon(p, new Point[] {
new Point(290/4,250/4),
new Point(290/4,170/4),
new Point(310/4,210/4) });

                SolidBrush n = new SolidBrush(Color.Red);
             g.FillPolygon(n, new Point[] {
new Point(240/4,150/4),
new Point(250/4,150/4),
new Point(260/4,180/4) });

             g.DrawPolygon(p, new Point[] {
new Point(240/4,150/4),
new Point(250/4,150/4),
new Point(260/4,180/4) });

                SolidBrush g1 = new SolidBrush(Color.White);
                g.FillEllipse(g1, 177 / 4, 110 / 4, 45 / 4, 45 / 4);
                g.DrawEllipse(p, 177 / 4, 110 / 4, 45 / 4, 45 / 4);

                SolidBrush g2 = new SolidBrush(Color.White);
                g.FillEllipse(g2, 266 / 4, 110 / 4, 45 / 4, 45 / 4);
                g.DrawEllipse(p, 266 / 4, 110 / 4, 45 / 4, 45 / 4);

                SolidBrush z1 = new SolidBrush(Color.Black);
                g.FillEllipse(z1, 200 / 4, 125 / 4, 15 / 4, 15 / 4);

                SolidBrush z2 = new SolidBrush(Color.Black);
                g.FillEllipse(z2, 274 / 4, 125 / 4, 15 / 4, 15 / 4);
            }
            pb.Refresh();


        }





    }
}
