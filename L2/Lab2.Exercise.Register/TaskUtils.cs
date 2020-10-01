//TaskUtils.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2.Exercises.Regular
{
    class TaskUtils
    {
        // get amount of dogs by gender
        public static int CountByGender(List<Dog> input, Gender gender)
        {
            int output = 0;
            foreach (Dog dog in input)
            {
                if (dog.Gender.Equals(gender))
                {
                    output++;
                }
            }

            return output;

        }

        // get the oldest dog when given a list of dogs
        public static Dog FindOldestDog(List<Dog> input)
        {
            // get the first dog in [input]...
            Dog output = input[0];

            // ...and start the search loop from 1
            for (int i = 1; i < input.Count; i++ )
            {
                if (DateTime.Compare(output.BirthDate, input[i].BirthDate) > 0)
                {
                    output = input[i];
                }
            }

            return output;
        }

        public static List<string> FindUniqueBreeds(List<Dog> input)
        {
            List<string> breeds = new List<string>();
            foreach(Dog dog in input)
            {
                string breed = dog.Breed;
                if (breeds.Contains(breed) == false)
                {
                    breeds.Add(breed);
                }
            }
            return breeds;
        }

        public static List<Dog> FilterByBreed(List<Dog> input, string breed)
        {
            List<Dog> output = new List<Dog>();

            foreach(Dog dog in input)
            {
                if (dog.Breed.Equals(breed))
                {
                    output.Add(dog);
                }
            }
            return output;
        }

        public static string FindMostPopularBreed(List<Dog> input)
        {
            // a dictionary is a list whose index and stored value can be an arbitrary type
            IDictionary<string, int> dogCountByBreed = new Dictionary<string, int>();

            // get the amount of dogs by breed
            foreach (Dog dog in input)
            {
                if (dogCountByBreed.ContainsKey(dog.Breed))
                {
                    dogCountByBreed[dog.Breed] += 1;
                }
                else
                {
                    dogCountByBreed[dog.Breed] = 1;
                }
            }


            // search for the item with the biggest number in the dict
            string breed = "";
            int count = -1;

            foreach (string key in dogCountByBreed.Keys)
            {
                if (dogCountByBreed[key] > count)
                {
                    breed = key;
                    count = dogCountByBreed[key];
                }
            }

            return breed;
        }
    }
}
