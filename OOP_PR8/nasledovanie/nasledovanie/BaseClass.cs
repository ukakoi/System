using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie
{
    abstract public class BaseClass
        {
            public double X;
            public BaseClass(double newX)
            {
                X = newX;
            }

            abstract public double Calc();
    }
}
