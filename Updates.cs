using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SysCentral
{
    public static class Updates
    {
        // Helper method for executing shell commands

        // Automate updates on Windows via Chocolatey, and WSL
        public static void WindowsUpdates()
        {
            Process.Start("CMD.exe", "/K choco upgrade all");
        }

        // Automate updates on MacOS via Homebrew
        public static void HomebrewUpdates()
        {
            string UpdateHomebrew = "brew update";
            var UpdateHomebrewExec = Process.Start("bin/bash", UpdateHomebrew);
            Console.WriteLine(UpdateHomebrewExec);

            string updateCmd = "brew upgrade";
            var UpdateCmdExec = Process.Start("bin/bash", updateCmd);
            Console.WriteLine(UpdateCmdExec);
        }

        // Automate updates on Linux via APT
        public static void AptUpdates()
        {
            Process proc = new Process();
            // Update APT
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