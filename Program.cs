using System;
using System.Collections.Generic;

namespace SysCentral
{
    class Program
    {
        static void UserOptions()
        {
            Dictionary<int, string> FileSysOptions = new Dictionary<int, string>();

            FileSysOptions.Add(1, "File/Directory automation.");

            foreach (var item in FileSysOptions)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {        
            UserOptions();    
            Console.Write("Enter an int, based on the above options: ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                FileSys.FileSysMain();
            }

            // Prompt the user to press enter to exit program
            Console.Write("Press any key to exit program.");
            Console.ReadKey();
        }
    }
}
