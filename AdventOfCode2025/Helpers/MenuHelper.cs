using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Helpers
{
    public static class MenuHelper
    {
        public static Dictionary<string, Delegate> menuItems = new();

        public static void AddMenu(string name, Delegate menuCall)
        {
            menuItems[name] = menuCall;
        }

        public static void DisplaMenu()
        {
            List<string> options = new List<string> { "Exit" };
            foreach (var item in menuItems.Keys)
            {
                options.Add(item);
            }
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i}. {options[i]}");
            }
        }

        public static void ChooseMenu(int input)
        {
            if (input == 0)
            {
                return;
            }
            var stringItems = menuItems.Keys.ToList();
            if (input < 0 || input > stringItems.Count)
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                var method = (Action)menuItems[stringItems[input-1]];
                if (method is not null) { method(); }
            }
        }
    }
}
