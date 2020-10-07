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

        /// <summary>
        /// a method to represent a player object with a string
        /// </summary>
        /// <returns>a string that describes a player</returns>
        public override string ToString()
        {
            return String.Format(
                "Žaidėjas: {0} {1}, Metai: {2}, Aukštis: {3}, Pozicija: {4}, Klubas: {5}, Ar parinktas: {6}, Ar kapitonas: {7}, Stovyklos pradžia: {8}, Stovyklos pabaiga: {9}",
                this.Name,
                this.Surname,
                this.Age,
                this.Height,
                this.Position,
                this.Club,
                this.IsPicked,
                this.IsPicked,
                this.startDate.ToShortDateString(),
                this.endDate.ToShortDateString()
            );
        }

        /// <summary>
        /// compares this object to any other object
        /// </summary>
        /// <param name="other">object to compare against</param>
        /// <returns>True if other is equal to this object; False if object isn't equal.</returns>
        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != this.GetType())
            {
                return false;
            }

            if (((Player)other).GetHashCode() != this.GetHashCode())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// a rudimentary hashing method of this class
        /// </summary>
        /// <returns>an integer hash of this class</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            string hString = String.Format(
                "{0}{1}{2}{3}{4}{5}",
                this.Name,
                this.Surname,
                this.Position,
                this.Club,
                this.startDate.ToShortDateString(),
                this.endDate.ToShortDateString()
            ); 


            foreach (char c in hString)
            {
                hash += (int)c;
            }

            hash += this.Age + this.Height;

            if (this.IsPicked) {
                hash += 5;
            }
            if (this.IsCaptain) {
                hash += 7;
            }

            return hash;
        }



        // overloading the operators below in such a manner (making them compare by only a single class attribute)
        // is, in my opinion, terrible practice. Now, every time someone tries to compare two
        // Player classes directly, they will get weird, undocumented behaviour that
        // will be really confusing to debug. I only did this because it was explicitly stated that the program
        // required operator overloading.

        /// <summary>
        /// overwritten > operator to use this class's height as the attribute to compare against
        /// </summary>
        public static bool operator >(Player p1, Player p2)
        {
            if (p1.Height > p2.Height) {
                return true;
            }
            return false;
        }


        /// <summary>
        /// overwritten < operator to use this class's height as the attribute to compare against
        /// </summary>
        public static bool operator <(Player p1, Player p2)
        {
            if (p1.Height < p2.Height) {
                return true;
            }
            return false;
        }


        /// <summary>
        /// overwritten equality operator to use this class's height as the attribute to compare against
        /// </summary>
        public static bool operator ==(Player p1, Player p2)
        {
            if (p1.Height == p2.Height) {
                return true;
            }
            return false;
        }
        

        /// <summary>
        /// overwritten != operator to use this class's height as the attribute to compare against
        /// </summary>
        public static bool operator !=(Player p1, Player p2)
        {
            if (p1.Height != p2.Height) {
                return true;
            }
            return false;
        }


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
