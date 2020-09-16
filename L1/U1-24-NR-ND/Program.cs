using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_24_NR_ND
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Hero> allHeroes = IOUtils.ReadHeroes("herojai.csv");

            IOUtils.PrintHeroes(allHeroes);
        }
    }
}
