using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1.Exercises.Register
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

    }
}
