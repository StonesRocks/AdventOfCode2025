using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _03 : BaseTask
    {
        private int ChooseTwoSum = 0;
        private long ChooseTwelveSum = 0;
        public _03() : base(nameof(_03)) { }

        public override void RunProcess()
        {
            var input = InputReader.ReadMultiple();
            if (input is null || input.Count <= 0) { return; }
            foreach (var value in input)
            {
                ChooseTwo(value);
                ChooseTwelve(value);
            }
            Console.WriteLine($"Choose two result: {ChooseTwoSum}\nChoose Twelve result: {ChooseTwelveSum}");
            Reset();
        }
        public override void Reset()
        {
            ChooseTwoSum = 0;
            ChooseTwelveSum = 0;
        }
        private void ChooseTwelve(string battery)
        {
            int availableIndex = battery.Length - 11;
            int bestValue = 0;
            int availableIndexFloor = 0;
            List<int> availableValues = battery.Select(c => int.Parse(c.ToString())).ToList();
            List<int> result = new List<int>();

            //Console.WriteLine($"Length of battery: {battery.Length}, battery: {battery}\tAvilable searchable index size: {availableIndex}");
            for(int currentTargetIndex = 0; currentTargetIndex < 12; currentTargetIndex++)
            {
                var bestValueSubIndex = 0;
                
                for (int index=0; index < availableIndex; index++)
                {
                    var value = availableValues[availableIndexFloor+index];
                    //Console.WriteLine($"Current value: {value}");
                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestValueSubIndex = index;
                        //Console.WriteLine($"Current best: {bestValue}");
                    }
                }
                availableIndex -= bestValueSubIndex;
                availableIndexFloor += bestValueSubIndex + 1;
                result.Add(bestValue);
                bestValue = 0;
                //Console.WriteLine($"Available interval: {availableIndex}, Index floor: {availableIndexFloor}");
            }
            ChooseTwelveSum += long.Parse(string.Join("", result));
            //Console.WriteLine($"From {battery} the highest 12 digit value was {string.Join("", result)}");
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
            //Console.WriteLine($"From {values} the highest value was {firstValue}{secondValue}");
        }
    }
}
