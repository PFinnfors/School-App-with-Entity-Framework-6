namespace SchoolNew
{
    using System;
    using System.Data.Entity;
    using SchoolNew.DataModel;
    using SchoolNew.Classes;

    class Program
    {
        static void Main(string[] args)
        {
            //
            Database.SetInitializer(new NullDatabaseInitializer<SchoolContext>());

            Console.WriteLine("Enter the student's first name:");
            string fName = Console.ReadLine();

            Console.WriteLine("Then enter the student's last name:");
            string lName = Console.ReadLine();

            AddStudent(fName, lName);
            Console.ReadKey();
        }

        private static void AddStudent(string firstName, string lastName)
        {
            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName
                //TakingCourses = new List<Course> { new Course { Name = "bs" } }
            };

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        private static void QueryStudent()
        {

        }
    }
}
