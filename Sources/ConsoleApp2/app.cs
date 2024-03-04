using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Espace2;

namespace ConsoleApp2
{
    internal class Program
    {
        private int j = 0;
        static void Main(string[] args)
        {
            Voiture v;
            string s = Console.ReadLine();
            if (s == "voiture")
            {
                v = new Voiture();
            }
            else
            {
                v = new Chevrolet();
            }
            v.Rouler();
            //string m = v.Moteur;

            //Voiture r5 = new Renault();
            int x = r5.NbRoues;

            Console.Read();
        }
    }
}
namespace Espace2
{
    public class Voiture
    {
        public int NbRoues;
        protected string Moteur = "V1";

        private string NoChassis;
        public virtual void Rouler()
        {
            Console.WriteLine("La voiture roule");
        }
    }
    class Chevrolet : Voiture
    {
        public override void Rouler()
        {
            string moteur = Moteur;
            Console.WriteLine("La chevrolet roule avec un moteur " + moteur);
        }
    }
    class ChevroletVip : Chevrolet
    {
        public override void Rouler()
        {
            Console.WriteLine("La chevrolet roule");
        }
    }
}