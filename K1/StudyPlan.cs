//StudyPlan.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace K1
{
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

        public Course GetEntry(int index)
        {
            return this.Courses[index];
        }

        public void AddEntry(Course course)
        {
            this.Courses.Add(course);
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


        public List<Course> pickChoicesForStudents(List<Student> students)
        {

            List<Course> output = new List<Course>();

            foreach (Student stud in students)
            {
                output.Add(this.Courses[this.MaxHoursIndex(stud.Credits)]);
            }

            return output;
        }

        public int MaxHoursIndex(int credits)
        {

            List<Course> tmp = new List<Course>();


            // filter out all courses that dont have the right amount of credits
            foreach(Course c in this.Courses)
            {
                if (c.Credits == credits)
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

            int index = this.Courses.FindIndex(highest);

            this.Courses[index].FreeNumber -= 1;

            return index;
            

        }

    }
}
