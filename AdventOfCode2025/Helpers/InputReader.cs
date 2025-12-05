using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Helpers
{
    public static class InputReader
    {
        public static List<string> ReadMultiple(string escape = "")
        {
            List<string> values = new();
            string? current = Console.ReadLine();
            while (true)
            {
                if (current == escape || current == null) break;
                values.Add(current);
                current = Console.ReadLine();
            }

            return values;
        }
        public static bool ReadBool(string message)
        {
            Console.WriteLine(message + " (y/n)");
            var input = Console.ReadLine();
            if (bool.TryParse(input, out bool value))
            {
                return value;
            }
            if (input == "1") return true;
            if(input == "y") return true;
            if(input == "yes") return true;
            else return false;
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

        public static List<string>? ReadSeparatedValues(char separator)
        {
            var values = new List<string>();
            var stringConstruct = "";

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return null;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == separator)
                {
                    values.Add(stringConstruct);
                    stringConstruct = "";
                }
                else
                {
                    stringConstruct += input[i];
                }
            }
            values.Add(stringConstruct);
            return values;
        }
    }
}
