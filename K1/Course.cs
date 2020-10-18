using System;

namespace K1
{
    class Course
    {
        public string CourseName { get; set;}
        public int Credits { get; set; }
        public int Hours { get; set; }
        public int FreeNumber { get; set; }

        public Course(string courseName, int credits, int hours, int freeNumber)
        {
            this.CourseName = courseName;
            this.Credits = credits;
            this.Hours = hours;
            this.FreeNumber = freeNumber;
        }


        public override string ToString()
        {
            return String.Format(
                "Modulis {0}, kreditai: {1}, valandų skaičius: {2}, laisvos vietos: {3}",
                this.CourseName,
                this.Credits,
                this.Hours,
                this.FreeNumber
            );
        }

        public static bool operator >=(Course lhs, Course rhs)
        {
            if (lhs.FreeNumber > 0 && rhs.FreeNumber > 0)
            {
                return lhs.Credits >= rhs.Credits;
            }
            else if (lhs.FreeNumber > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }


        public static bool operator <=(Course lhs, Course rhs)
        {
            if (lhs.FreeNumber > 0 && rhs.FreeNumber > 0)
            {
                return lhs.Credits <= rhs.Credits;
            }
            else if (lhs.FreeNumber > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
