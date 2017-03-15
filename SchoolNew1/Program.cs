using System;
using System.Data.Entity;
using System.Collections.Generic;

//CTRL + M + O is useful here

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
                Console.WriteLine("Select from menu:\n"
                    + "\tC) Courses"
                    + "\tP) People"
                    + "\tQ) Quit");

                //Get user choice
                char selection = Console.ReadKey(true).KeyChar;
                selection = char.ToUpper(selection);

                #endregion MAIN MENU: PROMPT & CHOICE

                #region MAIN MENU: BRANCH

                //Decides whether to go to Courses, People, or to Quit app
                switch (selection)
                {
                    #region BRANCH: COURSE
                    case 'C':
                        {
                            //Checks if courses exist in database ...
                            bool exist = CLogic.QueryCoursesExist();

                            //... if they don't, tell user
                            if (!exist)
                            {
                                #region NO COURSES FOUND. CREATE?
                                Console.WriteLine("There are no courses yet. Do you want to add one(Y/N)?");

                                char answer = '0';
                                while (answer != 'Y' & answer != 'N')
                                {
                                    answer = Console.ReadKey(true).KeyChar;
                                }

                                switch (answer)
                                {
                                    case 'Y':
                                        {
                                            //Prompts user to enter name of new course
                                            Console.WriteLine("Name of new course:");
                                            string newCourse = Console.ReadLine();

                                            //Adds new course
                                            CLogic.AddCourse(newCourse);

                                            break;
                                        }
                                    case 'N':
                                        {
                                            break;
                                        }
                                }
                                #endregion NO COURSES FOUND. CREATE?
                            }
                            else
                            {
                                #region COURSE: QUERY-DISPLAY

                                //QUERY: gets courses from database
                                List<Course> coursesList = new List<Course>(CLogic.QueryCourses());

                                //DISPLAY: writes out name of all the courses, numbered by id
                                CLogic.DisplayCourses(coursesList);

                                Console.WriteLine("What do you want to do?"
                                    + "\nA) Add course"
                                    + "\nR) Remove course"
                                    + "\nB) Back");

                                #endregion COURSE: QUERY-DISPLAY

                                #region COURSE: CHOICE

                                //LOOP MENU
                                char choice = '0';

                                choice = CLogic.InputUntilMatched(choice, 'A', 'R', 'B');
                                
                                #endregion COURSE: CHOICE

                                #region COURSE: BRANCH

                                //BRANCH: ...
                                switch (choice)
                                {
                                    #region ADD COURSE

                                    case 'A':
                                        {
                                            Console.WriteLine("Add new course:");
                                            
                                            CLogic.AddCourse();

                                            /*----User might be asked if they want to create an assignment,
                                            add a student or teacher */

                                            break;
                                        }

                                    #endregion ADD COURSE

                                    #region REMOVE COURSE

                                    case 'R':
                                        {
                                            

                                            Console.WriteLine("Which course do you want to remove (ID / NAME)?");

                                            var search = Console.ReadLine();

                                            var searchedCourse = CLogic.QuerySearchCourse(search);

                                            CLogic.RemoveCourse(searchedCourse);

                                            break;

                                            
                                        }

                                    #endregion REMOVE COURSE

                                    #region BACK

                                    case 'B':
                                        {
                                            break;   
                                        }

                                        #endregion BACK
                                }

                                #endregion COURSE: BRANCH
                            }
                            break;
                        }

                    #endregion BRANCH: COURSE

                    #region BRANCH: PEOPLE

                    case 'P':
                        {
                            #region PEOPLE: QUERY-DISPLAY

                            Console.WriteLine("T) Teachers"
                                + "\nS) Students");

                            CLogic.QueryTeachers();

                            #endregion PEOPLE: QUERY-DISPLAY

                            #region PEOPLE: CHOICE

                            //Inputs until user gives either T or S
                            char menuP = '0';
                            menuP = CLogic.InputUntilMatched(menuP, 'T', 'S');

                            #endregion PEOPLE: CHOICE

                            #region PEOPLE: BRANCH

                            //Branch
                            switch (menuP)
                            {
                                case 'T':
                                    {
                                        //Checks if teachers exist in database ...
                                        bool exist = CLogic.QueryTeachersExist();

                                        //... if they don't, tell user
                                        if (!exist)
                                        {
                                            #region NO TEACHERS FOUND. CREATE?
                                            Console.WriteLine("There are no teachers yet. Do you want to add one(Y/N)?");

                                            char choice = '0';
                                            CLogic.InputUntilMatched(choice, 'Y', 'N');

                                            CLogic.AddTeacher();

                                            #endregion NO TEACHERS FOUND. CREATE?
                                        }
                                        else
                                        {
                                            #region TEACHER: QUERY-DISPLAY
                                            
                                            //QUERY: gets courses from database
                                            List<Teacher> teachersList = new List<Teacher>(CLogic.QueryTeachers());

                                            //DISPLAY: writes out name of all the courses, numbered by id
                                            CLogic.DisplayTeachers(teachersList);

                                            Console.WriteLine("What do you want to do?"
                                                + "\nA) Add course"
                                                + "\nR) Remove course"
                                                + "\nB) Back");

                                            #endregion TEACHER: QUERY-DISPLAY

                                            #region TEACHER: CHOICE
                                            
                                            char menuC = '0';

                                            menuC = CLogic.InputUntilMatched(menuC, 'A', 'R', 'B');

                                            #endregion TEACHER: CHOICE

                                            #region TEACHER: BRANCH

                                            #endregion TEACHER: BRANCH
                                        }
                                        break;
                                    }
                                case 'S':
                                    {
                                        //Checks if students exist in database ...
                                        bool exist = CLogic.QueryStudentsExist();

                                        if (!exist)
                                        {
                                            #region NO STUDENTS FOUND. CREATE?
                                            Console.WriteLine("There are no students yet. Do you want to add one(Y/N)?");

                                            char choice = 'U';

                                            CLogic.InputUntilMatched(choice, 'Y', 'N');

                                            CLogic.AddStudent();

                                            #endregion NO TEACHERS FOUND. CREATE?
                                        }
                                        break;
                                    }

                            }
                            
                            //Not found / create option to be implemented for both students and teachers etc...

                            #endregion PEOPLE: BRANCH

                            break;
                        }

                    #endregion BRANCH: PEOPLE

                    #region BRANCH: QUIT
                    case 'Q':
                        {
                            mainLoop = false;
                            break;
                        }
                        #endregion BRANCH: QUIT
                }

                #endregion MAIN MENU: BRANCH
            }
        }
    }
}
