using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_15_Algo
{
    // Types d'algorythme
    // - Math
    // - Alea
    // - Combi
    // - IA
    internal class Program
    {
        // Alea
        static void Main(string[] args)
        {
            Random alea = new Random();

            string cavalier = "A1"; int compteur = 0;
            while (cavalier != "H8")
            {
                int deplacement = alea.Next(1, 9);
                string nouvellePosition = Deplacer(cavalier, deplacement);
                if (nouvellePosition != null)
                {
                    cavalier = nouvellePosition;
                    compteur++;
                    Console.WriteLine($"{compteur}. {nouvellePosition}");
                }
            }
            Console.ReadLine();
        }

        private static string Deplacer(string cavalier, int deplacement)
        {
            string np = "";
            switch (deplacement)
            {
                case 1: np = ((char)(cavalier[0] + 2)).ToString() + ((char)(cavalier[1] - 1)).ToString(); break;
                case 2: np = ((char)(cavalier[0] + 2)).ToString() + ((char)(cavalier[1] + 1)).ToString(); break;
                case 3: np = ((char)(cavalier[0] + 1)).ToString() + ((char)(cavalier[1] + 2)).ToString(); break;
                case 4: np = ((char)(cavalier[0] - 1)).ToString() + ((char)(cavalier[1] + 2)).ToString(); break;
                case 5: np = ((char)(cavalier[0] - 2)).ToString() + ((char)(cavalier[1] + 1)).ToString(); break;
                case 6: np = ((char)(cavalier[0] - 2)).ToString() + ((char)(cavalier[1] - 1)).ToString(); break;
                case 7: np = ((char)(cavalier[0] - 1)).ToString() + ((char)(cavalier[1] - 2)).ToString(); break;
                case 8: np = ((char)(cavalier[0] + 1)).ToString() + ((char)(cavalier[1] - 2)).ToString(); break;
            }
            if (np[0] >= 'A' && np[0] <= 'H' && np[1] >= '1' && np[1] <= '8') return np;
            return null;
        }
    }

}
