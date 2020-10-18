using System;

namespace L3
{
    /// <summary>
    /// class defining list (Vehicle) variables
    /// </summary>
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int MonthOfProduction { get; set; }
        public DateTime TechnicalInspection { get; set; }
        public string Fuel { get; set; }
        public double AverageFuelConsumption { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public Vehicle(string licensePlate, string producer, string model, int yearOfProduction, int monthOfProduction,
                        DateTime technicalInspection, string fuel, double averageFuelConsumption, 
                        string city, string address, string phoneNum)
        {
            this.LicensePlate = licensePlate;
            this.Producer = producer;
            this.Model = model;
            this.YearOfProduction = yearOfProduction;
            this.MonthOfProduction = monthOfProduction;
            this.TechnicalInspection = technicalInspection;
            this.Fuel = fuel;
            this.AverageFuelConsumption = averageFuelConsumption;
            this.City = city;
            this.Address = address;
            this.PhoneNum = phoneNum;
        }
        /// <summary>
        /// Used for finding the age of the vehicles
        /// </summary>
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year * 12 + DateTime.Today.Month - this.YearOfProduction * 12 - this.MonthOfProduction;
                return age;
            }
        }
        public override bool Equals(object other)
        {
            Vehicle vehicle = other as Vehicle;
            return this.LicensePlate == vehicle.LicensePlate;
        }
        public override int GetHashCode()
        {
            return this.LicensePlate.GetHashCode();
        }
        public static bool operator >(Vehicle vehicle1, Vehicle vehicle2) {
            return vehicle1.Age > vehicle2.Age;
                }
        public static bool operator <(Vehicle vehicle1, Vehicle vehicle2) {
            return vehicle1.Age < vehicle2.Age;
        }
    }
}