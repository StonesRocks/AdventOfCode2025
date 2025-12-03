using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _03 : BaseTask
    {
        private int ChooseTwoSum = 0;
        public _03() : base(nameof(_03)) { }

        public override void RunProcess()
        {
            var input = InputReader.ReadMultiple();
            if (input is null || input.Count <= 0) { return; }
            foreach (var value in input)
            {
                ChooseTwo(value);
            }
            Console.WriteLine($"Choose two result: {ChooseTwoSum}");
            Reset();
        }
        public override void Reset()
        {
            ChooseTwoSum = 0;
        }
        private void ChooseTwo(string values)
        {
            int firstValue = 0;
            int secondValue = 0;
            var indexfloor = 0;
            for (int i = 0; i < values.Length-1; i++)
            {
                if (int.TryParse(values[i].ToString(), out int parsedValue))
                {
                    if (parsedValue > firstValue)
                    {
                        firstValue = parsedValue;
                        indexfloor = i;
                    }
                }
            }
            for (int j = indexfloor+1; j < values.Length; j++)
            {
                if (int.TryParse(values[j].ToString(), out int parsedValue))
                {
                    if (parsedValue > secondValue)
                    {            
                        secondValue = parsedValue;
                    }
                }
            }
            ChooseTwoSum += firstValue * 10 + secondValue;
            Console.WriteLine($"From {values} the highest value was {firstValue}{secondValue}");
        }
    }
}
