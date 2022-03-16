using System;
using System.Diagnostics;
using ExtensionMethods;

namespace TSD.Linq.Task3.Lib{
    public class memoryUsage {
        public static void Main(){
            Process proc = new Process();
            proc.memoryUsage();
        }
    }
}