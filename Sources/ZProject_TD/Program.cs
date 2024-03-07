using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZProject_TD
{
    enum VerbeEnum { None, Get, Set, Add, Delete }
    enum NomEnum { None, Product }
    internal class Program
    {
        static void Main(string[] args)
        {
            var saisie = Console.ReadLine(); VerbeEnum verbe = VerbeEnum.None; NomEnum nom = NomEnum.None;

            if (!Extraire(saisie, ref verbe, ref nom))
            {
                Console.WriteLine("Instruction non valide"); 
            }
            else
            {
                Requeter(verbe, nom);
            }

            Console.ReadLine();
        }

        private static void Requeter(VerbeEnum verbe, NomEnum nom)
        {

        }
        private static void GetProduct()
        {

        }

        private static bool Extraire(string saisie, ref VerbeEnum verbe, ref NomEnum nom)
        {
            Regex regex = new Regex("([A-Z][a-z0-9]+)-([A-Z][a-z0-9]+)");

            // Trouver les correspondances dans le texte d'entrée
            MatchCollection matches = regex.Matches(saisie);

            // Parcourir les correspondances et extraire les captures
            foreach (Match match in matches)
            {
                // Captures
                Enum.TryParse<VerbeEnum>(match.Groups[1].Value, true, out verbe);
                Enum.TryParse<NomEnum>(match.Groups[2].Value, true, out nom);
            }
            return verbe != VerbeEnum.None && nom != NomEnum.None;
        }
    }
}
