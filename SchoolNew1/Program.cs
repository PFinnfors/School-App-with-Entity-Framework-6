using System;
using System.Data.Entity;
using System.Linq;

namespace SchoolNew1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Disables initialization for SchoolContext
            Database.SetInitializer(new NullDatabaseInitializer<SchoolContext>());

            //Object for custom class with data handling functions
            ConsoleLogic CLogic = new ConsoleLogic();

            //Intro
            Console.WriteLine("Welcome to the school app!\n");

            //MAIN LOOP: for stepping back to main menu
            bool mainLoop = true;
            while (mainLoop)
            {
                Console.WriteLine("Select from menu:\n"
                    + "\tC) Courses"
                    + "\tP) People"
                    + "\tQ) Quit");

                //Gets user choice
                char selection = Console.ReadKey(true).KeyChar;
                char.ToUpper(selection);

                //Decides whether to go to courses, people, or to quit app
                switch (selection)
                {
                    #region BRANCH: COURSE
                    case 'C':
                        {
                            //Checks if courses exist in database
                            bool exist = CLogic.QueryCoursesExist();

                            //If they don't, tell user
                            if(!exist)
                            {
                                Console.WriteLine("There are no courses yet. Do you want to create one?");
                            }
                            else
                            {
                                //QUERY: gets courses from database
                                var coursesList = CLogic.QueryCourses();

                                //DISPLAY: writes out name of all the courses, numbered by id
                                CLogic.DisplayCourses(coursesList);

                                Console.WriteLine("What do you want to do?"
                                    + "A) Add course"
                                    + "R) Remove course"
                                    + "B) Back");

                                //LOOP MENU
                                bool courseMenu = true;
                                while (courseMenu)
                                {
                                    //Takes menu choice and converts to uppercase
                                    var menu = Console.ReadKey(true).KeyChar;
                                    Char.ToUpper(menu);

                                    //BRANCH: ...
                                    switch(menu)
                                    {
                                        case 'A':
                                            {
                                                Console.WriteLine("Add new course:");
                                                //CLogic.AddCourse();
                                                break;
                                            }
                                        case 'R':
                                            {
                                                Console.WriteLine("What course do you want to remove (ID or NAME)?");
                                                //CLogic.SearchCourse();
                                                //CLogic.RemoveCourse();
                                                break;
                                            }
                                        case 'B':
                                            {
                                                courseMenu = false;
                                                break;
                                            }
                                    }

                                    //INPUT: finds the course with a user-selected id
                                    //var selectedCourse = CLogic.GetCourseById(coursesList);

                                }
                            }
                            
                            break;
                        }
                    #endregion BRANCH: COURSE
                    #region BRANCH: PEOPLE
                    case 'P':
                        {
                            //CLogic.asdadsd();
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
            }
            
            Console.ReadKey();
        }
    }
}
