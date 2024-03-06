using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_17_Algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var saisie = Console.ReadLine(); int n = 0;
            if (int.TryParse(saisie, out n))
            {
                Console.WriteLine(Factoriel(n));
            }
            Console.ReadLine();
        }

        private static int Factoriel(int n)
        {
            if (n == 1) return 1;
            var resultat = n * Factoriel(n - 1);
            return resultat;    
        }
    }
}
