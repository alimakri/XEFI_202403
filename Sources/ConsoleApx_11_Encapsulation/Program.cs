using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_11_Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Version 1
            //var liste = new List<Personne>();
            //liste.Add(new Personne { Nom = "Pierre" });
            //liste.Add(new Personne { Nom = "Paul" });
            //liste.Add(new Personne { Nom = "Jacques" });

            // Version 2
            //var liste = new Personnes();
            //liste.Add(new Personne { Nom = "Pierre" });
            //liste.Add(new Personne { Nom = "Paul" });
            //liste.Add(new Personne { Nom = "Jacques" });

            // Version 3
            var liste = new Personnes();
            liste.Add(new Personne { Nom = "Pierre" });
            liste.Add(new Personne { Nom = "Paul" });
            liste.Add(new Personne { Nom = "Jacques" });


            for (int i=0; i < liste.Count; i++)
            {
                Console.WriteLine(liste[i]);
            }
            foreach (var p in liste)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }
    }
    // Version 2
    //class Personnes : List<Personne>
    //{

    //}
    // Version 3
    class Personnes : IEnumerable<Personne> 
    {
        private List<Personne> listeInterne = new List<Personne>();
        public int Count
        {
            get
            {
                return listeInterne.Count;
            }
        }
        public void Add(Personne p)
        {
            if (p.Nom != "Pierre")
            {
                listeInterne.Add(p);
            }
            
        }

        public IEnumerator<Personne> GetEnumerator()
        {
            return new PersonneEnumerator(listeInterne);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonneEnumerator(listeInterne);
        }

        public Personne this[int index]
        {
            get
            {
                return listeInterne[index];
            }
        }
    }
    class PersonneEnumerator : IEnumerator<Personne>
    {
        private List<Personne> Liste = new List<Personne>();
        private int Index = -1;
        public PersonneEnumerator(List<Personne> liste)
        {
            Liste = liste;
        }
        public Personne Current => Liste[Index];

        object IEnumerator.Current => Liste[Index];

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            Index++;
            return Index < Liste.Count;
        }

        public void Reset()
        {
            Index= -1;
        }
    }
    class Personne
    {
        public string Nom;
        public override string ToString()
        {
            return Nom;
        }
    }
}
