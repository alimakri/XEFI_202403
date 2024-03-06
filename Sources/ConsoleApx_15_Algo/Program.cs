using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_15_Algo
{
    // Types d'algorythme
    // - Math
    // - Méthodique
    // - Alea
    // - Combi
    // - IA
    internal class Program
    {
        // Algo Alea
        private static Random Alea = new Random();
        static void Main(string[] args)
        {

            string cavalier = "A1"; int compteur = 0;
            while (cavalier != "H8")
            {
                int deplacement = Deplalea();
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

        private static int Deplalea()
        {
            return Alea.Next(1, 9);
        }

        private static string Deplacer(string cavalier, int deplacement)
        {
            string np = ""; int x = 0, y = 0;
            switch (deplacement)
            {
                case 1: x = +2; y = +1; break;
                case 2: x = +2; y = -1; break;
                case 3: x = +1; y = +2; break;
                case 4: x = +1; y = -2; break;
                case 5: x = -1; y = +2; break;
                case 6: x = -1; y = -2; break;
                case 7: x = -2; y = +1; break;
                case 8: x = -2; y = -1; break;
            }
            np = ((char)(cavalier[0] + x)).ToString() + ((char)(cavalier[1] + y)).ToString();
            if (np[0] >= 'A' && np[0] <= 'H' && np[1] >= '1' && np[1] <= '8') return np;
            return null;
        }
    }

}
