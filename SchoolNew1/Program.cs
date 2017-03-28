using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

/* IN VISUAL STUDIO
Collapse regions: CTRL + M + O
Expand regions: CTRL + M + L
*/

namespace SchoolNew1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PREPERATIONS

            //Disables initialization for SchoolContext
            Database.SetInitializer(new NullDatabaseInitializer<SchoolContext>());

            //Object for custom class with data handling functions
            ConsoleLogic CLogic = new ConsoleLogic();

            #endregion PREPERATIONS

            //Intro
            Console.WriteLine("Welcome to the school app!\n");

            //MAIN LOOP: for stepping back to main menu
            bool mainLoop = true;
            while (mainLoop)
            {
                #region MAIN MENU: PROMPT & CHOICE

                //Display menu
                Console.WriteLine("Select from menu:");
                CLogic.WriteColor("Green", "\tC) Courses"
                    + "\tP) People"
                    + "\tQ) Quit\n");

                //Get user choice
                char select = CLogic.InputUntilMatched('C', 'P', 'Q');

                #endregion MAIN MENU: PROMPT & CHOICE

                //Decides whether to go to Courses, People, or to Quit app
                switch (select)
                {
                    case 'C':
                        {
                            //QUERY: gets courses from database
                            List<Course> coursesList = new List<Course>(CLogic.QueryCourses());

                            //
                            if (coursesList.Count < 1)
                            {
                                #region COURSES: NOT FOUND

                                Console.WriteLine("\nThere are no courses available. Do you want to add one (Y/N)?");
                                char choice = CLogic.InputUntilMatched('Y', 'N');

                                #endregion COURSES: NOT FOUND

                                #region COURSES: ADD FIRST

                                switch (choice)
                                {
                                    case 'Y':
                                        {
                                            #region Add a new course

                                            //Prompts user to enter name of new course
                                            CLogic.WriteColor("Green", "\nName of the new course:\n");
                                            string newCourse = Console.ReadLine();

                                            //Adds new course
                                            CLogic.AddCourse(newCourse);
                                            
                                            break;

                                            #endregion Add a new course
                                        }
                                    case 'N':
                                        {
                                            break;
                                        }
                                }

                                #endregion COURSES: ADD FIRST
                            }
                            else
                            {
                                #region COURSES: DISPLAY
                                
                                //DISPLAY: writes out name of all the courses, numbered by id
                                CLogic.DisplayCourses(coursesList);

                                #endregion COURSES: DISPLAY

                                #region COURSES: CHOICES

                                Console.WriteLine("What do you want to do?");
                                CLogic.WriteColor("Green", "A) Add course"
                                    + "\nR) Remove course"
                                    + "\nS) Assignments"
                                    + "\nB) Back\n\n");

                                //LOOP MENU
                                char menuC = CLogic.InputUntilMatched('A', 'R', 'S', 'B');

                                #endregion COURSES: CHOICES

                                //Branches: Add, Remove, Assignments, Back
                                #region COURSES: BRANCHES

                                switch (menuC)
                                {
                                    case 'A':
                                        {
                                            #region Course: add

                                            Console.WriteLine("Add new course:");

                                            //Prompts user to enter name of new course
                                            Console.WriteLine("Name of new course:");
                                            string newCourse = Console.ReadLine();

                                            //Adds new course
                                            CLogic.AddCourse(newCourse);

                                            break;

                                            #endregion Course: add
                                        }
                                    case 'R':
                                        {
                                            #region Course: remove

                                            Console.WriteLine("Which course do you want to remove (ID/NAME)?");

                                            var search = Console.ReadLine();
                                            Console.Write("\n");

                                            //Searches for a course
                                            var searchedCourse = CLogic.QuerySearchCourse(search);

                                            //Removes searched course
                                            CLogic.RemoveCourse(searchedCourse.CourseId);

                                            break;

                                            #endregion Course: remove
                                        }
                                    case 'S':
                                        {
                                            #region Course: assignments

                                            //QUERY: gets assignments from database
                                            List<Assignment> assignmentsList = new List<Assignment>(CLogic.QueryAssignments());

                                            //No assignments were found in database
                                            if (assignmentsList.Count < 1)
                                            {
                                                Console.WriteLine("There are no assignments in the database. Do you want to add one (Y/N)?\n");

                                                char aNewChoice = CLogic.InputUntilMatched('Y', 'N');

                                                switch (aNewChoice)
                                                {
                                                    case 'Y':
                                                        {
                                                            #region Assignment: add

                                                            //NAME of new assignment
                                                            Console.WriteLine("Give the new assignment a name:");
                                                            string createName = Console.ReadLine();

                                                            //DESCRIPTION of new assignment
                                                            Console.WriteLine("\nGive the new assignment a description:");
                                                            string createDesc = Console.ReadLine();

                                                            //COURSE of new assignment
                                                            Console.WriteLine("\nConnect the assignment to a course (ID/NAME):");
                                                            
                                                            //Take input until conversion to int is possible to eliminate typing errors
                                                            string createFK = "";
                                                            createFK = Console.ReadLine();

                                                            //Finds a course based on searched ID
                                                            var searchedCourse = CLogic.QuerySearchCourse(createFK);
                                                            
                                                            //Adds
                                                            CLogic.AddAssignment(createName, createDesc, searchedCourse.CourseId);

                                                            break;

                                                            #endregion Assignment: add
                                                        }
                                                    case 'N':
                                                        {
                                                            break;
                                                        }
                                                }
                                            }
                                            else //Assignments were found in database
                                            {

                                                //Display the assignments in the list
                                                CLogic.DisplayAssignments(assignmentsList);


                                                #region Assignments: choice

                                                Console.Write("\nWhat do you want to do?\n");
                                                CLogic.WriteColor("Green", "A) Add assignment\n"
                                                    + "R) Remove assignment\n"
                                                    + "B) Back\n\n");

                                                char aChoice = CLogic.InputUntilMatched('A', 'R', 'B');

                                                #endregion Assignments: choice

                                                #region Assignments: branches

                                                switch (aChoice)
                                                {
                                                    case 'A':
                                                        {
                                                            #region Assignment: add

                                                            //NAME of new assignment
                                                            Console.WriteLine("Give the new assignment a name:");
                                                            string createName = Console.ReadLine();

                                                            //DESCRIPTION of new assignment
                                                            Console.WriteLine("Give the new assignment a description:");
                                                            string createDesc = Console.ReadLine();

                                                            break;

                                                            #endregion Assignment: add
                                                        }
                                                    case 'R':
                                                        {
                                                            #region Assignment: remove

                                                            Console.WriteLine("Which assignment do you want to remove (ID/NAME)?");

                                                            var search = Console.ReadLine();
                                                            Console.Write("\n");

                                                            //Searches for a course
                                                            var searchedAssign = CLogic.QuerySearchAssignment(search);

                                                            //Removes searched course
                                                            CLogic.RemoveAssignment(searchedAssign.AssignmentId);

                                                            break;

                                                            #endregion Assignment: remove
                                                        }
                                                    case 'B':
                                                        {
                                                            break;
                                                        }
                                                }

                                                #endregion Assignments: branches

                                            }

                                            break;

                                            #endregion Course: assignments
                                        }
                                    case 'B':
                                        {
                                            break;
                                        }
                                }

                                #endregion COURSES: BRANCHES
                            }
                            break;
                        }
                    case 'P':
                        {
                            #region PEOPLE: CHOICES

                            CLogic.WriteColor("Green", "\nPEOPLE:\n");
                            Console.WriteLine("T) Teachers"
                                + "\nS) Students"
                                + "\nB) Back\n");

                            //Inputs until user gives either T, S or B
                            char menuP = CLogic.InputUntilMatched('T', 'S', 'B');

                            #endregion PEOPLE: CHOICES

                            //Branches: Teachers, Students, Back
                            #region PEOPLE: BRANCHES

                            switch (menuP)
                            {
                                case 'T':
                                    {
                                        //Gets teachers from database
                                        var teachersList = new List<Teacher>(CLogic.QueryTeachers());

                                        //Checks if teachers were found in database ...
                                        if (teachersList.Count < 1)
                                        {
                                            #region NO TEACHERS FOUND. CREATE?

                                            Console.WriteLine("There are no teachers in the database. Do you want to add one (Y/N)?");
                                            char choice = CLogic.InputUntilMatched('Y', 'N');

                                            #endregion NO TEACHERS FOUND. CREATE?

                                            #region TEACHER CREATE: BRANCHES

                                            switch (choice)
                                            {
                                                case 'Y':
                                                    {
                                                        #region Add new teacher

                                                        //Prompts user to enter names of new teacher
                                                        Console.WriteLine("First name of the teacher to add:");
                                                        string newFirst = Console.ReadLine();

                                                        Console.WriteLine("Last name of the teacher to add:");
                                                        string newLast = Console.ReadLine();
                                                        
                                                        //Adds new teacher
                                                        CLogic.AddTeacher(newFirst, newLast);

                                                        break;

                                                        #endregion Add new teacher
                                                    }
                                                case 'N':
                                                    {
                                                        break;
                                                    }
                                            }

                                            #endregion TEACHER CREATE: BRANCHES
                                        }
                                        else
                                        {
                                            //DISPLAY: writes out name of all the teachers, numbered by id
                                            CLogic.DisplayTeachers(teachersList);

                                            #region TEACHER: CHOICE

                                            Console.WriteLine("What do you want to do?"
                                                + "\nA) Add teacher"
                                                + "\nR) Remove teacher"
                                                + "\nB) Back");

                                            char choice = CLogic.InputUntilMatched('A', 'R', 'B');

                                            #endregion TEACHER: CHOICE

                                            #region TEACHER: BRANCHES

                                            //BRANCHES: Add, Remove, Back
                                            switch (choice)
                                            {
                                                case 'A':
                                                    {
                                                        #region Add a new teacher

                                                        Console.WriteLine("First name of the new teacher:");
                                                        string newTeacherFirst = Console.ReadLine();

                                                        //Prompts user to enter name of new course
                                                        Console.WriteLine("Last name of the new teacher:");
                                                        string newTeacherLast = Console.ReadLine();

                                                        //Adds new course
                                                        CLogic.AddTeacher(newTeacherFirst, newTeacherLast);

                                                        break;

                                                        #endregion Add a new teacher
                                                    }
                                                case 'R':
                                                    {
                                                        #region Remove teacher

                                                        Console.WriteLine("Which teacher do you want to remove (ID / NAME)?");

                                                        //Searches for a teacher
                                                        var search = Console.ReadLine();
                                                        var searchedTeacher = CLogic.QuerySearchTeacher(search);

                                                        //Removes searched course
                                                        CLogic.RemoveTeacher(searchedTeacher);

                                                        break;

                                                        #endregion Remove teacher
                                                    }
                                                case 'B':
                                                    {
                                                        break;
                                                    }
                                            }

                                            #endregion TEACHER: BRANCHES
                                        }
                                        break;
                                    }
                                case 'S':
                                    {
                                        //Gets teachers from database
                                        var studentsList = new List<Student>(CLogic.QueryStudents());

                                        //Checks if students exist in database ...
                                        if (studentsList.Count < 1)
                                        {
                                            #region NO STUDENTS FOUND. CREATE?

                                            Console.WriteLine("There are no students yet. Do you want to add one (Y/N)?");
                                            char choice = CLogic.InputUntilMatched('Y', 'N');

                                            #endregion NO STUDENTS FOUND. CREATE?

                                            #region STUDENT CREATE: BRANCHES

                                            switch (choice)
                                            {
                                                case 'Y':
                                                    {
                                                        #region Add new student

                                                        //Prompts user to enter names of new student
                                                        Console.WriteLine("First name:");
                                                        string newStudentFirst = Console.ReadLine();

                                                        Console.WriteLine("Last name:");
                                                        string newStudentLast = Console.ReadLine();

                                                        //Adds new student
                                                        CLogic.AddStudent(newStudentFirst, newStudentLast);

                                                        break;

                                                        #endregion Add new student
                                                    }
                                                case 'N':
                                                    {
                                                        break;
                                                    }
                                            }

                                            #endregion STUDENT CREATE: BRANCHES
                                        }
                                        else
                                        {
                                            #region STUDENTS: DISPLAY
                                            
                                            //DISPLAY: writes out name of all the courses, numbered by id
                                            CLogic.DisplayStudents(studentsList);

                                            #endregion STUDENTS: DISPLAY

                                            #region STUDENTS: CHOICE

                                            Console.WriteLine("What do you want to do?"
                                                + "\nA) Add course"
                                                + "\nR) Remove course"
                                                + "\nB) Back");

                                            char choice = CLogic.InputUntilMatched('A', 'R', 'B');

                                            #endregion STUDENTS: CHOICE

                                            #region STUDENT: BRANCHES

                                            //BRANCH: Add, Remove, Back
                                            switch (choice)
                                            {
                                                case 'A':
                                                    {
                                                        #region Add a new student

                                                        Console.WriteLine("First name of the new student:");
                                                        string newStudentFirst = Console.ReadLine();

                                                        //Prompts user to enter name of new course
                                                        Console.WriteLine("Last name of the new student:");
                                                        string newStudentLast = Console.ReadLine();

                                                        //Adds new course
                                                        CLogic.AddStudent(newStudentFirst, newStudentLast);

                                                        break;

                                                        #endregion Add a new student
                                                    }
                                                case 'R':
                                                    {
                                                        #region Remove student

                                                        Console.WriteLine("Which student do you want to remove (ID / NAME)?");

                                                        //Searches for a student
                                                        var search = Console.ReadLine();
                                                        var searchedStudent = CLogic.QuerySearchStudent(search);

                                                        //Removes searched course
                                                        CLogic.RemoveStudent(searchedStudent);

                                                        break;

                                                        #endregion Remove teacher
                                                    }
                                                case 'B':
                                                    {
                                                        break;
                                                    }
                                            }

                                            #endregion STUDENT: BRANCHES
                                        }
                                        break;
                                    }
                                case 'B':
                                    {
                                        break;
                                    }
                            }

                            #endregion PEOPLE: BRANCHES

                            break;
                        }
                    case 'Q':
                        {
                            #region QUIT

                            mainLoop = false;
                            break;

                            #endregion QUIT
                        }
                }
            }
        }
    }
}
