using System;
using System.Collections.Generic;
using System.Linq;

/* IN VISUAL STUDIO
Collapse regions: CTRL + M + O
Expand regions: CTRL + M + L
*/

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

        //Creates a course based on input name
        public void AddTeacher(string firstName, string lastName)
        {
            var teacher = new Teacher()
            {
                FirstName = firstName,
                LastName = lastName
            };

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Teachers.Add(teacher);
                context.SaveChanges();
            }
        }

        //Creates a course based on input name
        public void AddStudent(string firstName, string lastName)
        {
            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName
            };

            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Students.Add(student);
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

        //Removes course based on id or name
        public void RemoveTeacher(Teacher tRemove)
        {
            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Teachers.Remove(tRemove);
                context.SaveChanges();
            }
        }

        //Removes course based on id or name
        public void RemoveStudent(Student sRemove)
        {
            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Students.Remove(sRemove);
                context.SaveChanges();
            }
        }

        #endregion DATABASE COMMANDS

        #region DATABASE QUERIES

        #region Basic Content Queries

        //Queries all courses from the database
        public List<Course> QueryCourses()
        {
            var qCourses = new List<Course>();

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                qCourses = context.Courses.ToList();
            }

            return qCourses;
        }

        //Queries all assignments from the database
        public List<Assignment> QueryAssignments()
        {
            var qAssigns = new List<Assignment>();

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
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
                //context.Database.Log = Console.WriteLine;
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
                //context.Database.Log = Console.WriteLine;
                qStudents = context.Students.ToList();
            }

            return qStudents;
        }

        #endregion Basic Content Queries

        #region Existence Queries

        //Queries the database to see if courses exist
        public bool QueryCoursesExist()
        {
            bool courseExists;

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                var cnt = context.Courses.Count();
                courseExists = (cnt > 0) ? true : false;
            }

            return courseExists;
        }

        //Queries the database to see if teachers exist
        public bool QueryTeachersExist()
        {
            bool teacherExists;

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                var cnt = context.Teachers.Count();
                teacherExists = (cnt > 0) ? true : false;
            }

            return teacherExists;
        }

        //Queries the database to see if students exist
        public bool QueryStudentsExist()
        {
            bool studentExists;

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                var cnt = context.Students.Count();
                studentExists = (cnt > 0) ? true : false;
            }

            return studentExists;
        }

        #endregion Existence Queries

        public Course QuerySearchCourse(string search)
        {
            Course searchedC = new Course();

            using (var context = new SchoolContext())
            {
                var qCourse = context.Courses.
                    FirstOrDefault(c => c.Name.ToUpper().Contains(search.ToUpper()));
                searchedC = qCourse;
            }

            return searchedC;
        }

        public Teacher QuerySearchTeacher(string search)
        {
            Teacher searchedT = new Teacher();

            using (var context = new SchoolContext())
            {
                var qTeacher = context.Teachers.
                    FirstOrDefault(t => string.Concat(t.FirstName, " ", t.LastName).ToUpper()
                    .Contains(search.ToUpper()));
                searchedT = qTeacher;
            }

            return searchedT;
        }

        public Student QuerySearchStudent(string search)
        {
            Student searchedS = new Student();

            using (var context = new SchoolContext())
            {
                var qStudent = context.Students.
                    FirstOrDefault(s => string.Concat(s.FirstName, "", s.LastName).ToUpper()
                    .Contains(search.ToUpper()));
                searchedS = qStudent;
            }

            return searchedS;
        }

        #endregion DATABASE QUERIES

        //GENERAL DATA

        #region GENERAL COMMANDS

        #region Displays

        //Writes out name of all the courses, numbered by id
        public void DisplayCourses(List<Course> dCourses)
        {
            //
            int cnt = dCourses.Count;

            WriteColor("DarkRed", "#  Course Name\n");

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
            Console.Write("\n");
        }

        //Writes out name of all the courses, numbered by id
        public void DisplayTeachers(List<Teacher> dTeachers)
        {
            //
            int cnt = dTeachers.Count;

            //For all courses
            for (int i = 0; i < cnt; i++)
            {
                //Display course [i]
                Console.WriteLine($"{dTeachers[i].TeacherId}) {dTeachers[i].FirstName} {dTeachers[i].LastName}");

                //If there are assignments in course [i]
                if (dTeachers[i].Courses != null)
                {
                    var tCourses = dTeachers[i].Courses.ToList();

                    //Display assignments of [i]
                    foreach (Course c in tCourses)
                    {
                        Console.WriteLine($"Teaching:\t{c.CourseId}) {c.Name}");
                    }
                }
            }
        }

        //Writes out name of all the courses, numbered by id
        public void DisplayStudents(List<Student> dStudents)
        {
            //
            int cnt = dStudents.Count;

            //For all courses
            for (int i = 0; i < cnt; i++)
            {
                //Display course [i]
                Console.WriteLine($"{dStudents[i].StudentId}) {dStudents[i].FirstName} {dStudents[i].LastName}");

                //If there are assignments in course [i]
                if (dStudents[i].Courses != null)
                {
                    var tStudents = dStudents[i].Courses.ToList();

                    //Display assignments of [i]
                    foreach (Course c in tStudents)
                    {
                        Console.WriteLine($"Taking:\t{c.CourseId}) {c.Name}");
                    }
                }
            }
        }

        #endregion Displays

        //Takes input char and blocks until a parameter value is matched
        public char InputUntilMatched(params char[] matches)
        {
            //Initialize loop and input
            var loopOn = true;
            char input = '0';

            while (loopOn)
            {
                //Takes input character and makes it uppercase
                input = Console.ReadKey(true).KeyChar;
                input = Char.ToUpper(input);

                //For each char included in params
                for (int i = 0; i < matches.Count(); i++)
                {
                    if (matches[i] == input)
                    {
                        loopOn = false;
                    }
                }
            }
            return input;
        }

        //Customized Console.Write to pass text color as an included parameter
        public void WriteColor(string color, string text)
        {
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, color);
            Console.Write(text);
            Console.ResetColor();
        }

        #endregion GENERAL COMMANDS

        #region GENERAL QUERIES

        //Finds match in courses based on an embedded input id prompt
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
        
        #endregion GENERAL QUERIES


    }
}
