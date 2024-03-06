using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApx18_TP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var c = new Calcul();
            var resultat1 = c.Go1();
            var resultat2 = c.Go2();
            Console.WriteLine(resultat1);
            Console.WriteLine(resultat2);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
    class Calcul
    {
        public int Go1()
        {
            Thread.Sleep(500);
            return 99;
        }
        public int Go2()
        {
            Thread.Sleep(1500);
            return 11;
        }
    }
}
