using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class PrimeGenerator
    {
       // public event EventHandler PrimeGenerated;

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
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                    return false;

            }
            return candidate != 1;
        }

        #region PrimeGenerated event things for C# 3.0
        public event EventHandler<PrimeGeneratedEventArgs> PrimeGenerated;

        protected virtual void OnPrimeGenerated(PrimeGeneratedEventArgs e)
        {
            if (PrimeGenerated != null)
                PrimeGenerated(this, e);
        }

        private PrimeGeneratedEventArgs OnPrimeGenerated(int minusPrime, int plusPrime)
        {
            PrimeGeneratedEventArgs args = new PrimeGeneratedEventArgs(minusPrime, plusPrime);
            OnPrimeGenerated(args);

            return args;
        }

        private PrimeGeneratedEventArgs OnPrimeGeneratedForOut()
        {
            PrimeGeneratedEventArgs args = new PrimeGeneratedEventArgs();
            OnPrimeGenerated(args);

            return args;
        }

        public class PrimeGeneratedEventArgs : EventArgs
        {
            public int MinusPrime { get; set; }
            public int PlusPrime { get; set; }

            public PrimeGeneratedEventArgs()
            {
            }

            public PrimeGeneratedEventArgs(int minusPrime, int plusPrime)
            {
                MinusPrime = minusPrime;
                PlusPrime = plusPrime;
            }
        }
        #endregion
    }
}
