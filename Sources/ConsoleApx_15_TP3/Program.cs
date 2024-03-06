using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_15_TP3
{
    internal class Program
    {
        // Tri à bulle
        static void Main(string[] args)
        {
            int[] tableau = { 25, 36, 58, 7, 123, 78 };
            int curseur = 0; int tampon = 0;
            while (curseur < tableau.Length-1)
            {
                if (tableau[curseur] <= tableau[curseur + 1])
                    curseur++;
                else
                {
                    tampon = tableau[curseur];
                    tableau[curseur] = tableau[curseur + 1];
                    tableau[curseur + 1] = tampon;
                    curseur = 0;
                }
            }
            foreach (int i in tableau) { Console.WriteLine(i); }
            Console.ReadLine();
        }
    }
}
