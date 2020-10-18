using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L3
{
    class VehiclesRegister
    {

        private VehicleContainer AllVehicles;

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
        /// Method prints startting data to txt file
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
        /// Method  to find all unique car producers
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
        /// Method counts how many vehicles each producer has
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
        /// Method counts how many vehicles a producer has
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
                Vehicle vehicle = this.AllVehicles[i];
                if (vehicle.Age == NewestVehicleDate().Age)
                {
                    NewestVehicles.Add(vehicle);
                }
            }
            return NewestVehicles;
        }


        /// <summary>
        /// Method to find the newest vehicle
        /// </summary>
        /// <returns></returns>
        private Vehicle NewestVehicleDate()
        {
            Vehicle NewestVehicle = AllVehicles[0];
            for (int i = 0; i < this.AllVehicles.Count; i++)
            {
                Vehicle vehicle = this.AllVehicles[i];
                if (vehicle < NewestVehicle)
                {
                    NewestVehicle = vehicle;
                }
            }
            return NewestVehicle;
        }


        /// <summary>
        /// Method to find vehicles with an expired technical inspection and add them to a list
        /// </summary>
        /// <returns></returns>
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
            return VehiclesWithExpiredTI;
        }
    }
}