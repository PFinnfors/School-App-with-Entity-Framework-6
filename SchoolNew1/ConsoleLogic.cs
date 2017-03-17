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

        #region Database: Add

        //Creates a course based on input name
        public void AddCourse(string name)
        {
            var course = new Course()
            {
                Name = name
            };

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;

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
                //context.Database.Log = Console.WriteLine;

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
                //context.Database.Log = Console.WriteLine;

                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        #endregion Database: Add

        #region Database: Remove

        //Removes course based on id or name
        public void RemoveCourse(Course cRemove)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;

                //Attaches the course to the context and then removes it
                context.Courses.Attach(cRemove);
                context.Courses.Remove(cRemove);

                context.SaveChanges();
            }
        }

        //Removes course based on id or name
        public void RemoveTeacher(Teacher tRemove)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;

                //Attaches the course to the context and then removes it
                context.Teachers.Attach(tRemove);
                context.Teachers.Remove(tRemove);

                context.SaveChanges();
            }
        }

        //Removes course based on id or name
        public void RemoveStudent(Student sRemove)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;

                context.Students.Attach(sRemove);
                context.Students.Remove(sRemove);

                context.SaveChanges();
            }
        }

        #endregion Database: Remove

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

        //Queries the database to see if assignments exist
        public bool QueryAssignmentsExist()
        {
            bool assignExists;

            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                var cnt = context.Assignments.Count();
                assignExists = (cnt > 0) ? true : false;
            }

            return assignExists;
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

        #region Specific search queries

        public Course QuerySearchCourse(string search)
        {
            var searchedC = new Course();

            //Attempts to parse search string to int ...
            int res;
            bool success = int.TryParse(search, out res);

            //... if it is parsable, do an id search with the resulting int
            if (success)
            {
                using (var context = new SchoolContext())
                {
                    searchedC =
                        context.Courses.
                        FirstOrDefault(c => c.CourseId == res);
                }

                return searchedC;
            }
            else //do a name search instead
            {
                using (var context = new SchoolContext())
                {
                    searchedC = context.Courses.
                        FirstOrDefault(c => c.Name.ToUpper().Contains(search.ToUpper()));
                }

                return searchedC;
            }
        }

        public Teacher QuerySearchTeacher(string search)
        {
            Teacher searchedT = new Teacher();

            //
            int res;
            bool success = int.TryParse(search, out res);

            if (success)
            {
                using (var context = new SchoolContext())
                {
                    var qiTeacher =
                        context.Teachers.
                        FirstOrDefault(t => t.TeacherId.ToString() == search);

                    searchedT = qiTeacher;
                }
            }
            else
            {
                using (var context = new SchoolContext())
                {
                    var qsTeacher = context.Teachers.
                        FirstOrDefault(t => string.Concat(t.FirstName, "", t.LastName).ToUpper()
                    .Contains(search.ToUpper()));

                    searchedT = qsTeacher;
                }
            }

            return searchedT;
        }

        public Student QuerySearchStudent(string search)
        {
            Student searchedS = new Student();

            //
            int res;
            bool success = int.TryParse(search, out res);

            if (success)
            {
                using (var context = new SchoolContext())
                {
                    var qiStudent =
                        context.Students.
                        FirstOrDefault(s => s.StudentId.ToString() == search);

                    searchedS = qiStudent;
                }
            }
            else
            {
                using (var context = new SchoolContext())
                {
                    var qStudent = context.Students.
                        FirstOrDefault(s => string.Concat(s.FirstName, "", s.LastName).ToUpper()
                        .Contains(search.ToUpper()));
                    searchedS = qStudent;
                }
            }

            return searchedS;
        }

        #endregion Specific search queries

        #endregion DATABASE QUERIES

        //GENERAL DATA

        #region GENERAL COMMANDS

        #region DISPLAYS

        //Writes out name of all the courses, numbered by id
        public void DisplayCourses(List<Course> dCourses, List<Assignment> dAssigns = null)
        {
            //Gets count of courses
            int cnt = dCourses.Count;

            //Displays reference row for courses
            WriteColor("DarkRed", "#  Course Name\n");

            //For all courses
            for (int i = 0; i < cnt; i++)
            {
                //Display course[i of cnt]
                Console.WriteLine($"{dCourses[i].CourseId}) {dCourses[i].Name}");

                //If there are assignments in course[i of cnt]
                if (dAssigns != null)
                {
                    //Displays reference row for assignments
                    Console.Write("\tAssignments ");
                    WriteColor("DarkRed", "Name: Description\n");

                    //Displays all assignments with a foreign key course id matching the current course's id
                    foreach (Assignment a in dAssigns.Where(a => a.CourseId == dCourses[i].CourseId))
                    {
                        Console.WriteLine($"\t{a.Name}: {a.Description}");
                    }
                }
            }

            Console.Write("\n");
        }

        public void DisplayAssignments(List<Assignment> dAssignments)
        {
            //
            int cnt = dAssignments.Count;

            WriteColor("DarkRed", "#  Assignment Name | Description\n");

            //For all assignments
            for (int i = 0; i < cnt; i++)
            {
                //Display course [i]
                Console.WriteLine($"{dAssignments[i].AssignmentId}) {dAssignments[i].Name}"
                    + $"\n\t{dAssignments[i].Description}");
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

            Console.Write("\n");
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

            Console.Write("\n");
        }

        #endregion DISPLAYS

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
