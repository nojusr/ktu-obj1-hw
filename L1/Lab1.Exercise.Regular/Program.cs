//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            // read
            List<Dog> dogs = IOUtils.ReadDogs(@"dogs.csv");

            // output all dogs
            IOUtils.PrintDogs(dogs);

            // output amount of dogs
            Console.WriteLine("Iš viso šunų: {0}", dogs.Count());

            // output amount of dogs by gender
            Console.WriteLine("Patinų: {0}", TaskUtils.CountByGender(dogs, Gender.Male));
            Console.WriteLine("Patelių: {0}", TaskUtils.CountByGender(dogs, Gender.Female));

            Dog oldest = TaskUtils.FindOldestDog(dogs);
            Console.WriteLine("Seniausias šuo:");
            Console.WriteLine(
                "Vardas: {0}, Veislė: {1}, Amžius: {2}",
                oldest.Name,
                oldest.Breed,
                oldest.CalculateAge()
            );

            // print out unique dog breeds
            Console.WriteLine("Šunų veislės: ");
            IOUtils.PrintList(TaskUtils.FindUniqueBreeds(dogs));

            // handle dog breed input
            Console.WriteLine("Kokias veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();

            // generate and print out a list of dogs by breed
            List<Dog> filteredDogs = TaskUtils.FilterByBreed(dogs, selectedBreed);
            IOUtils.PrintDogs(filteredDogs);

            // output to file
            string fileName = selectedBreed + ".csv";
            IOUtils.PrintDogsToCSV(fileName, filteredDogs);

            // output the oldest dog from [filteredDogs]
            Dog oldestBreed = TaskUtils.FindOldestDog(filteredDogs);
            Console.WriteLine("Seniausias šuo kuris priklauso \"{0}\" veislėi:", selectedBreed);
            Console.WriteLine(
                "Vardas: {0}, Veislė: {1}, Amžius: {2}",
                oldestBreed.Name,
                oldestBreed.Breed,
                oldestBreed.CalculateAge()
            );

            string mostPopBreed = TaskUtils.FindMostPopularBreed(dogs);

            Console.WriteLine("Populiariausia šūnų veislė: {0}", mostPopBreed);


        }
    }
}
