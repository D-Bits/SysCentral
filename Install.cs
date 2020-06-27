using System;
using System.Diagnostics;
using System.Collections.Generic;

/*
 <summary>
  Functions to lookup and install software via various 
  package managers.
 </summary>
*/

namespace SysCentral
{
    public class Install
    {
        public static Process ChocolateyLookup(string pkgName)
        {
            Process chocoSearch = Process.Start("powershell.exe", $"choco list {pkgName}");

            return chocoSearch;
        }

        public static Process ChocolateyInstall(string pkgName)
        {
            Process chocoInstall = Process.Start("powershell.exe", $"choco install {pkgName}");

            return chocoInstall;        
        }

        public static void InstallChoices()
        {
            Dictionary<int, string> InstallOptions = new Dictionary<int, string>();

            InstallOptions.Add(0, "Back to Main Menu.");
            InstallOptions.Add(1, "Look up a program on Chocolatey.");
            InstallOptions.Add(2, "Install a program from Chocolatey.");

            Console.WriteLine();

            foreach (var option in InstallOptions)
            {
                Console.WriteLine(option);
            }

            Console.WriteLine();

            Console.Write("Select an option, based on the above options: ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            if (userChoice == 0)
            {
                Program.Main(null);
            }
            else if (userChoice == 1)
            {
                // Prompt the user to enter the name of a package
                Console.Write("Enter the name of a package you want to look up via Chocolatey: ");
                string userPkg = Console.ReadLine();
                ChocolateyLookup(userPkg);
                Console.ReadKey();
            }
            else if (userChoice == 2)
            {
                // Prompt the user to enter the name of a package
                Console.Write("Enter the name of a package you want to look up via Chocolatey: ");
                string userPkg = Console.ReadLine();
                ChocolateyInstall(userPkg);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("*Invalid selection. Please choose again.");
                InstallChoices();
            }
        }
    }
}