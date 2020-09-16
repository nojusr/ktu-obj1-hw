using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1antra_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int sum;

            Console.WriteLine("Įveskite sveikąją a reikšmę");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite sveikąją b reikšmę");
            b = int.Parse(Console.ReadLine());

            sum = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, sum);
        }
    }
}
