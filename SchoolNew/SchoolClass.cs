using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolNew.Classes
{
    public class Teacher
    {
        //Primary key
        public int TeacherId { get; set; }

        //Teacher first name
        public string FirstName { get; set; }

        //Teacher last name
        public string LastName { get; set; }

        //--FK----------------------------------------------------
        //Teaching which courses
        public ICollection<Course> Courses { get; set; }
    }

    public class Student
    {
        //Primary key
        public int StudentId { get; set; }

        //Student first name
        public string FirstName { get; set; }

        //Student last name
        public string LastName { get; set; }

        //--FK----------------------------------------------------
        //Signed up for what courses
        public List<Course> Courses { get; set; }
    }

    public class Course
    {
        //Primary key
        public int CourseId { get; set; }

        //Course name
        public string Name { get; set; }

        //--FK----------------------------------------------------
        //Assignments in this course
        public List<Teacher> Teachers { get; set; }

        //Students in this course
        public List<Student> Students { get; set; }

        //Assignments in this course
        public List<Assignment> Assignments { get; set; }
    }

    public class Assignment
    {
        public Assignment()
        {
            Course = new Course();
        }

        //Primary key
        public int AssignmentId { get; set; }

        //Assignment name
        public string Name { get; set; }

        //Assignment description
        public string Description { get; set; }

        //--FK----------------------------------------------------
        //Part of what course
        public virtual Course Course { get; set; }
    }
}
