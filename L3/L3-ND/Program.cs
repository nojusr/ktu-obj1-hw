using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L3
{
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"> program's arguments </param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // filenames
            string fileName1 = "Duomenys1.txt";
            string fileName2 = "Duomenys2.txt";

            // register initializations
            VehiclesRegister register2 = InOutUtils.ReadVehicles(fileName2);
            VehiclesRegister register1 = InOutUtils.ReadVehicles(fileName1);

            // write out initial data to text
            register1.PrintToTxt("DuomenysPradiniai1.txt");
            register2.PrintToTxt("DuomenysPradiniai2.txt");

            double reg1AvgAge = register1.GetAverageVehicleAge();
            double reg2AvgAge = register2.GetAverageVehicleAge();


            // find and print the regsiter with the oldest cars on average
            if (reg1AvgAge > reg2AvgAge) {
                Console.WriteLine("Pirmame Filiale (registre) yra senesni automobiliai.");
                register1.PrintVehicles();
            } else if (reg1AvgAge == reg2AvgAge){
                Console.WriteLine("Abu filialai (registrai) turi lygiai tokio pačio senumo automobilius.");
            } else {
                Console.WriteLine("Antrame Filiale (registre) yra senesni automobiliai.");
                register2.PrintVehicles();
            }
            Console.Write("\n"); // add some space to distinguish the tasks better

            // find and write to file the matching vehicles in both registers
            VehicleContainer matches = register1.FindMatches(register2);
            InOutUtils.PrintMatchedVehiclesToCSV("Klaidos.csv", register1, register2, matches);


            Console.WriteLine("Pirmas registras:");

            // print out the first register's initial data
            register1.PrintVehicles();
            
            // print out the first register's newest vehicle(s)
            VehicleContainer NewestVehicles = register1.FindNewestVehicles();
            Console.WriteLine("Naujausias(-i) automobilis(-iai):");
            InOutUtils.PrintVehicles(NewestVehicles);
            Console.WriteLine();


            // print out the first register's vehicles that have an expired technical inspection status
            VehicleContainer VehiclesWithExpiredTI = register1.FindVehiclesWithExpiredTI();
            if (VehiclesWithExpiredTI.Count == 0)
            {
                Console.WriteLine("Automobilių su pasibaigusiu T.A. nėra");
                Console.WriteLine();
            }
            else
            {
                InOutUtils.PrintVehiclesToCSV(VehiclesWithExpiredTI, "Apžiūra1.csv");
            }



            Console.WriteLine("Antras registras:");


            // print out the second register's initial data
            register2.PrintVehicles();


            // print out the second register's newest vehicle(s)
            VehicleContainer NewestVehicles2 = register2.FindNewestVehicles();
            Console.WriteLine("Naujausias(-i) automobilis(-iai):");
            InOutUtils.PrintVehicles(NewestVehicles2);
            Console.WriteLine();


            // print out the second register's vehicles that have an expired technical inspection status
            VehicleContainer VehiclesWithExpiredTI2 = register2.FindVehiclesWithExpiredTI();
            if (VehiclesWithExpiredTI2.Count == 0)
            {
                Console.WriteLine("Automobilių su pasibaigusiu T.A. nėra");
                Console.WriteLine();
            }
            else
            {
                InOutUtils.PrintVehiclesToCSV(VehiclesWithExpiredTI2, "Apžiūra2.csv");
            }
        }
    }
}
