using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNew1
{
    class ConsoleLogic
    {


        //Queries the database to see if courses exist in it
        public void CreateCourse(string name)
        {
            var course = new Course()
            {
                Name = name
            };

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }

        //Queries the database to see if courses exist in it
        public bool QueryCoursesExist()
        {
            bool courseExists;

            using (var context = new SchoolContext())
            {
                var cnt = context.Courses.Count();
                courseExists = (cnt > 0) ? true : false;
            }

            return courseExists;
        }
    }
}
