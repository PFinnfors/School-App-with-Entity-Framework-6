using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolNew1
{
    class ConsoleLogic
    {
        //DATABASE

        #region DATABASE COMMANDS

        //Creates a course based on input name
        public void AddCourse(string name)
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

        //Removes course based on id or name
        public void RemoveCourse(int? id = null, string name = null)
        {
            //if()
            //{

            //}
            //else if()
            //{

            //}
            //else
            //{
            //    Console.WriteLine("Not a valid course ID or name!");
            //}
        }

        public void SearchCourse()
        {

        }

        #endregion DATABASE COMMANDS

        #region DATABASE QUERIES

        //Queries the database to see if courses exist
        public bool QueryCoursesExist()
        {
            bool courseExists;

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                var cnt = context.Courses.Count();
                courseExists = (cnt > 0) ? true : false;
            }

            return courseExists;
        }

        //Queries all courses from the database
        public List<Course> QueryCourses()
        {
            var courses = new List<Course>();

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                courses = context.Courses.ToList();
                //cnt = context.Courses.ToList().Count;
            }

            return courses;
        }

        #endregion DATABASE QUERIES

        
        //GENERAL

        #region DISPLAY INFORMATION

        //Writes out name of all the courses, numbered by id
        public void DisplayCourses(List<Course> courses)
        {
            //
            int cnt = courses.Count;

            //For all courses
            for (int i = 0; i < cnt; i++)
            {
                //Display course [i]
                Console.WriteLine($"{courses[i].CourseId}) {courses[i].Name}");

                //If there are assignments in course [i]
                if (courses[i].Assignments != null)
                {
                    var cAssigns = courses[i].Assignments.ToList();

                    //Display assignments of [i]
                    foreach (Assignment a in cAssigns)
                    {
                        Console.WriteLine($"\t{a.AssignmentId}) {a.Name}\n\tDescription: {a.Description}");
                    }
                }
            }

            //Console.WriteLine("ID # | Name");
            //foreach (Course c in courses)
            //{
            //    Console.WriteLine($"{c.CourseId}) {c.Name}");
            //}
        }

        #endregion DISPLAY INFORMATION

        #region RETRIEVE INFORMATION

        //Finds match in courses based on input id
        public Course GetCourseById(List<Course> courses)
        {
            char idNum = '0';

            //while course(s) don't exist where their id equals idNum as int ...
            while (courses.Exists(c => c.CourseId == Convert.ToInt16(idNum)))
            {
                //Prompts user for id request
                idNum = Console.ReadKey(true).KeyChar;
            }

            //Finds the first course with a matching id then returns it
            var courseMatch = courses.FirstOrDefault(c => c.CourseId == Convert.ToInt16(idNum));
            return courseMatch;
        }

        #endregion RETRIEVE INFORMATION


    }
}
