using System;
using System.Collections.Generic;

namespace SysCentral
{
    public class Program
    {
        static void UserOptions()
        {
            Dictionary<int, string> MainMenuOptions = new Dictionary<int, string>();

            MainMenuOptions.Add(0, "Exit program.");
            MainMenuOptions.Add(1, "File/Directory Tasks.");
            MainMenuOptions.Add(2, "Automate Updates.");
            MainMenuOptions.Add(3, "Get Various System Information.");
            MainMenuOptions.Add(4, "(*May need to be run w/ root*) Look up and Install Packages via Various Package Managers.");
            MainMenuOptions.Add(5, "Manage Docker Containers.");

            Console.WriteLine();

            foreach (var item in MainMenuOptions)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            try
            {
                UserOptions();    
                Console.Write("Enter an int, based on the above options: ");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 0)
                {
                    Environment.Exit(0);
                }
                else if (userChoice == 1)
                {
                    FileSys.FileSysOptions();
                    Console.WriteLine();
                }
                else if (userChoice == 2)
                {
                    Updates.UpdatesOptions();
                    Console.WriteLine();
                }
                else if (userChoice == 3)
                {
                    SysInfo.SysInfoOptions();
                    Console.WriteLine();
                }
                else if (userChoice == 4)
                {
                    Install.InstallChoices();
                    Console.WriteLine();
                }
                else if (userChoice == 5)
                {
                     Containers.ContainerChoices();
                     Console.WriteLine();
                }
                else 
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid option. Please enter a valid int.");
                    Console.WriteLine();
                    Main(null);
                }
            }       
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine();
                Console.Write("We apologize for the error. Press any key to exit.");
                Console.ReadKey();
            }   
        }
    }
}
