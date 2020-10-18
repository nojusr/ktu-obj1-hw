using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace L3
{
    /// <summary>
    /// Class containing reading and priniting methods
    /// </summary>
    static class InOutUtils
    {
        /// <summary>
        /// the method that reads the data from a file
        /// </summary>
        /// <param name="fileName"> input filename </param>
        /// <returns>a vehicleRegister</returns>
        public static VehiclesRegister ReadVehicles(string fileName)
        {

            string[] lines = new string[150];

            VehiclesRegister output = new VehiclesRegister();

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

            string city = lines[0];
            string address = lines[1];
            string phoneNum = lines[2];

            for (int i = 3; i < lines.Length; i++)
            {
                string line = lines[i];

                // basic support for comments
                // if a line in the input file starts with
                // '//', then ignore the line and move on
                if (line.StartsWith("//"))
                {
                    continue;
                }

                string[] values = line.Split(';');

                Vehicle vehicleToAdd = new Vehicle(
                    values[0],
                    values[1],
                    values[2],
                    int.Parse(values[3]),
                    int.Parse(values[4]), 
                    DateTime.Parse(values[5]),
                    values[6],
                    double.Parse(values[7]),
                    city,
                    address,
                    phoneNum
                );

                output.Add(vehicleToAdd);
            }

            return output;
        }

        public static void PrintVehiclesByProducer(VehiclesRegister register)
        {
            List<String> output = CreateVehiclesByProducerTable(register);
            Console.WriteLine(String.Join("\n", output));
        }


        /// <summary>
        /// Method prints the most common producer(s)
        /// </summary>
        /// <param name="allVehicles"></param>
        public static List<String> CreateVehiclesByProducerTable(VehiclesRegister register)
        {

            List<int> tableSpacing = new List<int> {16, 18};

            string topstr = CreateIndexedTableLine(tableSpacing, 2, '┌', '┬', '┐', '─');
            string midstr = CreateIndexedTableLine(tableSpacing, 2, '├', '┼', '┤', '─');
            string botstr = CreateIndexedTableLine(tableSpacing, 2, '└', '┴', '┘', '─');

            List<String> output = new List<String>();

            List<string> producers = register.FindProducers();
            List<Producer> filteredProducersWithNumberOfCars = register.ListOfStringsToProducerObjects(producers);
            List<Producer> filteredProducers = register.CountVehiclesByProducers(filteredProducersWithNumberOfCars);
            int HighestNumber = register.HighestNumber(filteredProducers);


            output.Add("Daugiausiai automobilių turi: ");

            output.Add(topstr);

            output.Add(String.Format(
                "│{0,-16}│{1,-18}│",
                "Gamintojas(-ai)",
                "Automobilių kiekis"
            ));

            output.Add(midstr);

            foreach (Producer producer in filteredProducers) //searching producer with the most vehicles
            {
                if (producer.NumberOfVehicles == HighestNumber)
                {
                    output.Add(String.Format(
                        "│{0,-16}│{1,-18}│",
                        producer.ProducerName, 
                        producer.NumberOfVehicles
                    ));
                }
            }

            output.Add(botstr);

            return output;

        }


        /// <summary>
        /// Outputs a list of vehicles to the console
        /// </summary>
        /// <param name="Vehicles">a list of vehicles</param>
        public static void PrintVehicles(VehicleContainer vehicles)
        {
            List<String> output = CreateVehicleTable(vehicles);
            Console.WriteLine(String.Join("\n", output));
        }

        /// <summary>
        /// Outputs a list of vehicles to a text file
        /// </summary>
        /// <param name="fileName">the name of the text file to which to output</param>
        /// <param name="vehicles">a list of vehicles</param>
        public static void PrintVehiclesToText(string fileName, VehicleContainer vehicles)
        {
            List<String> output = CreateVehicleTable(vehicles);
            File.WriteAllLines(fileName, output.ToArray(), Encoding.UTF8);
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
        private static string CreateIndexedTableLine(List<int> spacing, int columnCount, char leftEdge, char middleEdge, char rightEdge, char line)
        {

            string output = "";

            output += leftEdge;

            for (int i = 0; i < columnCount; i++) {

                output += new string(line, spacing[i]);

                if (i == columnCount - 1)
                {
                    output += rightEdge;
                }
                else
                {
                    output += middleEdge;
                }
            }

            return output;
        }

        /// <summary>
        /// creates a string-based table of vehicles,
        /// used in both console output and text output
        /// </summary>
        /// <returns>list of strings</returns>
        private static List<String> CreateVehicleTable(VehicleContainer vehicles)
        {
            List<String> output = new List<String>();

            // the amount of empty characters given for every value in the table
            List<int> tableSpacing = new List<int> {7, 12, 8, 5, 4, 15, 10, 12};

            string topstr = CreateIndexedTableLine(tableSpacing, 8, '┌', '┬', '┐', '─');
            string midstr = CreateIndexedTableLine(tableSpacing, 8, '├', '┼', '┤', '─');
            string botstr = CreateIndexedTableLine(tableSpacing, 8, '└', '┴', '┘', '─');


            output.Add(topstr);

            output.Add(String.Format(
                "│{0,-7}│{1,-12}│{2,-8}│{3,-5}│{4,-4}│{5,-15}│{6,-10}│{7,-12}│",
                "Val. ID",
                "Gamintojas",
                "Modelis",
                "Metai",
                "Mėn.",
                "T.A. gal. data",
                "Kuras",
                "Vid. sąnaud."
            ));

            output.Add(midstr);

            for (int i = 0; i < vehicles.Count; i++)
            {
                Vehicle vehicle = vehicles[i];

                output.Add(String.Format(
                    "│{0,-7}│{1,-12}│{2,-8}│{3,-5}│{4,-4}│{5,-15}│{6,-10}│{7,-12}│",
                    vehicle.LicensePlate,
                    vehicle.Producer,
                    vehicle.Model,
                    vehicle.YearOfProduction,
                    vehicle.MonthOfProduction,
                    vehicle.TechnicalInspection.ToShortDateString(),
                    vehicle.Fuel,
                    vehicle.AverageFuelConsumption
                ));

            }

            output.Add(botstr);

            return output;

        }


        /// <summary>
        /// Method to print vehicles to a CSV file
        /// </summary>
        /// <param name="Vehicles"></param>
        /// <param name="fileName"></param>
        public static void PrintVehiclesToCSV (VehicleContainer Vehicles, string fileName)
        {
            string[] lines = new string[Vehicles.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7}",
                "Valstybinis numeris", 
                "Gamintojas",
                "Modelis",
                "Pagaminimo metai",
                "Pagaminimo mėnuo",
                "T.A. galiojimo data",
                "Kuras",
                "Vid. sąnaudos"
            );


            for (int i = 1; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].TechnicalInspection == Convert.ToDateTime("1111/1/1"))
                {
                    lines[i] = String.Format(
                        "{0};{1};{2};{3};{4};{5};{6};{7:f}",
                        Vehicles[i].LicensePlate, 
                        Vehicles[i].Producer,
                        Vehicles[i].Model,
                        Vehicles[i].YearOfProduction,
                        Vehicles[i].MonthOfProduction,
                        "SKUBIAI",
                        Vehicles[i].Fuel,
                        Vehicles[i].AverageFuelConsumption
                    );
                }
                else
                {
                    lines[i] = String.Format(
                        "{0};{1};{2};{3};{4};{5:yyyy-MM-dd};{6};{7:f}",
                        Vehicles[i].LicensePlate, 
                        Vehicles[i].Producer,
                        Vehicles[i].Model,
                        Vehicles[i].YearOfProduction,
                        Vehicles[i].MonthOfProduction,
                        Vehicles[i].TechnicalInspection,
                        Vehicles[i].Fuel,
                        Vehicles[i].AverageFuelConsumption
                    );
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }


        public static void PrintMatchedVehiclesToCSV(string fileName, VehiclesRegister left, VehiclesRegister right, VehicleContainer matches)
        {

            if (matches.Count <= 0)
            {
                return;
            }

            string[] lines = new string[matches.Count+2];

            lines[0] = left.City;
            lines[1] = right.City;

            for (int i = 0; i < matches.Count; i++)
            {
                int lineIndex = i+2;

                lines[lineIndex] = String.Format(
                    "{0};{1}",
                    matches[i].LicensePlate,
                    matches[i].Model
                );
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
