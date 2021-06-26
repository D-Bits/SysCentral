using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace SysCentral
{
    public class Containers
    {
        public Process BootContainer(string image, string name, string volume)
        {
            if (volume == "")
            {
                Process createContainer = Process.Start("powershell.exe", $"docker run {image} --name {name} -v {volume}");

                return createContainer;
            }
            
        }

        public Process StopContainer(string name)
        {
            Process stopContainer = Process.Start("powershell.exe", $"docker stop {name}");

            return stopContainer;
        }
    }
}