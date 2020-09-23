//IOUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_24_NR_ND
{
    static class IOUtils
    {

        public static List<Hero> ReadHeroes(string fileName)
        {
            List<Hero> output = new List<Hero>();

            string[] lines = new string[100];

            // file error handling
            if (System.IO.File.Exists(fileName))
            {
                lines = File.ReadAllLines(fileName, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("Failas nerastas. Programa negali veikti.");
                System.Environment.Exit(1); // exit code 1 means that the program did not run successfuly
            }

            if (lines.Length <= 0)
            {
                Console.WriteLine("Pateiktas tuščias failas. Programa negali veikti.");
                System.Environment.Exit(1); // exit code 1 means that the program did not run successfuly
            }

            foreach (string line in lines)
            {
                string[] values = line.Split(';');

                string name = values[0];
                string race = values[1];
                string _class = values[2];
                int lifePoints = int.Parse(values[3]);
                int manaPoints = int.Parse(values[4]);
                int atkPoints = int.Parse(values[5]);
                int defPoints = int.Parse(values[6]);
                int strPoints = int.Parse(values[7]);
                int spdPoints = int.Parse(values[8]);
                int intPoints = int.Parse(values[9]);
                string special = values[10];

                Hero heroToAdd = new Hero(
                    name,
                    race,
                    _class,
                    lifePoints,
                    manaPoints,
                    atkPoints,
                    defPoints,
                    strPoints,
                    spdPoints,
                    intPoints,
                    special
                );

                output.Add(heroToAdd);

            }

            return output;
        }

        public static void PrintHeroes(List<Hero> input)
        {
            PrintIndexedTableLine(18, 11, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│ {0,-16} │ {1,-16} │ {2,-16} │ {3,-16} │ {4,-16} │ {5, -16} │ {6, -16} │ {7, -16} │ {8, -16} │ {9, -16} │ {10, -16} │",
                "Vardas",
                "Rasė",
                "Klasė",
                "Gyvybės t.",
                "Manos t.",
                "Žalos t.",
                "Gynybos t.",
                "Jėga",
                "Vikrumas",
                "Intelektas",
                "Ypat. galia"
            );

            PrintIndexedTableLine(18, 11, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Hero hero = input[i];
                Console.WriteLine(
                    "│ {0,-16} │ {1,-16} │ {2,-16} │ {3,-16} │ {4,-16} │ {5, -16} │ {6, -16} │ {7, -16} │ {8, -16} │ {9, -16} │ {10, -16} │",
                    hero.Name,
                    hero.Race,
                    hero.Class,
                    hero.LifePoints,
                    hero.ManaPoints,
                    hero.AtkPoints,
                    hero.DefPoints,
                    hero.StrPoints,
                    hero.SpdPoints,
                    hero.IntPoints,
                    Truncate(hero.Special, 12)
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(18, 11, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(18, 11, '├', '┼', '┤', '─');
                }
            }

        }

        // prints out a list of heroes with some of their info not shown
        public static void PrintHeroesCompressed(List<Hero> input)
        {
            PrintIndexedTableLine(18, 4, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│ {0,-16} │ {1,-16} │ {2,-16} │ {3,-16} │",
                "Vardas",
                "Rasė",
                "Klasė",
                "Gyvybės t."
            );

            PrintIndexedTableLine(18, 4, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Hero hero = input[i];
                Console.WriteLine(
                    "│ {0,-16} │ {1,-16} │ {2,-16} │ {3,-16} │",
                    hero.Name,
                    hero.Race,
                    hero.Class,
                    hero.LifePoints
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(18, 4, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(18, 4, '├', '┼', '┤', '─');
                }
            }

        }
             
        // a method to truncate strings that are too long
        private static string Truncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        // a simple method to assist in creating text character based tables
        private static void PrintIndexedTableLine(int spacing, int columnCount, char leftEdge, char middleEdge, char rightEdge, char line)
        {

            Console.Write(leftEdge);

            for (int i = 0; i < columnCount; i++) {

                Console.Write(new string(line, spacing));

                if (i == columnCount - 1)
                {
                    Console.WriteLine(rightEdge);
                }
                else
                {
                    Console.Write(middleEdge);
                }
            }
        }

        public static void OutputClassesToCSV(string fileName, List<String> classes)
        {
            string[] lines = classes.ToArray();

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

    }
}


