using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZProject_TD
{
    public class Entite
    {
        public int Id;
        public string Nom;
    }
    public class Produit : Entite
    {
        public decimal Prix;
        public override string ToString()
        {
            return $"{Id}. {Nom} ({Prix})";
        }
    }
    public class Categorie : Entite
    {
        public override string ToString()
        {
            return $"{Id}. {Nom}";
        }
    }
    public class Commande : Entite
    {
        public int Annee;
        public decimal Total;
        public override string ToString()
        {
            return $"{Annee}. {Total}";
        }
    }
}
