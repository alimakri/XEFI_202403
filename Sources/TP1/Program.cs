﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    // Définir une classe Maison avec une propriété Porte
    // Dans le Main, demander à la porte de la maison m1 de s'ouvrir.
    // A l'exécution, il faut que le message "La porte de la maison M1 est ouverte" s'affiche.
    internal class Program
    {
        static void Main(string[] args) 
        {
            Maison m1 = new Maison();
            m1.Nom = "M1";
            m1.Porte.Ouvrir(m1.Nom);

            Console.Read();
        }
    }
    class Maison
    {
        public Maison()
        {
            Porte = new Ouverture();
        }
        public string Nom;
        public Ouverture Porte;
    }
    class Ouverture
    {
        public void Ouvrir(string maison)
        {
            Console.WriteLine("La porte de la maison {0} est ouverte.", maison);
        }
    }
}
