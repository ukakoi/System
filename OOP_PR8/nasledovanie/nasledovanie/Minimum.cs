using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie
{
    public class Minimum : BaseClass
    {
        public double n, o;


        public Minimum(double newN, double newO, double newX) : base(newX)
        {
            n = newN;
            o = newO;
        }

        public override double Calc()
        {
          double bu =  Math.Min(X, n);
          //////////////////////////
            return Math.Min(bu, o);
        }

        public override string ToString()
        {
            return "Min:"+"X=" + X.ToString()
                + ",N=" + n.ToString() + ",O=" + o.ToString();
        }
    }
    
}
