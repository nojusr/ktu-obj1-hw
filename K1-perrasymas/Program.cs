//Program.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace K1_perrasymas
{
    class Program
    {
        static void Main(string[] args)
        {
            // clean up the output file
            File.WriteAllText("Result.txt", String.Empty);


            List<Course> courses = InOut.ReadCourseData("Course.txt");
            List<Student> students = InOut.ReadStudentData("Student.txt");

            StudyPlan studyPlan = new StudyPlan(courses);


            InOut.Print(students, "Result.txt", "Pradiniai duomenys:\nStudentai:");
            InOut.Print(studyPlan, "Result.txt", "Kursai:");


            List<Course> studentChoices = new List<Course>();

            // temporary list
            List<Course> tmp = new List<Course>();

            foreach (Student stud in students)
            {
                tmp.Clear();

                for (int i = 0; i < studyPlan.GetCount(); i++)
                {
                    Course c = studyPlan.GetEntry(i);

                    if (c.Credits == stud.Credits)
                    {
                        tmp.Add(c);
                    }
                }


                Course highest = tmp[0];

                for (int i = 1; i < tmp.Count; i++)
                {

                    if (highest >= tmp[i])
                    {
                        highest = tmp[i];
                    }
                }

                Course choice = studyPlan.GetEntry(studyPlan.MaxHoursIndex(highest));
                studentChoices.Add(studyPlan.GetEntry(studyPlan.MaxHoursIndex(highest)));

                tmp.Clear();
                tmp.Add(choice);
                studyPlan.AddChoice(tmp);
            }

            InOut.Print(studentChoices, students, "Result.txt", "\nAtrinkti moduliai:\n");



        }
    }

    class StudyPlan
    {
        

        public List<Course> Courses;

        public StudyPlan()
        {
            this.Courses = new List<Course>();
        }

        public StudyPlan(List<Course> courses)
        {

            if (this.Courses == null)
            {
                this.Courses = new List<Course>();
            }

            this.Courses.AddRange(courses);
        }


        public int GetCount() {
            return this.Courses.Count;
        }


        public void AddEntry(Course course)
        {
            this.Courses.Add(course);
        }

        public Course GetEntry(int index)
        {
            return this.Courses[index];
        }


        public int MaxHoursIndex(Course course)
        {
        

            Course highest = this.Courses[0];

            for (int i = 1; i < this.Courses.Count; i++)
            {
                if (highest >= this.Courses[i])
                {
                    highest = this.Courses[i];
                }
            }

            int index = this.Courses.IndexOf(course);

            return index;
        }

        public void AddChoice(List<Course> studentChoice)
        {
            foreach (Course c in studentChoice)
            {
                int index = this.Courses.IndexOf(c);
                this.Courses[index].FreeNumber -= 1;
            }
        }

        public double Average()
        {
            double hoursum = 0.0;

            foreach (Course course in this.Courses)
            {
                hoursum += (double)course.Hours;
            }

            return hoursum/(double)this.GetCount();

        }
    }

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

        public Course()
        {
            this.CourseName = "";
            this.Credits = 0;
            this.Hours = 0;
            this.FreeNumber = 0;
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


    class InOut
    {

        static public List<Course> ReadCourseData(string fileName)
        {
            List<Course> output = new List<Course>();

            string[] lines = new string[150];

            // file error handling
            if (!System.IO.File.Exists(fileName)) {
                Console.WriteLine("Course.txt nerastas, programa stabdoma.");
                Environment.Exit(1);
            }

            lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] split = line.Split(";");


                Course courseToAdd = new Course(
                    split[0],
                    int.Parse(split[1]),
                    int.Parse(split[2]),
                    int.Parse(split[3])
                );

                output.Add(courseToAdd);

            }

            return output;
        }


        static public List<Student> ReadStudentData(string fileName)
        {
            List<Student> output = new List<Student>();

            string[] lines = new string[150];

            // file error handling
            if (!System.IO.File.Exists(fileName)) {
                Console.WriteLine("Student.txt nerastas, programa stabdoma.");
                Environment.Exit(1);
            }

            lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] split = line.Split(";");

                Student studentToAdd = new Student(split[0], int.Parse(split[1]));

                output.Add(studentToAdd);

            }

            return output;
        }

        static public void PrintStudents(List<Student> students)
        {
            foreach(Student stud in students)
            {
                Console.WriteLine(stud);
            }
        }

        static public void PrintCourses(List<Course> courses)
        {
            foreach(Course course in courses)
            {
                Console.WriteLine(course);
            }
        }


        public static void Print(StudyPlan allCourses, string fileName, string header)
        {
            List<string> output = new List<string>();

            output.Add(header);

            foreach(Course course in allCourses.Courses)
            {
                output.Add(course.ToString());
            }

            output.Add(String.Format("\nVidutinis valandų kiekis: {0:000.00}\n", allCourses.Average()));


            File.AppendAllLines(fileName, output.ToArray(), Encoding.UTF8);
        }

        public static void Print(List<Student> students, string fileName, string header)
        {
            List<String> output = new List<String>();

            output.Add(header);

            foreach (Student s in students)
            {
                output.Add(s.ToString());
            }

            File.AppendAllLines(fileName, output.ToArray(), Encoding.UTF8);
        }

        public static void Print(List<Course> studentChoices, List<Student> students,  string fileName, string header)
        {
            List<string> output = new List<string>();

            output.Add(header);

            output.Add("┌────────────┬─────────────┐");
            output.Add("│Stud. vardas│Kurso pav.   │");
            output.Add("├────────────┼─────────────┤");

            for(int i = 0; i < students.Count; i++)
            {
                output.Add(String.Format("│{0,-12}│{1,-13}│", students[i].StudentName, studentChoices[i].CourseName));
            }
            output.Add("└────────────┴─────────────┘");

            File.AppendAllLines(fileName, output.ToArray(), Encoding.UTF8);
            
        }

    }
}
