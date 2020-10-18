using System;

namespace K1
{
    class Student
    {
        public string StudentName { get; set; }
        public int Credits { get; set; }

        public Student(string studentName, int credits)
        {
            this.StudentName = studentName;
            this.Credits = credits;
        }


        public override string ToString()
        {
            return String.Format("Studentas {0}, trūksta kreditų: {1}", this.StudentName, this.Credits);
        }

    }
}
