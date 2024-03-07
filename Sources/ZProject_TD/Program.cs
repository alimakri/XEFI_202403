using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZProject_TD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var saisie = Console.ReadLine(); VerbeEnum verbe = null; string nom = null;

            if (!Extraire(saisie, ref verbe, ref nom))
            {
                Console.WriteLine("Instruction non valide"); 
            }
            else
            {
                Console.WriteLine("Ok !");
            }

            Console.ReadLine();
        }

        private static bool Extraire(string saisie, ref string verbe, ref string nom)
        {
            Regex regex = new Regex("([A-Z][a-z0-9]+)-([A-Z][a-z0-9]+)");

            // Trouver les correspondances dans le texte d'entrée
            MatchCollection matches = regex.Matches(saisie);

            // Parcourir les correspondances et extraire les captures
            foreach (Match match in matches)
            {
                // Captures
                verbe = match.Groups[1].Value;
                nom = match.Groups[2].Value;
            }
            return ! string.IsNullOrEmpty(verbe);
        }
    }
}
