using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolNew1
{
    public class ConsoleLogic
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
        public void RemoveCourse(Course cRemove)
        {
            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Courses.Remove(cRemove);
                context.SaveChanges();
            }
        }
        
        #endregion DATABASE COMMANDS

        #region DATABASE QUERIES
        
        #region Basic Queries

        //Queries all courses from the database
        public List<Course> QueryCourses()
        {
            var qCourses = new List<Course>();

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                qCourses = context.Courses.ToList();
                //cnt = context.Courses.ToList().Count;
            }

            return qCourses;
        }

        //Queries all assignments from the database
        public List<Assignment> QueryAssignments()
        {
            var qAssigns = new List<Assignment>();

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                qAssigns = context.Assignments.ToList();
            }

            return qAssigns;
        }

        //Queries all teachers from the database
        public List<Teacher> QueryTeachers()
        {
            var qTeachers = new List<Teacher>();

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                qTeachers = context.Teachers.ToList();
            }

            return qTeachers;
        }

        //Queries all students from the database
        public List<Student> QueryStudents()
        {
            var qStudents = new List<Student>();

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                qStudents = context.Students.ToList();
            }

            return qStudents;
        }

        #endregion Basic Queries

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

        public Course QuerySearchCourse(string search)
        {
            Course searchedC = new Course();

            using (var context = new SchoolContext())
            {
                var qCourse = context.Courses.FirstOrDefault(c => c.Name.ToUpper() == search.ToUpper());
                searchedC = qCourse;
            }

            return searchedC;
        }
        
        #endregion DATABASE QUERIES
        


        //GENERAL DATA

        #region DISPLAY INFORMATION

        //Writes out name of all the courses, numbered by id
        public void DisplayCourses(List<Course> dCourses)
        {
            //
            int cnt = dCourses.Count;

            //For all courses
            for (int i = 0; i < cnt; i++)
            {
                //Display course [i]
                Console.WriteLine($"{dCourses[i].CourseId}) {dCourses[i].Name}");

                //If there are assignments in course [i]
                if (dCourses[i].Assignments != null)
                {
                    var cAssigns = dCourses[i].Assignments.ToList();

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
