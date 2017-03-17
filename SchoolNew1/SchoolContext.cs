namespace SchoolNew1
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;

    public class SchoolContext : DbContext
    {
        //
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        //
        public DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        //Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuring primary keys, string lengths and requirements
            modelBuilder.Entity<Assignment>().Property(a => a.Name).HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Assignment>().Property(a => a.Description).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(25);
            modelBuilder.Entity<Teacher>().Property(t => t.FirstName).HasMaxLength(25);
            modelBuilder.Entity<Teacher>().Property(t => t.LastName).HasMaxLength(25);
            modelBuilder.Entity<Student>().Property(s => s.FirstName).HasMaxLength(25);
            modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(25);
        }
    }

    public class Teacher
    {
        //Primary key
        public int TeacherId { get; set; }

        //Teacher first name
        public string FirstName { get; set; }

        //Teacher last name
        public string LastName { get; set; }

        //--NAV----------------------------------------------------
        //Teaching which courses
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Student
    {
        //Primary key
        public int StudentId { get; set; }

        //Student first name
        public string FirstName { get; set; }

        //Student last name
        public string LastName { get; set; }

        //--NAV----------------------------------------------------
        //Signed up for what courses
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        //Primary key
        public int CourseId { get; set; }

        //Course name
        public string Name { get; set; }

        //--NAV----------------------------------------------------
        //Teachers in this course
        public virtual ICollection<Teacher> Teachers { get; set; }

        //Students in this course
        public virtual ICollection<Student> Students { get; set; }

        //Assignments in this course
        public ICollection<Assignment> Assignments { get; set; }
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

        //-NAV----------------------------------------------------
        //Part of what course
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}