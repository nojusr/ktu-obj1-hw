//IOUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace K1
{
    class IOUtils
    {
        static public List<Student> ReadStudentData (string fileName)
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

        static public List<Course> ReadCourseData (string fileName)
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

            output.Add(String.Format("\n Vidutinis valandų kiekis: {0}", allCourses.Average()));


            File.WriteAllLines(fileName, output.ToArray(), Encoding.UTF8);
        }

        public static void Print(List<Course> studentChoices, List<Student> students,  string fileName, string header)
        {
            List<string> output = new List<string>();

            output.Add(header);

            for(int i = 0; i < students.Count; i++)
            {
                output.Add(String.Format("{0} buvo parinktas {1}", students[i].StudentName, studentChoices[i].CourseName));
            }


            File.AppendAllLines(fileName, output.ToArray(), Encoding.UTF8);
            
        }

    }
}
