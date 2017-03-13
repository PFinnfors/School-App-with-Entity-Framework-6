using System.Data.Entity;
using SchoolNew.Classes;

namespace SchoolNew.DataModel
{
    class SchoolContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        //Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuring primary keys, string lengths and requirements
            modelBuilder.Entity<Assignment>().HasKey<int>(a => a.AssignmentId);
            modelBuilder.Entity<Assignment>().Property(a => a.Name).HasMaxLength(50);

            modelBuilder.Entity<Course>().HasKey<int>(c => c.CourseId);
            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(50);

            modelBuilder.Entity<Teacher>().HasKey<int>(t => t.TeacherId);
            modelBuilder.Entity<Teacher>().Property(t => t.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Teacher>().Property(t => t.LastName).HasMaxLength(50);

            modelBuilder.Entity<Student>().HasKey<int>(s => s.StudentId);
            modelBuilder.Entity<Student>().Property(s => s.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(50);
        }
    }
}
