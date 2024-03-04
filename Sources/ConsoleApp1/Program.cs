//class Jean123
//{
//    static public string Nom = "Dupont";
//    static public string Prenom = "Jean";
//    static public int Age = 20;
//}
//class Sylvie456
//{
//    static public string Nom = "Durand";
//    static public string Prenom = "Sylvie";
//    static public int Age = 30;
//}
using System;

namespace MonEspace1
{
    class Personne
    {
        //public Personne(string nom, string prenom, DateTime dn)
        //{
        //    Nom = nom;
        //    Prenom = prenom;
        //    Age = CalculerAge(dn);
        //    Nombre = Nombre + 1;
        //}
        public static int Nombre = 0;
        public string Nom = null;
        public string Prenom = null;
        public int Age = 0;
        public DateTime DateNaissance;
        public int CalculerAge(DateTime dateNaissance)
        {
            return (int)(DateTime.Now - dateNaissance).TotalDays / 365;
        }
    }
    class Employe : Personne
    {
        public string Societe;
    }
    class Program
    {
        static public void Main()
        {
            int i;
            i = 1;
            DateTime d = default;
            Guid g = default;

            //Personne jean123 = new Personne("Dupont", "Jean", new DateTime(2004, 1, 1));
            Personne jean123 = new Personne
            {
                Nom = "Dupont",
                Prenom = "Jean",
                DateNaissance = new DateTime(2004, 1, 1)
            };
            Personne sylvie456 = new Personne
            {
                Nom = "Durand",
                Prenom = "Sylvie",
                DateNaissance = new DateTime(1994, 1, 1)
            };
            Personne etienne = new Employe
            {
                Nom = "Dumont",
                Prenom = "Etienne",
                DateNaissance = new DateTime(2000, 1, 1),
                Societe = "Xifi"
            };

            Console.WriteLine(jean123.Age + " ans");
            Console.WriteLine(g);
            Console.WriteLine(Personne.Nombre + " personnes ont été définies.");

            
            Console.Read();
        }
    }
}