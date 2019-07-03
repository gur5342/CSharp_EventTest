using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class PrimeCallbackArg : EventArgs
    {
        public int Prime;

        public PrimeCallbackArg(int prime)
        {
            this.Prime = prime;
        }
    }
}
