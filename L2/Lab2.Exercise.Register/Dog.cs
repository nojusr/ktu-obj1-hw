//Dog.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Regular
{
    class Dog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.BirthDate.Year;
            if (this.BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

    }
}
