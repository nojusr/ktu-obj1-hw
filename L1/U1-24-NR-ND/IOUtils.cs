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

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

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
            PrintIndexedTableLine(21, 11, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│ {0,-19} │ {1,-19} │ {2,-19} │ {3,-19} │ {4,-19} │ {5, -19} │ {6, -19} │ {7, -19} │ {9, -19} │ {9, -19} │ {10, -19} │",
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

            PrintIndexedTableLine(21, 11, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count; i++)
            {
                Hero hero = input[i];
                Console.WriteLine(
                    "│ {0,-19} │ {1,-19} │ {2,-19} │ {3,-19} │ {4,-19} │ {5, -19} │ {6, -19} │ {7, -19} │ {9, -19} │ {9, -19} │ {10, -19} │",
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
                    hero.Special
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(21, 11, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(21, 11, '├', '┼', '┤', '─');
                }
            }

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


    }
}


