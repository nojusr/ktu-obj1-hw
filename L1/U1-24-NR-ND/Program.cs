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
        public static void Main(string[] args)
        {
            // read from file
            List<Hero> allHeroes = IOUtils.ReadHeroes("herojai.csv");

            // print out heroes with highest [LifePoints]
            Console.WriteLine("Herojai su didžiausiu kiekiu gyvybės taškų:");
            IOUtils.PrintHeroes(TaskUtils.FindHeroesWithHighestHealth(allHeroes));

            // print out all heroes with the smallest difference between
            // [AtkPoints] and [DefPoints]
            Console.WriteLine("Herojai su mažiausiu skirtumu tarp žalos ir gynybos taškų:");
            IOUtils.PrintHeroes(TaskUtils.FindHeroesWithSmallestDifference(allHeroes));

            List<String> uniqueClasses = TaskUtils.FindUniqueClasses(allHeroes);
            IOUtils.OutputClassesToCSV("Klasės.csv", uniqueClasses);

        }
    }
}
