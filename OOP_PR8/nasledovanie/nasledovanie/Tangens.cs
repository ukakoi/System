using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie
{
    public class Tangens : BaseClass
    {
       
        public Tangens( double newX) : base(newX)
        {
            //x = newX;
        
        }

        public override double Calc()
        {
            return Math.Sin(X) / Math.Cos(X);
        }

        public override string ToString()
        {
            return "Tg:X=" + X.ToString() ;
        }
    }

    


}
