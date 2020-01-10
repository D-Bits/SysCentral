using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SysCentral
{
    public class FileSys
    {
        // Create multiple directories in a given location
        public static void CreateDirs(string path, int dirNum)
        {
            try
            {
                Directory.SetCurrentDirectory(path);

                for (int i = 0; i < dirNum; i++)
                {
                    Console.Write("Enter a name for the directory you want to create: ");
                    string dirName = Console.ReadLine();
                    Directory.CreateDirectory(dirName);
                }

                Console.WriteLine("Your directories have been created.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }    
        }

        // Calculate a SHA256 file checksum
        public static string GetFileChecksum(string SourceFile)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(SourceFile))
                    {
                        return BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Compare two checksums to see if they match
        public static bool CompareHashes(string hash1, string hash2)
        {
            if (hash1 == hash2)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public static void FileSysOptions()
        {
            Dictionary<int, string> FileSysChoices = new Dictionary<int, string>();

            FileSysChoices.Add(1, "Create directories");
            FileSysChoices.Add(2, "Calculate a SHA256 file checksum.");
            FileSysChoices.Add(3, "Compare two file checksums.");

            foreach (KeyValuePair<int, string> value in FileSysChoices)
            {
                Console.WriteLine(value);
            }

            Console.Write("Select an option, based on the above options: ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                Console.Write("Enter the full path of where you want to create your directories: ");
                string userPath = Console.ReadLine();
                Console.Write("Enter the number of directories you want to create: ");
                int userDirNum = Convert.ToInt32(Console.ReadLine());

                CreateDirs(userPath, userDirNum);
            }
            else if (userChoice == 2)
            {
                Console.Write("Enter the full path of the file you want to hash: ");
                string userFile = Console.ReadLine();
                Console.Write("Your SHA256 Hash is: ");
                Console.WriteLine(GetFileChecksum(userFile));
            }
            else if (userChoice == 3)
            {
                Console.Write("Enter the first hash: ");
                string firstHash = Console.ReadLine();

                Console.Write("Enter the second hash: ");
                string secondHash = Console.ReadLine();
                Console.WriteLine(CompareHashes(firstHash, secondHash));
            }
            else
            {
                Console.WriteLine("Invalid option selected. Program terminated");
            }
        }
    }
}