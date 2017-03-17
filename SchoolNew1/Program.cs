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
                    + "\tQ) Quit\n\n");

                //Get user choice
                char select = CLogic.InputUntilMatched('C', 'P', 'Q');

                #endregion MAIN MENU: PROMPT & CHOICE

                #region MAIN MENU: BRANCHES

                //Decides whether to go to Courses, People, or to Quit app
                switch (select)
                {
                    case 'C':
                        {
                            //Checks if courses don't exist in the database ...
                            if (!(CLogic.QueryCoursesExist()))
                            {
                                #region NO COURSES FOUND. CREATE?

                                Console.WriteLine("There are no courses available. Do you want to add one (Y/N)?");
                                char choice = CLogic.InputUntilMatched('Y', 'N');

                                #endregion NO COURSES FOUND. CREATE?

                                #region COURSE CREATE: SWITCH

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

                                            #region Assignments?

                                            Console.WriteLine("\nDo you want to give it assignments (Y/N)?\n");

                                            //Takes user choice of giving assignments to the created course
                                            char giveAssignments = CLogic.InputUntilMatched('Y', 'N');

                                            switch (giveAssignments)
                                            {
                                                case 'Y':
                                                    {
                                                        #region Give assignments

                                                        //bool assignsExist;
                                                        //do {
                                                        //    //Checks if assignments exist in the database
                                                        //    assignsExist = CLogic.QueryAssignmentsExist();
                                                        //    if (assignsExist)
                                                        //    {
                                                        //        //Gets list of assignments from database
                                                        //        var assignments = CLogic.QueryAssignments();

                                                        //        //Displays assignments
                                                        //        CLogic.DisplayAssignments(assignments);

                                                        //        using (var context = new SchoolContext())
                                                        //        {
                                                        //            //context.Courses.
                                                        //        }
                                                        //    }
                                                        //    else //Assignments don't exist, user has to create them
                                                        //    {

                                                        //    }

                                                        //} while (assignsExist);

                                                        #endregion Give assignments

                                                        break;
                                                    }
                                                case 'N':
                                                    {
                                                        break;
                                                    }
                                            }

                                            #endregion Assignments?

                                            break;

                                            #endregion Add a new course
                                        }
                                    case 'N':
                                        {
                                            break;
                                        }
                                }

                                #endregion COURSE CREATE: SWITCH
                            }
                            else //... if they do
                            {
                                #region COURSE: QUERY & DISPLAY

                                //QUERY: gets courses from database
                                List<Course> coursesList = new List<Course>(CLogic.QueryCourses());

                                //QUERY: gets assignments from database
                                List<Assignment> assignmentsList = new List<Assignment>(CLogic.QueryAssignments());

                                //DISPLAY: writes out name of all the courses, numbered by id
                                CLogic.DisplayCourses(coursesList, assignmentsList);

                                Console.WriteLine("What do you want to do?");
                                CLogic.WriteColor("Green", "A) Add course"
                                    + "\nR) Remove course"
                                    + "\nS) Assignments"
                                    + "\nB) Back\n\n");

                                #endregion COURSE: QUERY & DISPLAY

                                #region COURSE: CHOICE

                                //LOOP MENU
                                char menuC = CLogic.InputUntilMatched('A', 'R', 'S', 'B');

                                #endregion COURSE: CHOICE

                                #region COURSE: BRANCHES

                                //BRANCH: ...
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

                                            /*----User might be asked if they want to create an assignment,
                                            add a student or teacher */

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
                                            CLogic.RemoveCourse(searchedCourse);

                                            break;

                                            #endregion Course: remove
                                        }
                                    case 'S':
                                        {
                                            #region Course: assignments

                                            //There are assignments in database
                                            if (CLogic.QueryAssignmentsExist())
                                            {

                                                #region Query & Display assignments
                                                
                                                foreach (Assignment a in assignmentsList.Where()
                                                {

                                                }

                                                //
                                                Console.WriteLine($"{}");

                                                #endregion Query & Display assignments

                                                #region
                                                #endregion
                                            }
                                            else //There are no assignments in database
                                            {

                                            }

                                            break;

                                            #endregion Course: assignments
                                        }
                                    case 'B':
                                        {
                                            break;
                                        }
                                }

                                #endregion COURSE: BRANCHES
                            }
                            break;
                        }
                    case 'P':
                        {
                            #region PEOPLE: PROMPT

                            CLogic.WriteColor("Green", "T) Teachers"
                                + "\nS) Students"
                                + "B) Back");

                            #endregion PEOPLE: PROMPT

                            #region PEOPLE: CHOICE

                            //Inputs until user gives either T, S or B
                            char menuP = CLogic.InputUntilMatched('T', 'S', 'B');

                            #endregion PEOPLE: CHOICE

                            #region PEOPLE: BRANCHES

                            //Branches ...
                            switch (menuP)
                            {
                                case 'T':
                                    {
                                        //Checks if teachers exist in database ...
                                        if (!(CLogic.QueryTeachersExist()))
                                        {
                                            #region NO TEACHERS FOUND. CREATE?
                                            Console.WriteLine("There are no teachers yet. Do you want to add one(Y/N)?");

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
                                                        string newTeacherFirst = Console.ReadLine();

                                                        Console.WriteLine("Last name of the teacher to add:");
                                                        string newTeacherLast = Console.ReadLine();

                                                        //Adds new teacher
                                                        CLogic.AddTeacher(newTeacherFirst, newTeacherLast);

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
                                            #region TEACHER: QUERY & DISPLAY

                                            //QUERY: gets courses from database
                                            List<Teacher> teachersList = new List<Teacher>(CLogic.QueryTeachers());

                                            //DISPLAY: writes out name of all the courses, numbered by id
                                            CLogic.DisplayTeachers(teachersList);

                                            Console.WriteLine("What do you want to do?"
                                                + "\nA) Add course"
                                                + "\nR) Remove course"
                                                + "\nB) Back");

                                            #endregion TEACHER: QUERY & DISPLAY

                                            #region TEACHER: CHOICE

                                            char choice = CLogic.InputUntilMatched('A', 'R', 'B');

                                            #endregion TEACHER: CHOICE

                                            #region TEACHER: BRANCHES

                                            //BRANCH: ...
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
                                        //Checks if students exist in database ...
                                        if (!(CLogic.QueryStudentsExist()))
                                        {
                                            #region NO STUDENTS FOUND. CREATE?
                                            Console.WriteLine("There are no students yet. Do you want to add one(Y/N)?");

                                            char choice = CLogic.InputUntilMatched('Y', 'N');

                                            #endregion NO STUDENTS FOUND. CREATE?

                                            #region STUDENT CREATE: BRANCHES

                                            switch (choice)
                                            {
                                                case 'Y':
                                                    {
                                                        #region Add new student

                                                        //Prompts user to enter names of new student
                                                        Console.WriteLine("First name of the student to add:");
                                                        string newStudentFirst = Console.ReadLine();

                                                        Console.WriteLine("Last name of the student to add:");
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
                                            #region STUDENT: QUERY & DISPLAY

                                            //QUERY: gets courses from database
                                            List<Student> studentsList = new List<Student>(CLogic.QueryStudents());

                                            //DISPLAY: writes out name of all the courses, numbered by id
                                            CLogic.DisplayStudents(studentsList);

                                            Console.WriteLine("What do you want to do?"
                                                + "\nA) Add course"
                                                + "\nR) Remove course"
                                                + "\nB) Back");

                                            #endregion STUDENT: QUERY & DISPLAY

                                            #region STUDENT: CHOICE

                                            char choice = CLogic.InputUntilMatched('A', 'R', 'B');

                                            #endregion STUDENT: CHOICE

                                            #region STUDENT: BRANCHES

                                            //BRANCH: ...
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

                                                        Console.WriteLine("Which student do you want to remove(ID / NAME)?");

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
                            #region BRANCH: QUIT

                            mainLoop = false;
                            break;

                            #endregion BRANCH: QUIT
                        }
                }

                #endregion MAIN MENU: BRANCHES
            }
        }
    }
}
