using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

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
                #region MAIN MENU: USER CHOICE
                Console.WriteLine("Select from menu:\n"
                    + "\tC) Courses"
                    + "\tP) People"
                    + "\tQ) Quit");

                //Gets user choice
                char selection = Console.ReadKey(true).KeyChar;
                selection = char.ToUpper(selection);

                #endregion MAIN MENU: USER CHOICE

                #region MAIN MENU: BRANCH

                //Decides whether to go to courses, people, or to quit app
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
                                Console.WriteLine("There are no courses yet. Do you want to create one (Y/N)?");

                                char answer = 'U';
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
                                    + "A) Add course"
                                    + "R) Remove course"
                                    + "B) Back");

                                #endregion COURSE: QUERY-DISPLAY

                                #region COURSE: CHOICE

                                //LOOP MENU
                                bool courseMenu = true;
                                char menu = 'U';

                                while (courseMenu)
                                {
                                    //Takes menu choice and then converts it to uppercase
                                    menu = Console.ReadKey(true).KeyChar;
                                    menu = Char.ToUpper(menu);

                                    //If answer is valid, break loop
                                    if (menu == 'A' || menu == 'R' || menu == 'B')
                                    {
                                        courseMenu = false;
                                    }
                                }

                                #endregion COURSE: CHOICE

                                #region COURSE: BRANCH

                                //BRANCH: ...
                                switch (menu)
                                {
                                    #region ADD COURSE
                                    case 'A':
                                        {
                                            //Break out of loop after switch
                                            courseMenu = false;

                                            Console.WriteLine("Add new course:");

                                            string name = Console.ReadLine();

                                            CLogic.AddCourse(name);

                                            /*----User might be asked if they want to create an assignment,
                                            add a student or teacher */

                                            break;
                                        }
                                    #endregion ADD COURSE

                                    #region REMOVE COURSE

                                    case 'R':
                                        {
                                            //Break out of loop after switch
                                            courseMenu = false;

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
                                            courseMenu = false;
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
                            Console.WriteLine("T) Teachers"
                                + "S) Students");

                            bool peopleMenu = true;
                            char menu = 'U';

                            while (peopleMenu)
                            {
                                //Takes menu choice and then converts it to uppercase
                                menu = Console.ReadKey(true).KeyChar;
                                menu = Char.ToUpper(menu);

                                //If answer is valid, break loop
                                if (menu == 'T' || menu == 'S')
                                {
                                    peopleMenu = false;
                                }
                            }

                            //Branch
                            //Not found / create option to be implemented for both students and teachers etc...

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
