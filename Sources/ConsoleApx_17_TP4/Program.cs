using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_17_TP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var saisie = Console.ReadLine(); int n = 0;
            if (int.TryParse(saisie, out n))
            {
                Console.WriteLine(SommeSuite(n));
            }
            Console.ReadLine();
        }

        private static int SommeSuite(int n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}
