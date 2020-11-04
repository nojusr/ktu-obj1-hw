// VehiclesRegister.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L3
{
    class VehiclesRegister
    {

        public string City {
            get {
                return this.AllVehicles[0].City;
            }
        }

        public string Adress {
            get {
                return this.AllVehicles[0].Address;
            }
        }

        public string PhoneNum {
            get {
                return this.AllVehicles[0].PhoneNum;
            }
        }

        public VehicleContainer AllVehicles;


        public VehiclesRegister()
        {
            AllVehicles = new VehicleContainer();
        }


        public VehiclesRegister(VehicleContainer Vehicles)
        {
            AllVehicles = new VehicleContainer();
            for (int i = 0; i < Vehicles.Count; i++)
            {
                Vehicle vehicle = this.AllVehicles[i];
                this.AllVehicles.Add(vehicle);
            }
        }

        /// <summary>
        /// Method adds a vehicle to the list
        /// </summary>
        /// <param name="vehicle"></param>
        public void Add (Vehicle vehicle)
        {
            AllVehicles.Add(vehicle);
        }


        /// <summary>
        /// Method to print all vehicles to a text file
        /// </summary>
        /// <param name="fileName"></param>
        public void PrintToTxt(string fileName)
        {
            InOutUtils.PrintVehiclesToText(fileName, this.AllVehicles);
        }


        /// <summary>
        /// Method to print all vehicles in the register
        /// </summary>
        public void PrintVehicles()
        {
            Console.WriteLine("UAB „Žaibas {0}“ priklausantys automobiliai:", AllVehicles[0].City);
            InOutUtils.PrintVehicles(this.AllVehicles);
        }



        /// <summary>
        /// Method to find all unique car producers
        /// </summary>
        /// <returns></returns>
        public List<string> FindProducers()
        {
            List<string> producers = new List<string>();
            for (int i = 0; i < this.AllVehicles.Count; i++)
            {
                Vehicle vehicle = this.AllVehicles[i];
                string producer = vehicle.Producer;
                if (!producers.Contains(producer))
                {
                    producers.Add(producer);
                }
            }
            return producers;
        }


        /// <summary>
        /// a method to find all matching vehicles from another VehiclesRegister
        /// </summary>
        /// <param name="other">a vehicle register to which to compare against</param>
        /// <returns>a VehicleContainer that contains all matching vehicles</returns>
        public VehicleContainer FindMatches(VehiclesRegister other)
        {
            VehicleContainer matches = new VehicleContainer();

            VehicleContainer selfContainer = this.AllVehicles;
            VehicleContainer otherContainer = other.AllVehicles;
            
            for (int i = 0; i < selfContainer.Count; i++)
                {
                for (int j = 0; j < otherContainer.Count; j++)
                {
                    if (selfContainer[i].Equals(otherContainer[j]))
                    {
                        matches.Add(selfContainer[i]);
                    }
                }
            }

            return matches;

        }

        /// <summary>
        /// Method creates new list with filtered producers and new segment for counting the quantity of producer's cars
        /// </summary>
        /// <param name="filteredProducers"></param>
        /// <returns></returns>
        public List<Producer> ListOfStringsToProducerObjects(List<string> filteredProducers)
        {
            List<Producer> allProducers = new List<Producer>();
            foreach (string newProducer in filteredProducers)
            {
                Producer producer = new Producer(newProducer, 0);
                allProducers.Add(producer);
            }
            return allProducers;
        }


        /// <summary>
        /// Method to count how many vehicles each producer has
        /// </summary>
        /// <param name="filteredProducers"></param>
        /// <param name="vehicles"></param>
        public List<Producer> CountVehiclesByProducers(List<Producer> filteredProducers)
        {

            for (int i = 0; i < filteredProducers.Count; i++)
            {
                int NumberOfVehicles = CountingOfVehiclesByProducer(filteredProducers[i].ProducerName);
                filteredProducers[i].NumberOfVehicles = NumberOfVehicles;
            }
            return filteredProducers;
        }


        /// <summary>
        /// Method to count how many vehicles a producer has
        /// </summary>
        /// <param name="ProducerName"></param>
        /// <returns></returns>
        public int CountingOfVehiclesByProducer(string ProducerName)
        {
            int NumberOfVehicles = 0;
            for (int i = 0; i < this.AllVehicles.Count; i++)
            {
                Vehicle vehicle = this.AllVehicles[i];
                if (vehicle.Producer == ProducerName)
                {
                    NumberOfVehicles++;
                }
            }
            return NumberOfVehicles;
        }


        /// <summary>
        /// Method to find the highest amount of vehicles made by a single brand
        /// </summary>
        /// <param name="filteredProducers"></param>
        /// <returns>an integer</returns>
        public int HighestNumber(List<Producer> filteredProducers)
        {
            int highestNumber = 0;
            foreach (Producer producer in filteredProducers)
            {
                if (highestNumber < producer.NumberOfVehicles)
                    highestNumber = producer.NumberOfVehicles;
            }
            return highestNumber;
        }


        /// <summary>
        /// Method to find a list of the newest vehicles
        /// </summary>
        /// <returns></returns>
        public VehicleContainer FindNewestVehicles()
        {

            VehicleContainer NewestVehicles = new VehicleContainer();

            for (int i = 0; i < this.AllVehicles.Count; i++)
            {

                if (NewestVehicles.Count == 0)
                {
                    NewestVehicles.Add(this.AllVehicles[i]);
                    continue;
                }

                Vehicle vehicleToCompare = NewestVehicles[0];

                if (this.AllVehicles[i] < vehicleToCompare)
                {
                    NewestVehicles.Clear();
                    NewestVehicles.Add(this.AllVehicles[i]);
                }
                else if (this.AllVehicles[i].Age == vehicleToCompare.Age)
                {
                    NewestVehicles.Add(this.AllVehicles[i]);
                }
            }
            return NewestVehicles;
        }

        /// <summary>
        /// calculates the average age of all the vehicles in this register
        /// </summary>
        /// <returns>a double which gives the average age in years (i assume)</returns>
        public double GetAverageVehicleAge()
        {
            double output = 0.0;

            double sum = 0.0;

            for (int i = 0; i < this.AllVehicles.Count; i++)
            {
                sum += (double)this.AllVehicles[i].Age;
            }

            output = sum/(double)this.AllVehicles.Count;

            return output;
        }


        /// <summary>
        /// Method to find vehicles with an expired technical inspection and add them to a list
        /// </summary>
        /// <returns>a VehicleContainer that contains all vehicles with their expired TI</returns>
        public VehicleContainer FindVehiclesWithExpiredTI()
        {

            VehicleContainer VehiclesWithExpiredTI = new VehicleContainer();

            DateTime Today = DateTime.Today;
            for (int i = 0; i < this.AllVehicles.Count; i++)
            {
                Vehicle vehicle = this.AllVehicles[i];
                if(Today.Year > vehicle.TechnicalInspection.Year)
                {
                    vehicle.TechnicalInspection = Convert.ToDateTime("1111/1/1");
                    VehiclesWithExpiredTI.Add(vehicle);
                }
                else if (vehicle.TechnicalInspection.Year == Today.Year && vehicle.TechnicalInspection.Month - vehicle.TechnicalInspection.Month <= 1)
                {
                    VehiclesWithExpiredTI.Add(vehicle);
                }
            }


            VehiclesWithExpiredTI.SortWithDelegate((left, right) => {
                
                if (left.Producer.CompareTo(right.Producer) > 0)
                {
                    return 1;
                } else if (left.Producer.CompareTo(right.Producer) < 0)
                {
                    return -1;
                }

                // producer names are equal, sort by model next
                if (left.Model.CompareTo(right.Model) > 0)
                {
                    return 1;
                } else if (left.Model.CompareTo(right.Model) < 0)
                {
                    return -1;
                }

                // model names are equal, sort by ID
                if (left.LicensePlate.CompareTo(right.LicensePlate) > 0)
                {
                    return 1;
                } else if (left.LicensePlate.CompareTo(right.LicensePlate) < 0)
                {
                    return -1;
                }
                
                return 0; // vehicles are identical

            });

            //VehiclesWithExpiredTI.Sort();


            return VehiclesWithExpiredTI;
        }
    }
}