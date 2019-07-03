using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public class PrimeGenerator
    {
        
        public event EventHandler PrimeGenerated;

        public void Run(int limit)
        {
            for (int i = 2; i <= limit; i++)
            {
                if (IsPrime(i) == true && PrimeGenerated != null)
                {
                    PrimeGenerated(this, new PrimeCallbackArg(i));
                }
            }
        }

        private bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return true;
            }
            for (int i = 3 ; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                    return false;

            }
            return candidate != 1;
        }
        
    }
}
