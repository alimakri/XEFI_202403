using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApx18_TP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new Calcul();
            Console.WriteLine(DateTime.Now);
            // TODO
            var d1 = new Func<int>(c.Go1);
            var d2 = new Func<int>(c.Go2);
            d1.BeginInvoke(new AsyncCallback(c.Fini), null);
            d2.BeginInvoke(new AsyncCallback(c.Fini), null);

            // A l'origine
            //var resultat1 = c.Go1();
            //var resultat2 = c.Go2();
            //Console.WriteLine(resultat1);
            //Console.WriteLine(resultat2);

            Console.ReadLine();
        }
    }
    class Calcul
    {
        private int Resultat = 0;
        public int Go1()
        {
            Thread.Sleep(2500);
            Resultat = 99;
            return 99;
        }
        public int Go2()
        {
            Thread.Sleep(5500);
            Resultat = 11;
            return 11;
        }

        internal void Fini(IAsyncResult ar)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(Resultat);
        }
    }
}
