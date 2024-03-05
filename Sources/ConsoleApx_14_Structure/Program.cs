using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_14_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rmc = new Radio("RMC", 104.2);
            rmc.Categorie = CategorieEnum.Debat | CategorieEnum.Sport;
            
            List<Radio> mesRadios = new List<Radio>
            {
                rmc,
                new Radio("Europe 1", 104.6),
                new Radio("France Info", 105.4),
                new Radio("RTL", 105),
                new Radio("Sud Radio", 105.8)
            };
            var centCinqPointHuit = 105.8;
            foreach (var radio in mesRadios)
            {
                if (radio.isFrequence(centCinqPointHuit))
                    Console.WriteLine(radio.Nom);
            }
            Console.WriteLine((rmc.Categorie & CategorieEnum.Musique) == CategorieEnum.Musique);
            Console.ReadLine();
        }
    }
    [Flags]
    enum CategorieEnum { None = 0, Musique = 1, Debat = 2, Sport = 4, Information = 8 }
    struct Radio
    {
        public Radio(string nom, double frequence)
        {
            Nom = nom; Frequence = frequence;
            Pays = "France";
            DabPlus = true; Categorie = CategorieEnum.None;
        }
        public double Frequence;
        public string Nom;
        public string Pays;
        public bool isFrequence(double frequence)
        {
            return Frequence == frequence;
        }

        public bool DabPlus;
        public CategorieEnum Categorie;
    }
}
