using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie
{
    public class Stepen : BaseClass
    {
        public double  n;


        public Stepen( double newN, double newX) : base(newX)
        {
           
            n = newN;
        }

        public override double Calc()
        {
            return Math.Pow(X, n);
        }

        public override string ToString()
        {
            return "Pow:"+"X=" + X.ToString()
                + ",N=" + n.ToString();
        }
    }
}
