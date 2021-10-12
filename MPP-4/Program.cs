using System;
using System.Diagnostics;

namespace MPP_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Beep();
            Process[] processes = Process.GetProcessesByName("GitHubDesktop");
            // ProcessThreadCollection processThreads = proc.Threads;
 
            foreach(Process process in processes)
            {
                Console.WriteLine($"Handle: {process.Handle} ID: {process.Id}  Name: {process.ProcessName}");
            }
            // foreach (Process process in Process.GetProcesses())
            // {
            //     Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
            // }
        }
    }
}