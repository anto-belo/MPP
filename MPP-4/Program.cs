using System;
using System.Diagnostics;

namespace MPP_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Process[] processes = Process.GetProcessesByName("GitHubDesktop");
            // ProcessThreadCollection processThreads = proc.Threads;
 
            foreach(Process process in processes)
            {
                Console.WriteLine($"Handle: {process.Handle} ID: {process.Id}  Name: {process.ProcessName}");
                OsHandle handle = new OsHandle(process.Handle);
            }
        }
    }
}