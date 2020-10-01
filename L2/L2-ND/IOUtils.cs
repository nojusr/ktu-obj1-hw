//IOUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_ND
{
    static class IOUtils
    {
        /// <summary>
        /// reads players in from a filename
        /// </summary>
        /// <param name="fileName">the filename from which to read</param>
        /// <returns>a list of players</returns>
        public static List<Player> ReadPlayers(string fileName)
        {
            List<Player> output = new List<Player>();

            string[] lines = new string[150];

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
                string surname = values[1];
                int age = int.Parse(values[2]);
                int height = int.Parse(values[3]);
                string position = values[4];
                bool isPicked = bool.Parse(values[5]);
                bool isCaptain = bool.Parse(values[6]);

                Player PlayerToAdd = new Player(
                    name,
                    surname,
                    age,
                    height,
                    position,
                    isPicked,
                    isCaptain
                );

                output.Add(PlayerToAdd);

            }

            return output;
        }


        /// <summary>
        /// prints out a table of Players when give a list of them as input
        /// </summary>
        /// <param name="input">the list of Players to be used as input</param>
        public static void PrintPlayers(List<Player> input)
        {
            // the amount of empty characters given for every value in the table
            List<int> tableSpacing = new List<int> {10, 14, 3, 3, 10, 10, 10};


            PrintIndexedTableLine(tableSpacing, 7, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│{0,-10}│{1,-14}│{2,-3}│{3,-3}│{4,-10}│{5, -10}│{6, -10}│",
                "Vardas",
                "Pavardė",
                "Amž",
                "Au.",
                "Pozicija",
                "Išrinktas",
                "Kapitonas"
            );

            PrintIndexedTableLine(tableSpacing, 7, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Player player = input[i];
                Console.WriteLine(
                    "│{0,-10}│{1,-14}│{2,-3}│{3,-3}│{4,-10}│{5, -10}│{6, -10}│",
                    player.Name,
                    player.Surname,
                    player.Age,
                    player.Height,
                    player.Position,
                    player.IsPicked,
                    player.IsCaptain
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(tableSpacing, 7, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(tableSpacing, 7, '├', '┼', '┤', '─');
                }
            }

        }

        /// <summary>
        /// prints only the name, surname and age of a list of players
        /// </summary>
        /// <param name="input">a list of players</param>
        public static void PrintCondensedPlayersWithAge(List<Player> input)
        {
            // the amount of empty characters given for every value in the table
            List<int> tableSpacing = new List<int> {10, 14, 3};


            PrintIndexedTableLine(tableSpacing, 3, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│{0,-10}│{1,-14}│{2,-3}│",
                "Vardas",
                "Pavardė",
                "Amž"
            );

            PrintIndexedTableLine(tableSpacing, 3, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Player player = input[i];
                Console.WriteLine(
                    "│{0,-10}│{1,-14}│{2,-3}│",
                    player.Name,
                    player.Surname,
                    player.Age
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(tableSpacing, 3, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(tableSpacing, 3, '├', '┼', '┤', '─');
                }
            }
        }

        /// <summary>
        /// prints only the name, surname and height of a list of players
        /// </summary>
        /// <param name="input">a list of players</param>
        public static void PrintCondensedPlayersWithHeight(List<Player> input)
        {
            // the amount of empty characters given for every value in the table
            List<int> tableSpacing = new List<int> {10, 14, 3};


            PrintIndexedTableLine(tableSpacing, 3, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│{0,-10}│{1,-14}│{2,-3}│",
                "Vardas",
                "Pavardė",
                "Au."
            );

            PrintIndexedTableLine(tableSpacing, 3, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Player player = input[i];
                Console.WriteLine(
                    "│{0,-10}│{1,-14}│{2,-3}│",
                    player.Name,
                    player.Surname,
                    player.Height
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(tableSpacing, 3, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(tableSpacing, 3, '├', '┼', '┤', '─');
                }
            }
        }

        /*

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

        }*/

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

        /*
        /// <summary>
        /// outputs a list of classes to a csv file
        /// </summary>
        /// <param name="fileName">the filename to which to output</param>
        /// <param name="classes">the list of classes</param>
        public static void OutputClassesToCSV(string fileName, List<String> classes)
        {
            string[] lines = classes.ToArray();

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }*/

        /// <summary>
        /// outputs a list of players into a csv file
        /// </summary>
        /// <param name="fileName">the filename to which to write</param>
        /// <param name="players">a list of players</param>
        public static void OutputPlayersToCSV(string fileName, List<Player> players)
        {

            List<string> output = new List<string>();

            foreach (Player p in players)
            {
                string line;

                line = String.Format(
                    "{0};{1};{2};{3};{4};{5};{6}",
                    p.Name,
                    p.Surname,
                    p.Age,
                    p.Height,
                    p.Position,
                    p.IsPicked,
                    p.IsCaptain
                );

                output.Add(line);
            }

            File.WriteAllLines(fileName, output.ToArray(), Encoding.UTF8);
        }
    }
}
