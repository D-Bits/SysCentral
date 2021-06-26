using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace SysCentral
{
    public class Containers
    {
        // Boot a generic container, plus assign it a name and (optionally) a volume.
        public Process BootContainer(string image, string name)
        {
            Process createContainer = Process.Start("powershell.exe", $"docker run {image} --name {name}");

            return createContainer;
        }

        // Boot a named Postgres container, with a volume, and specified version
        public Process BootPostgres(string name, string volume, double version)
        {
            Process createContainer = Process.Start("powershell.exe", $"docker run postgres:{version}-alpine --name {name} -v {volume}:/var/lib/postgresql/data/");

            return createContainer;
        }

        // Stop a running, named container
        public Process StopContainer(string name)
        {
            Process stopContainer = Process.Start("powershell.exe", $"docker stop {name}");

            return stopContainer;
        }

        // Restart a named container
        public Process RestartContainer(string name)
        {
            Process restartContainer = Process.Start("powershell.exe", $"docker restart {name}");

            return restartContainer;
        }

        // Run docker system prune
        public Process PruneSystem()
        {
            Process prune = Process.Start("powershell.exe", "docker system prune");

            return prune;
        }

        // Run docker system info
        public Process SystemInfo()
        {
            Process sysinfo = Process.Start("powershell.exe", "docker system info");

            return sysinfo;
        }

        public static void ContainerChoices()
        {
            Dictionary<int, string> ContainerOptions = new Dictionary<int, string>();

            ContainerOptions.Add(0, "Back to Main Menu.");
            ContainerOptions.Add(1, "Boot a Container.");
            ContainerOptions.Add(2, "Create a Postgres Container, with a Volume.");
            ContainerOptions.Add(3, "Stop a Running Container.");
            ContainerOptions.Add(4, "Restart a Running Container.");
            ContainerOptions.Add(5, "Run docker system prune.");
            ContainerOptions.Add(6, "Get Docker System Info");

            Console.WriteLine();

            foreach (var option in ContainerOptions)
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
                // Get image name from stdin
                Console.Write("Enter an image name: ");
                string imageName = Console.ReadLine();

                // Get container name from stdin
                Console.Write("Enter a name for your container: ");
                string containerName = Console.ReadLine();

                BootContainer(imageName, containerName);
            }
            else if (userChoice == 2)
            {
                // Get container name from stdin
                Console.Write("Enter a name for your container: ");
                string containerName = Console.ReadLine();
                // Get a volume name from stdin
                Console.Write("Enter a name for your volume: ");
                string volumeName = Console.ReadLine();
                // Get a version number from stdin
                Console.Write("Enter which version of Postgres you want to use: ");
                double versionNo = Convert.ToDouble(Console.ReadLine());

                BootPostgres(containerName, volumeName, versionNo);
            }
            else
            {
                Console.WriteLine("*Invalid selection. Please choose again.");
                ContainerChoices();
            }
        }
    }
}