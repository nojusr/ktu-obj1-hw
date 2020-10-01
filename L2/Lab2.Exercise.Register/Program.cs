//Program.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Regular
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Dog> AllDogs = IOUtils.ReadDogs(@"dogs.csv");

            //DogRegister reg = new DogRegister(AllDogs);

            
            IOUtils.PrintDogs(AllDogs);
        }
    }
}
