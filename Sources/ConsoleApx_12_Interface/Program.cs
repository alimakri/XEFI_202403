using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_12_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Forme c1 = new Cercle();
            c1.Dessiner();

            Console.ReadLine();
        }
    }
    abstract class Forme
    {
        public abstract void Dessiner();
        public abstract void Effacer();
    }
    class Cercle : Forme
    {
        public override void Dessiner()
        {
            Console.WriteLine("Je dessine un cercle");
        }
        public override void Effacer()
        {
            Console.WriteLine("J'efface un cercle");
        }
    }
    class Carre : Forme
    {
        public override void Dessiner()
        {
            Console.WriteLine("Je dessine un carré");
        }

        public override void Effacer()
        {
            Console.WriteLine("J'efface un carré");
        }
    }
    class Triangle : Forme
    {
        public override void Dessiner()
        {
            
        }

        public override void Effacer()
        {
            
        }
    }
}
