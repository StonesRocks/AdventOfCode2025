using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Helpers
{
    public static class InputReader
    {
        public static List<string> ReadMultiple()
        {
            List<string> values = new();
            string? current = Console.ReadLine();
            while (true)
            {
                if (current == "" || current == null) break;
                values.Add(current);
                current = Console.ReadLine();
            }

            return values;
        }

        public static int? ReadInt()
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            else return null;
        }
    }
}
