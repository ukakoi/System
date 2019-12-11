using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PR6_2
{
    class TOpa
    {
        public string FIO;
        public string ULI;

        public int NumH;
          public int NumK;
 

        public override string ToString()
        {
            return FIO;
        }

        public TOpa(string myFIO, string myULI, int myNumH, int myNumK)
        {
            FIO = myFIO;
            ULI = myULI;
            NumH = myNumH;
            NumK = myNumK;
        }
        ~TOpa() { }
    }
}
