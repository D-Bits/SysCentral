using System;
using System.Diagnostics;
/*
*<summary>
  Functions to automate updates via various 
  package managers.
*</summary>
*/
namespace SysCentral
{
    // Functions to automate updates via package managers
    public static class Updates
    {
        // Automate updates on Windows via Chocolatey
        public static void WindowsUpdates()
        {
            try
            {
                // Update all packages install via Chocolatey
                Process ChocoUpdates = Process.Start("CMD.exe", "/K choco upgrade all");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        // Automate updates on MacOS via Homebrew
        public static void HomebrewUpdates()
        {
            try
            {
                // Ensure downloadable packages are up-to-date
                Process HomebrewUpdate = Process.Start("/bin/bash", "-c brew update");
                // Update all installed packages
                Process HomebrewUpgrade = Process.Start("/bin/bash", "-c brew upgrade");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        // Automate updates on Linux via APT
        public static void AptUpdates()
        {
            try
            {
                // Ensure downloadable packages are up-to-date
                var AptUpdate = Process.Start("/bin/bash", "-c sudo apt-get update");
                // Update all installed packages
                var AptUpgrade = Process.Start("/bin/bash", "-c sudo apt-get upgrade");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        
        public static void UpdatesOptions()
        {
            // Prompt the user to choose what platform they use.
            Console.Write("Enter 1 for Windows updates, 2 for Linux (APT) updates, 3 Homebrew Updates, and 0 to return to main: ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                WindowsUpdates();
            }
            else if (userChoice == 2)
            {
                AptUpdates();
            }
            else if (userChoice == 3)
            {
                HomebrewUpdates();
            }
            else 
            {
                Program.Main(null);
            }
        }
    }

}