using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Net;

/*
* Functions for gathering info about the host device.
*/

namespace SysCentral
{
    public class SysInfo
    {
        // Get info about the user's operating system
        public static void OsInfo()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***Operating System Information***");
                Console.WriteLine();
                Console.WriteLine("OS Version: " + RuntimeInformation.OSDescription);
                Console.WriteLine("Host Name: " + Environment.MachineName.ToString());
                Console.WriteLine("64-bit OS?: " + Environment.Is64BitOperatingSystem.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void HardwareInfo()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***Hardware Information***");
                Console.WriteLine();
                // Get hardware architecture 
                Console.WriteLine("Architecture: ", Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
                Console.WriteLine("CPU Identifier: ", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        public static void NetworkInfo()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostInfo = Dns.GetHostEntry("localhost");

            try
            {
                Console.WriteLine();
                Console.WriteLine("***Network Information***");
                Console.WriteLine();
                Console.WriteLine("Host Name: " + Dns.GetHostName());
                Console.WriteLine("IP Address: " +  Dns.GetHostEntry(hostName).AddressList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        public static void SysInfoOptions()
        {
            Dictionary<int, string> SysInfoChoices = new Dictionary<int, string>();

            SysInfoChoices.Add(1, "Get Operating System Info.");
            SysInfoChoices.Add(2, "Get Hardware Info.");
            SysInfoChoices.Add(3, "Get Network Info");

            foreach (KeyValuePair<int, string> value in SysInfoChoices)
            {
                Console.WriteLine(value);
            }

            Console.Write("Select an option, based on the above options: ");
            int UserChoice = Convert.ToInt32(Console.ReadLine());
        
            if (UserChoice == 1)
            {
                OsInfo();
            }
            else if (UserChoice == 2)
            {
                HardwareInfo();
            }
            else if (UserChoice == 3)
            {
                NetworkInfo();
            }
            else
            {
                Console.WriteLine("Invalid selection. Please choose again.");
                SysInfoOptions();
            }
        }
    }
}