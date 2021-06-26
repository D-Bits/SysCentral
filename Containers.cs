using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace SysCentral
{
    public class Containers
    {
        // Boot a container, plus assign it a name and (optionally) a volume.
        public Process BootContainer(string image, string name, string volume)
        {
            if (volume == "")
            {
                Process createContainer = Process.Start("powershell.exe", $"docker run {image} --name {name}");

                return createContainer;
            }
            else
            {
                Process createContainer = Process.Start("powershell.exe", $"docker run {image} --name {name} -v {volume}");

                return createContainer;
            }
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
        }
    }
}