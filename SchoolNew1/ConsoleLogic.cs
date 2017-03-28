using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolNew1
{
    public class ConsoleLogic
    {
        //DATABASE

        #region Database: Add

        //Creates a course based on input name
        public void AddCourse(string name)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                context.Courses.Add(new Course { Name = name });

                context.SaveChanges();
            }
        }

        //Creates an assignment based on course, name and description
        public void AddAssignment(string assignName, string assignDescription, int courseId)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                context.Assignments.Add(new Assignment
                {
                    Name = assignName,
                    Description = assignDescription,
                    CourseId = courseId
                });

                context.SaveChanges();
            }
        }

        //Creates a course based on input name
        public void AddTeacher(string firstName, string lastName)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                context.Teachers.Add(new Teacher
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                context.SaveChanges();
            }
        }

        //Creates a course based on input name
        public void AddStudent(string firstName, string lastName)
        {
            using (var context = new SchoolContext())
            {
                //context.Database.Log = Console.WriteLine;
                context.Students.Add(new Student
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                context.SaveChanges();
            }
        }

        #endregion Database: Add

        #region Database: Remove

        //Removes course based on id or name
        public void RemoveCourse(int? cRemoveId)
        {
            if (cRemoveId != null)
            {
                using (var context = new SchoolContext())
                {
                    //context.Database.Log = Console.WriteLine;

                    var removeC = context.Courses.FirstOrDefault(c => c.CourseId == (int)(cRemoveId));

                    if (removeC != null)
                    {
                        //Attaches the course to the context and then removes it
                        context.Courses.Attach(removeC);
                        context.Courses.Remove(removeC);

                        context.SaveChanges();
                    }
                }
            }
        }

        //Removes course based on id or name
        public void RemoveAssignment(int? aRemoveId)
        {
            if (aRemoveId != null)
            {
                using (var context = new SchoolContext())
                {
                    //context.Database.Log = Console.WriteLine;

                    var removeA = context.Assignments.FirstOrDefault(a => a.AssignmentId == (int)(aRemoveId));

                    if (removeA != null)
                    {
                        //Attaches the course to the context and then removes it
                        context.Assignments.Attach(removeA);
                        context.Assignments.Remove(removeA);

                        context.SaveChanges();
                    }
                }
            }
        }

        //Removes course based on id or name
        public void RemoveTeacher(Teacher tRemove)
        {
            if (tRemove != null)
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
        }

        //Removes course based on id or name
        public void RemoveStudent(Student sRemove)
        {
            if (sRemove != null)
            {
                using (var context = new SchoolContext())
                {
                    //context.Database.Log = Console.WriteLine;

                    context.Students.Attach(sRemove);
                    context.Students.Remove(sRemove);

                    context.SaveChanges();
                }
            }
        }

        #endregion Database: Remove


        #region Database: Querying lists

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

        #endregion Database Querying lists

        #region Database: Search queries

        //
        public Course QuerySearchCourse(string search)
        {
            Course searchedC = new Course();

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

        //
        public Assignment QuerySearchAssignment(string search)
        {
            Assignment searchedA = new Assignment();

            //Attempts to parse search string to int ...
            int res;
            bool success = int.TryParse(search, out res);

            //... if it is parsable, do an id search with the resulting int
            if (success)
            {
                using (var context = new SchoolContext())
                {
                    searchedA = context.Assignments.FirstOrDefault(a => a.AssignmentId == res);
                }

                return searchedA;
            }
            else //do a name search instead
            {
                using (var context = new SchoolContext())
                {
                    searchedA = context.Assignments.FirstOrDefault(a => a.Name.ToUpper().Contains(search.ToUpper()));
                }

                return searchedA;
            }
        }

        //
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

        //
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

        #endregion Database: Search queries



        //GENERAL DATA

        #region DISPLAYS

        //Writes out all the courses with assignments), numbered by id
        public void DisplayCourses(List<Course> courses, List<Assignment> assigns = null)
        {
            //Gets count of courses
            int courseCnt = courses.Count;

            //Displays reference row
            WriteColor("DarkRed", "#  Course Name\n");

            //For all courses
            for (int i = 0; i < courseCnt; i++)
            {
                //Display course i
                Console.WriteLine($"{courses[i].CourseId}) {courses[i].Name}");

                //If there are assignments in course i
                if (assigns != null)
                {
                    //Displays reference row for assignments
                    WriteColor("DarkRed", "\tAssignments\n");

                    //Displays all assignments with a foreign key course id matching the current course's id
                    foreach (Assignment a in assigns.Where(a => a.CourseId == courses[i].CourseId))
                    {
                        Console.WriteLine($"\t{a.Name}: {a.Description}");
                    }
                }
            }

            Console.Write("\n");
        }

        //Writes out all the assignments, numbered by id
        public void DisplayAssignments(List<Assignment> assigns)
        {
            //Display assignments reference
            WriteColor("DarkRed", "#  Name | Course | Description\n");

            //Display each assignment in paramater list with the name of the course they belong to
            foreach (Assignment a in assigns)
            {
                //Gets the course of the id FK in the assignment
                var aCourse = QuerySearchCourse(a.CourseId.ToString());

                //Display everything
                Console.WriteLine($"{a.AssignmentId}) {a.Name}\n"
                    + $"\tCourse: {aCourse.Name}\n"
                    + $"\tDescription: {a.Description}\n");
            }

            Console.Write("\n");
        }

        //Writes out all the teachers, numbered by id
        public void DisplayTeachers(List<Teacher> dTeachers)
        {
            //
            int teachCnt = dTeachers.Count;

            //For all courses
            for (int t = 0; t < teachCnt; t++)
            {
                //Display teacher[t]
                Console.WriteLine($"{dTeachers[t].TeacherId}) {dTeachers[t].FirstName} {dTeachers[t].LastName}");

                //If the teacher has any courses
                if (dTeachers.Count > 0)
                {
                    WriteColor("DarkRed", $"\tTeaching:");

                    //
                    foreach (Course c in dTeachers[t].Courses)
                    {
                        if (c != null)
                        {
                            Console.WriteLine("\t{c.CourseId}) {c.Name}");
                        }
                    }
                    Console.Write("\n");
                }
            }

            Console.Write("\n");
        }

        //Writes out all the students, numbered by id
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

        #region MISC

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

        #endregion MISC
        
    }
}
