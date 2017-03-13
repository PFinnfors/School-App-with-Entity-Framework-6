using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNew1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogic CLogic = new ConsoleLogic();

            Console.WriteLine("Welcome to the school database!\n");

            //
            var query = CLogic.QueryCoursesExist();

            //
            if (!query)
            {
                Console.WriteLine("\nThere are no courses in the school database!\nA default will be created.\n");

                CLogic.CreateCourse("Biology I");
            }
            //
            else
            {
                Console.WriteLine("Select from menu:\n"
                    + "1) Get courses");

                char selection = Console.ReadKey(false).KeyChar;

                switch (selection)
                {
                    case '1':
                        {
                            Console.WriteLine("");
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }




            Console.ReadKey();
        }

        
    }
}
