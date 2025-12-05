using AdventOfCode2025.Helpers;
using AdventOfCode2025.Tasks;

namespace AdventOfCode2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegisterPrograms();
            Console.WriteLine("Hello World!");
            ProgramLoop();
        }

        private static void ProgramLoop()
        {
            bool exit = false;
            while (!exit)
            {
                MenuHelper.DisplaMenu();
                var input = InputReader.ReadInt();
                if (input is null)
                    continue;
                if (input == 0)
                {
                    exit = true;
                    continue;
                }
                MenuHelper.ChooseMenu((int)input);
            }
        }

        private static void RegisterPrograms()
        {
            new _01();
            new _02();
            new _03();
            new _04();
            new _05();
        }
    }
}
