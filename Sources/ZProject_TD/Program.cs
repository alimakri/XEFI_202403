using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZProject_TD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var saisie = Console.ReadLine();
            Regex reg = new Regex("([A-Z][a-z0-9]+)-([A-Z][a-z0-9]+)");

            Console.ReadLine();
        }
    }
}
