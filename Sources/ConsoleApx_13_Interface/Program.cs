using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_13_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IForme c1 = new Cercle();
            c1.Dessiner();

            Console.ReadLine();
        }
    }
    interface IForme
    {
        void Dessiner();
        void Effacer();
    }
    interface IPrint
    {
        void Print();
    }
    class Cercle : IForme, IPrint
    {
        public  void Dessiner()
        {
            Console.WriteLine("Je dessine un cercle");
        }
        public  void Effacer()
        {
            Console.WriteLine("J'efface un cercle");
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
    class Carre : IForme
    {
        public void Dessiner()
        {
            
        }

        public void Effacer()
        {
            
        }
    }
}
