using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Animal
    {
        public string Espece;
        public string Nom;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exemple1();
            Exemple2();


            Console.Read();
        }

        private static void Exemple2()
        {
            List<Animal> list = new List<Animal>
            {
                new Animal {Espece = "Criquet", Nom="Jiminy"},
                new Animal {Espece = "Cheval", Nom="Jolly jumper"},
                new Animal {Espece = "Cheval", Nom="Tornardo"},
                new Animal {Espece = "Chien", Nom="Pif"},
                new Animal {Espece = "Chat", Nom="Tom"},
                new Animal {Espece = "Criquet", Nom="Tom"}
            };
            var chevaux = list.Where(animal => animal.Espece == "Cheval");
            var toms = list.Where(x => x.Nom == "Tom");
            var animauxTries1 = list.OrderBy(x => x.Nom);
            var animauxTries2 = animauxTries1.OrderBy(x => x.Espece);
            var animauxTries3 = animauxTries2.Select(x => x.Nom);

            foreach (var item in chevaux)
            {
                Console.WriteLine(item.Nom);
            }
            foreach (var item in toms)
            {
                Console.WriteLine(item.Nom + " " + item.Espece);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in animauxTries2)
            {
                Console.WriteLine(item.Nom + " " + item.Espece);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in animauxTries3)
            {
                Console.WriteLine(item);
            }
        }

        private static void Exemple1()
        {
            int[] tableau = new int[5];
            tableau[0] = 58;
            tableau[1] = 17;
            tableau[2] = 7;
            tableau[3] = 6;
            tableau[4] = 11;

            // Méthode 1
            for (int index = 0; index < tableau.Length; index++)
            {
                if (tableau[index] % 2 == 1)
                    Console.WriteLine(tableau[index]);
            }

            // Méthode 2 : linq
            var listeImpairs = tableau
                                    .Where(x => x % 2 == 1)
                                    .OrderBy(x => x);

            var listePairs = tableau.Where(x => x % 2 == 0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var nombre in listeImpairs)
            {
                Console.WriteLine(nombre);
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var nombre in listePairs)
            {
                Console.WriteLine(nombre);
            }
        }
    }
}
