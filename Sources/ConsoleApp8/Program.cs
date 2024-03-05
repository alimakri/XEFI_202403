using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Démo 1
            var kawa = new Moto { Id = Guid.NewGuid(), Nom = "Kawasaki", VitesseMax = 200 };
            var v = 350;
            ChangeVitesse(kawa, ref v);

            // Démo 2
            string s = "123"; int i = 0;
            if (int.TryParse(s, out i))
                Console.WriteLine(i);

            // Démo 3
            Moto[] tableauMotos = 
            {
                new Moto { Id = Guid.NewGuid(), Nom="Yamaha"},
                new Moto { Id = Guid.NewGuid(), Nom="Honda"},
                new Moto { Id = Guid.NewGuid(), Nom="Bmw"},
            };
            Affiche(tableauMotos);

            // Démo 4
            string maChainedeCaractere = "abc";
            maChainedeCaractere += "def";
            Console.WriteLine(maChainedeCaractere);

            StringBuilder maChaine = new StringBuilder("abc");
            maChaine.Append("def");
            Console.WriteLine(maChaine);
            
            Console.ReadLine();
        }

        private static void Affiche(Moto[] tableauMotos)
        {
            foreach(var moto in tableauMotos)
            {
                Console.WriteLine(moto);
            }
        }

        private static void ChangeVitesse(Moto moto, ref int nouvelleVitesse)
        {
            moto.VitesseMax = nouvelleVitesse;
            nouvelleVitesse = 0;
        }
    }
    class Moto
    {
        public Guid Id;
        public string Nom;
        public int VitesseMax;
        public override string ToString()
        {
            return $"{Id}: Nom = {Nom}";
        }
    }
}
