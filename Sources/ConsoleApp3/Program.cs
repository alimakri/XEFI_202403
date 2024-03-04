using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    // Définir une classe Maison avec une propriété Porte
    // Dans le Main, demander à la porte de la maison m1 de s'ouvrir.
    // A l'exécution, il faut que le message "La porte de la maison M1 est ouverte" s'affiche.
    internal class Program
    {
        static void Main(string[] args)
        {
            Maison m1 = new Maison { Nom = "Emeraude" };
            var m2 = new Maison { Nom = "Rubis" };

            List<Maison> liste = new List<Maison>();
            liste.Add(m1);
            liste.Add(m2);
            liste.Add(new Maison { Nom = "Saphir" });

            m1 = null;

            foreach (Maison m in liste)
            {
                m.Porte.Ouvrir(m.Nom);
            }
            for(int i= 0; i < liste.Count; i++)
            {
               Console.WriteLine( liste[i].Nom);
            }

            //Console.WriteLine(m1.Nom);
            Console.WriteLine(liste[0].Nom);
            Console.Read();
        }
    }
    class Maison
    {
        public Maison()
        {
            Porte = new Ouverture();
        }
        public string Nom;
        public Ouverture Porte;
    }
    class Ouverture
    {
        public void Ouvrir(string maison)
        {
            Console.WriteLine("La porte de la maison {0} est ouverte.", maison);
        }
    }
}
