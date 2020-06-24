using System;
using System.Collections.Generic;

namespace SysCentral
{
    public class Program
    {
        static void UserOptions()
        {
            Dictionary<int, string> FileSysOptions = new Dictionary<int, string>();

            FileSysOptions.Add(0, "Exit program.");
            FileSysOptions.Add(1, "File/Directory Tasks.");
            FileSysOptions.Add(2, "Automate Updates.");
            FileSysOptions.Add(3, "Get Various System Information.");

            foreach (var item in FileSysOptions)
            {
                Console.WriteLine(item);
            }
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
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
