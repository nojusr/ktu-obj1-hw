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
        /// <summary>
        /// reads heroes in from a filename
        /// </summary>
        /// <param name="fileName">the filename from which to read</param>
        /// <returns>a list of heroes</returns>
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


        /// <summary>
        /// prints out a table of heroes when give a list of them as input
        /// </summary>
        /// <param name="input">the list of heroes to be used as input</param>
        public static void PrintHeroes(List<Hero> input)
        {
            // the amount of empty characters given for every value in the table
            List<int> tableSpacing = new List<int> {10, 14, 11, 4, 4, 4, 5, 2, 2, 2, 16};


            PrintIndexedTableLine(tableSpacing, 11, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│{0,-10}│{1,-14}│{2,-11}│{3,-4}│{4,-4}│{5, -4}│{6, -5}│{7, -2}│{8, -2}│{9, -2}│{10, -16}│",
                "Vardas",
                "Rasė",
                "Klasė",
                "G.t.",
                "M.t.",
                "Ž.t.",
                "Gy.t.",
                "J.",
                "V.",
                "I.",
                "Ypat. galia"
            );

            PrintIndexedTableLine(tableSpacing, 11, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Hero hero = input[i];
                Console.WriteLine(
                    "│{0,-10}│{1,-14}│{2,-11}│{3,-4}│{4,-4}│{5, -4}│{6, -5}│{7, -2}│{8, -2}│{9, -2}│{10, -16}│",
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
                    PrintIndexedTableLine(tableSpacing, 11, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(tableSpacing, 11, '├', '┼', '┤', '─');
                }
            }

        }

        /// <summary>
        /// prints out a list of heroes with some of their info omitted
        /// </summary>
        /// <param name="input">a list of heroes to be used as input</param>
        public static void PrintHeroesCompressed(List<Hero> input)
        {
            // the amount of empty characters given for every value in the table
            List<int> tableSpacing = new List<int> {18, 18, 18, 18};


            PrintIndexedTableLine(tableSpacing, 4, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│ {0,-16} │ {1,-16} │ {2,-16} │ {3,-16} │",
                "Vardas",
                "Rasė",
                "Klasė",
                "Gyvybės t."
            );

            PrintIndexedTableLine(tableSpacing, 4, '├', '┼', '┤', '─');

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
                    PrintIndexedTableLine(tableSpacing, 4, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(tableSpacing, 4, '├', '┼', '┤', '─');
                }
            }

        }

        /// <summary>
        /// a method to truncate strings that are too long
        /// </summary>
        /// <param name="value">the string to truncate</param>
        /// <param name="maxChars">the maximum amount of chars to use before truncating</param>
        /// <returns></returns>
        private static string Truncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }


        /// <summary>
        ///  a simple method to assist in creating text character based tables
        /// </summary>
        /// <param name="spacing">a list of ints which defines the amount of <paramref name="line"/> chars to put in between any of the other chars</param>
        /// <param name="columnCount">the amount of columns in the</param>
        /// <param name="leftEdge">the char used at the left edge of the table</param>
        /// <param name="middleEdge">the char used inbetween lines</param>
        /// <param name="rightEdge">the char used at the right edge or end of the line</param>
        /// <param name="line">the char used inbetween any and all other chars</param>
        private static void PrintIndexedTableLine(List<int> spacing, int columnCount, char leftEdge, char middleEdge, char rightEdge, char line)
        {

            Console.Write(leftEdge);

            for (int i = 0; i < columnCount; i++) {

                Console.Write(new string(line, spacing[i]));

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

        /// <summary>
        /// outputs a list of classes to a csv file
        /// </summary>
        /// <param name="fileName">the filename to which to output</param>
        /// <param name="classes">the list of classes</param>
        public static void OutputClassesToCSV(string fileName, List<String> classes)
        {
            string[] lines = classes.ToArray();

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

    }
}


