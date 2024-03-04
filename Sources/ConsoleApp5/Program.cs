using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class O1
    {
        public void M1(int a)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Méthode M1 de la classe O1 avec {0}", a);
        }
    }
    class O2
    {
        public void M2(int a) { Console.WriteLine("Méthode M2 de la classe O2 avec {0}", a); }
    }
    class O3
    {
        public int M3() { return 0; }
    }
    delegate void D1(int a);

    internal class Program
    {
        static void Main(string[] args)
        {
            var o1 = new O1();
            var o2 = new O2();
            var o = new O3();
            var d1 = new D1(o1.M1);
            var d2 = new D1(o2.M2);
            o1.M1(10);
            Console.WriteLine("Go");
            d1.BeginInvoke(8, null, null);
            Console.WriteLine("Fin");
            d2.BeginInvoke(77, null, null);

            Console.Read();
        }
    }
}
