using System;
using System.Threading;

namespace ConsoleApx18_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Compteur c1 = new Compteur
            {
                Nom = "C1",
                Depart = 1,
                Pause = 1000,
                Couleur = ConsoleColor.Green
            };
            Compteur c2 = new Compteur
            {
                Nom = "C2",
                Depart = 1,
                Pause = 2000,
                Couleur = ConsoleColor.Magenta
            };
            var d1 = new Func<int, string>(c1.Go);
            var d2 = new Func<int, string>(c2.Go);
            d1.BeginInvoke(10, new AsyncCallback(c1.Fin), "Compteur 1");
            d2.BeginInvoke(10, new AsyncCallback(c2.Fin), "Compteur 2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Fin du programme");
            Console.ReadLine();
        }
    }
    class Compteur
    {
        public string Nom;
        public int Depart;
        public int Pause;
        public ConsoleColor Couleur;
        public string Go(int arrivee)
        {
            for (int i = Depart; i <= arrivee; i++)
            {
                Console.ForegroundColor = Couleur;
                Console.WriteLine("{0}. {1}", Nom, i);
                Thread.Sleep(Pause);
            }
            return arrivee.ToString();
        }
        public void Fin(IAsyncResult ar)
        {
            var parametre = ar.AsyncState.ToString();
            Console.ForegroundColor = Couleur;
            Console.WriteLine("{0}. Fin du {1}", Nom, parametre);
        }
    }
}
