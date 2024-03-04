using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4_TP2
{
    // 3 équipes de foot : 2 fr + 1 italienne.
    // Dans chaque équipe 3 joueurs dont 1 remplaçant
    // Linq : Quelles sont les équipes espagnoles ?
    // Linq : Qui sont les remplaçants dans toutes les équipes ?
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Equipe> equipes = new List<Equipe>();

            var equipe1 = new Equipe { Nom = "OM", Pays = "fr" };
            equipe1.Joueurs.Add(new Joueur { Nom = "Claus" });
            equipe1.Joueurs.Add(new Joueur { Nom = "Drogba" });
            equipe1.Joueurs.Add(new Joueur { Nom = "Papin", Remplacant = true });
            equipes.Add(equipe1);

            var equipe2 = new Equipe { Nom = "Madrid", Pays="es" };
            equipe1.Joueurs.Add(new Joueur { Nom = "Bellingham" });
            equipe1.Joueurs.Add(new Joueur { Nom = "Vinicius" });
            equipe1.Joueurs.Add(new Joueur { Nom = "Rodrigo", Remplacant = true });
            equipes.Add(equipe2);

            var equipe3 = new Equipe { Nom = "Barcelone", Pays = "Es" };
            equipe1.Joueurs.Add(new Joueur { Nom = "Lewandoski" });
            equipe1.Joueurs.Add(new Joueur { Nom = "Yamal" });
            equipe1.Joueurs.Add(new Joueur { Nom = "Pedri", Remplacant = true });
            equipes.Add(equipe3);

            var espagnoles = equipes.Where(x => x.Pays.ToLower() == "es");
            var remplacants = equipes
                .SelectMany(e => e.Joueurs)
                .Where(j => j.Remplacant)
                .OrderByDescending(j=>j.Nom);
            
            // Affichage
            Console.WriteLine("Les équipes espagnoles sont :");
            foreach(var e in espagnoles) Console.WriteLine(e);
            Console.WriteLine();
            foreach (var j in remplacants) Console.WriteLine(j);

            Console.Read();
        }
    }
    class Equipe 
    {
        public string Nom;
        public List<Joueur> Joueurs = new List<Joueur>();
        public string Pays;

        public override string ToString()
        {
            return Nom + "(" + Pays + ")";
        }
    }
    class Joueur
    {
        public string Nom;
        public bool Remplacant = false;
        public override string ToString()
        {
            return Nom;
        }
    }
}
