using System;

namespace L2_ND
{
    class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public bool IsPicked { get; set; }
        public bool IsCaptain { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        


        public Player(string name, string surname, int age, int height, string position, string club, bool isPicked, bool isCaptain, DateTime start, DateTime end) {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Height = height;
            this.Position = position;
            this.Club = club;
            this.IsPicked = isPicked;
            this.IsCaptain = isCaptain;
            this.startDate = start;
            this.endDate = end;
        }

    }
}
