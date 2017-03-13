namespace SchoolNew1
{
    using System.Collections.Generic;
    using System.Data.Entity;

    public class SchoolContext : DbContext
    {
        //
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        //
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        //Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuring primary keys, string lengths and requirements
            modelBuilder.Entity<Assignment>().Property(a => a.Name).HasMaxLength(50);
            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Teacher>().Property(t => t.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Teacher>().Property(t => t.LastName).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(s => s.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(50);
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
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}