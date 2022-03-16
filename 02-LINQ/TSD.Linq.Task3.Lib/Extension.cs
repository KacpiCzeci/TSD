using System;
using System.Diagnostics;

namespace ExtensionMethods{
    public static class ProcessExtensions{
        public static void memoryUsage(this Process process){
            Process[] processlist = Process.GetProcesses();

            long totalMemory = 0;

            Console.WriteLine("<----------Memory usage of your Processes---------->\n");
            foreach (Process proc in processlist) {
                long tempMemory = proc.WorkingSet64;
                Console.WriteLine("Process: {0} ID: {1} Memory: {2} B \n", proc.ProcessName, proc.Id, tempMemory);
                totalMemory += tempMemory;
            }
            Console.WriteLine("Total Memory Usage: {0} B \n", totalMemory);
        }
    }
}