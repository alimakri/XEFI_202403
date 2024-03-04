using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class PompeHydraulique
    {
        public void Refroidir(CentraleArgs args)
        {
            if (args.Boost)
                Console.WriteLine("La pompe hydraulique est boostée ({0})", args.Temperature);
            else 
                Console.WriteLine("La pompe hydraulique est lancée ({0})", args.Temperature);
        }
    }
    class PompeElectrique
    {
        public void Refroidir(CentraleArgs args) { Console.WriteLine("La pompe electrique est lancée ({0})", args.Pression); }
    }
    class PompeManuelle
    {
        public void Refroidir(CentraleArgs args) { Console.WriteLine("La pompe manuelle est lancée ({0})", args.Temperature); }
    }
    delegate void RefroidirDelegate(CentraleArgs args);
    class CentraleArgs : EventArgs
    {
        public int Temperature;
        public int Pression;
        public bool Boost = false;

    }
    class Centrale
    {
        public event RefroidirDelegate FaitChaud;
        //List<RefroidirDelegate> Delegues = new List<RefroidirDelegate>();

        ArrayList Pompes = new ArrayList();
        public Centrale()
        {
            var pompe1 = new PompeHydraulique();
            var pompe2 = new PompeElectrique();
            var pompe3 = new PompeElectrique();
            var pompe4 = new PompeManuelle();
            Pompes.Add(pompe1);
            Pompes.Add(pompe2);
            Pompes.Add(pompe3);

            //Delegues.Add(new RefroidirDelegate(pompe1.Refroidir));
            //Delegues.Add(new RefroidirDelegate(pompe2.Refroidir));
            //Delegues.Add(new RefroidirDelegate(pompe3.Refroidir));
            //Delegues.Add(new RefroidirDelegate(pompe4.Refroidir));
            FaitChaud += new RefroidirDelegate(pompe1.Refroidir);
            FaitChaud += new RefroidirDelegate(pompe2.Refroidir);
            FaitChaud += new RefroidirDelegate(pompe3.Refroidir);
            FaitChaud += new RefroidirDelegate(pompe4.Refroidir);

        }
        public void Refroidir()
        {
            //foreach(var pompe in Pompes)
            //{
            //    if (pompe is PompeHydraulique) ((PompeHydraulique)pompe).Refroidir();
            //    else if (pompe is PompeElectrique) ((PompeElectrique)pompe).Refroidir();
            //}

            //foreach (var delegue in Delegues)
            //{
            //    delegue.Invoke();
            //}

            FaitChaud(new CentraleArgs { Pression = 30, Temperature = 3000, Boost = true });
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Centrale c1 = new Centrale();
            c1.Refroidir();

            Console.ReadLine();
        }
    }
}
