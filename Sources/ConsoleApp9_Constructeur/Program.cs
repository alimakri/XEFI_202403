using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9_Constructeur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Version 1
            var bat1 = new Batiment();
            Console.WriteLine(bat1);

            // Version 2
            var bat2 = new Batiment();
            bat2.Nom = "Le Pompidou";
            Console.WriteLine(bat2);

            // Version 3
            var bat3 = new Batiment { Nom = "Le Verlaine" };
            Console.WriteLine(bat3);

            // Version 4
            var bat4 = new Batiment("Saphir");
            Console.WriteLine(bat4);

            // Version 5
            var bat5 = Batiment.CreateInstance("Emeraude");
            Console.WriteLine(bat5);

            // Version 6 : Singleton
            BatimentDiamant.Nom = "Diamant";
            Console.WriteLine(BatimentDiamant.Nom);

            // Version 7 : Singleton du Design Pattern
            var bat7 = BatimentDiamant2.Instance.Nom = "Diamant2";
            Console.WriteLine(bat7);


            Console.ReadLine();
        }
    }
    class Batiment
    {
        public string Nom = "inconnu";
        public int NEtage = 6;

        public Batiment()
        {

        }
        public Batiment(string nom)
        {
            Nom = nom;
        }
        public Batiment(string nom, int nEtage)
        {
            Nom = nom;
            NEtage = nEtage;
        }

        internal static Batiment CreateInstance(string nom)
        {
            return new Batiment(nom);
        }

        public override string ToString()
        {
            return Nom;
        }
    }

    public static class BatimentDiamant
    {
        public static string Nom;
    }
    public sealed class BatimentDiamant2
    {
        public string Nom;

        private BatimentDiamant2() { }
        private static BatimentDiamant2 instance = null;
        public static BatimentDiamant2 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BatimentDiamant2();
                }
                return instance;
            }
        }
    }
    //class Bat : BatimentDiamant2
    //{

    //}
}
