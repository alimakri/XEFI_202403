using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dessin d = null;


            var original = new Dessin
            {
                Numero = Guid.NewGuid(),
                Nom = "Guernica",
                Auteur = "Picasso",
                DatePublication = new DateTime(1935, 5, 20),
                DateCopie = null
            };
            Dessin copie1 = original.Reproduire();
            Dessin copie2 = original.Reproduire(DateTime.Now.AddDays(-1));
            copie2.DateCopie = null;
            Console.WriteLine(copie2.IsCopie());

            var liste = original.Reproduire(10);
            //var liste = Dessin.Reproduire(copie1, 10);
            foreach(var item in liste)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
    class Dessin
    {
        private static Guid NumeroOriginal = default;
        public Guid Numero;
        public string Nom;
        public string Auteur;
        public DateTime DatePublication;
        public DateTime? DateCopie;
        public Dessin()
        {
            if (NumeroOriginal == default) NumeroOriginal = Guid.NewGuid();
        }
        public List<Dessin> Reproduire(int nCopie)
        {
            var list = new List<Dessin>();
            for (int i = 0; i < nCopie; i++)
            {
                list.Add(Reproduire());
                Thread.Sleep(1000);
            }
            return list;
        }
        public Dessin Reproduire()
        {
            return Reproduire(DateTime.Now);
        }
        public Dessin Reproduire(DateTime date)
        {
            return new Dessin
            {
                Numero = Guid.NewGuid(),
                Nom = Nom,
                Auteur = Auteur,
                DatePublication = DatePublication,
                DateCopie = date
            };
        }
        public bool IsCopie()
        {
            return Numero != NumeroOriginal;
        }
        public override string ToString()
        {
            var copie = IsCopie() ? "(copie)" : "(Original)";
            return Nom + " : " + Auteur + " " + copie + " " + DatePublication.ToString("dddd d MMM");
        }
    }
}
