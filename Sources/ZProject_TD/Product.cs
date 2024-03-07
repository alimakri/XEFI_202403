using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZProject_TD
{
    public class Produit
    {
        public int Id;
        public string Nom;
        public decimal Prix;
        public override string ToString()
        {
            return $"{Id}. {Nom} ({Prix})";
        }
    }
}
