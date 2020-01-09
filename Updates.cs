using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SysCentral
{
    // Functions to automate updates via package managers
    public static class Updates
    {
        // Automate updates on Windows via Chocolatey, and WSL
        public static void WindowsUpdates()
        {
            try
            {
                var ChocoUpdates = Process.Start("CMD.exe", "/K choco upgrade all");
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
                var HomebrewUpdate = Process.Start("bin/bash", "/K brew update");
                // Update all installed packages
                var HomebrewUpgrade = Process.Start("bin/bash", "/K brew upgrade");
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
                var AptUpdate = Process.Start("bin/bash", "/K sudo apt-get update");
                // Update all installed packages
                var AptUpgrade = Process.Start("bin/bash", "/K sudo apt-get upgrade");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        
        public static void UpdatesMain()
        {
            // Prompt the user to choose what platform they use.
            Console.Write("Enter 1 for Windows updates, 2 for Linux (APT) updates, and 3 Homebrew Updates: ");
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
        }
    }

}