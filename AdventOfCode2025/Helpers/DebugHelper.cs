using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Helpers
{
    public static class DebugHelper
    {
        public static bool Debug = true;
        public static void SetDebug(bool state) => Debug = state;
        public static void Log(string message) { Console.WriteLine(message); }
    }
}
