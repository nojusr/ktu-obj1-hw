using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1antra_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pi = 3.1415; // math. constant
            double H;                 // height of cone
            double R, r;              // base radii of cone
            double V;                 // volume

            // input handling
            Console.WriteLine("Įveskite kūgio aukštinės reikšmę");
            H = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kūgio viršutinio pagrindo spindulio reikšmę");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kūgio apatinio pagrindo spindulio reikšmę");
            R = double.Parse(Console.ReadLine());

            // main calc for volume
            V = (1.0 / 3) * pi * H * (R * R + R * r + r * r);
            
            // output
            Console.WriteLine("Kūgio tūris = {0, 5:f}", V);

        }
    }
}
