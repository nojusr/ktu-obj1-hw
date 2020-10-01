//IOUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Regular
{
    static class IOUtils
    {
        public static List<Dog> ReadDogs(string fileName)
        {

            List<Dog> output = new List<Dog>();

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
                int id = int.Parse(values[0]);
                string name = values[1];
                string breed = values[2];
                DateTime birthDate = DateTime.Parse(values[3]);
                Gender gender;
                Enum.TryParse(values[4], out gender); //tries to convert value to enum

                Dog dogToAppend;

                dogToAppend = new Dog(
                    id,
                    name,
                    breed,
                    birthDate,
                    gender
                );

                output.Add(dogToAppend);

            }



            return output;

        }


        public static void PrintDogs(List<Dog> input)
        {

            PrintIndexedTableLine(17, 5, '┌', '┬', '┐', '─');

            Console.WriteLine(
                "│ {0,-15} │ {1,-15} │ {2,-15} │ {3,-15:yyyy-MM-dd} │ {4,-15} │",
                "Reg. Nr.",
                "Vardas",
                "Veislė",
                "Gimimo data",
                "Lytis"
            );

            PrintIndexedTableLine(17, 5, '├', '┼', '┤', '─');

            for (int i = 0; i < input.Count(); i++) {

                Dog dog = input[i];

                Console.WriteLine(
                    "│ {0,-15} │ {1,-15} │ {2,-15} │ {3,-15:yyyy-MM-dd} │ {4,-15} │",
                    dog.ID,
                    dog.Name,
                    dog.Breed,
                    dog.BirthDate,
                    dog.Gender
                );

                if (i == input.Count - 1)
                {
                    PrintIndexedTableLine(17, 5, '└', '┴', '┘', '─');
                }
                else
                {
                    PrintIndexedTableLine(17, 5, '├', '┼', '┤', '─');
                }

            }

        }

        // print a list of strings
        public static void PrintList(List<string> input)
        {
            foreach (string item in input)
            {
                Console.WriteLine(item);
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

        public static void PrintDogsToCSV(string fileName, List<Dog> input)
        {
            string[] lines = new string[input.Count + 1];
            lines[0] = String.Format(
                "{0};{1};{2};{3};{4}",
                "Reg. Nr.",
                "Vardas",
                "Veislė",
                "Gimimo data",
                "Lytis"
            );

            for (int i = 0; i < input.Count; i++)
            {
                lines[i+1] = String.Format(
                    "{0};{1};{2};{3:yyyy-mm-dd};{4}",
                    input[i].ID,
                    input[i].Name,
                    input[i].Breed,
                    input[i].BirthDate,
                    input[i].Gender
                );
            }

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }


    }
}
