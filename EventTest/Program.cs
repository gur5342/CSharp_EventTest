using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    class Program
    {
        private static void PrintPrime(object sender, EventArgs arg)
        {
            Console.Write((arg as PrimeCallbackArg).Prime + ",");
        }

        private static void SumPrime(object sender, EventArgs arg)
        {
            Sum += (arg as PrimeCallbackArg).Prime;
        }
        static int Sum;

        static void Main(string[] args)
        {
            PrimeGenerator gen = new PrimeGenerator();

            gen.PrimeGenerated += PrintPrime;
            gen.PrimeGenerated += SumPrime;
            gen.Run(10);

            Console.WriteLine();

            gen.PrimeGenerated += SumPrime;
            gen.Run(15);
        }

        
    }
}
