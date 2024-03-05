using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10_Encapsulation
{
    // Encapsulation
    internal class Program
    {
        static void Main(string[] args)
        {
            // Version 1
            //var c1 = new CoffreFort { MotDePasse = "" };
            //c1.SetCodeSecret("123");

            //var code = c1.GetCodeSecret();
            //Console.WriteLine(code);

            // Version 2
            var c1 = new CoffreFort { MotDePasse = "ABC" };
            c1.CodeSecret = "123";
            var code = c1.CodeSecret;
            Console.WriteLine(code);
            Console.ReadLine();
        }
    }
    class CoffreFort
    {
        public string MotDePasse;
        

        // Version 0
        // public string CodeSecret;

        // Version 1
        //private string CodeSecret;

        //internal string GetCodeSecret()
        //{
        //    if (MotDePasse == "ABC") return CodeSecret;
        //    return "";
        //}

        //internal void SetCodeSecret(string code)
        //{
        //    CodeSecret = code;
        //}

        // Version 2
        //private string codeSecret;

        //public string CodeSecret
        //{
        //    get { if (MotDePasse == "ABC") return codeSecret; return ""; }
        //    set { codeSecret = value; }
        //}

        // version 3 = Version 0
        //private string codeSecret;

        //public string CodeSecret
        //{
        //    get { return codeSecret;  }
        //    set { codeSecret = value; }
        //}

        // Version 4 = version 3 = version 0
        public string CodeSecret { get;  }
        // Variante de pté en lecture seule
        //public readonly string CodeSecret;
        //public const string CodeSecret="123";
    }
}
