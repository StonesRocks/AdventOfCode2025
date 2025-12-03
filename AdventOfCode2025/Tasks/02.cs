using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _02 : BaseTask
    {
        private List<Tuple<long, long>> rangeList = new List<Tuple<long, long>>();
        private long DoubleRepeatSum = 0;
        private long FullRepeatSum = 0;
        public _02() : base(nameof(_02)) { }

        public override void RunProcess()
        {
            Reset();
            SetRange();
            foreach (var item in rangeList)
            {
                Console.WriteLine($"\tCurrent List: {item.Item1}-{item.Item2}");
                FindInvalidId(item.Item1, item.Item2);
            }
            Console.WriteLine($"Double repeat result: {DoubleRepeatSum}");
            Console.WriteLine($"Full repeat result: {FullRepeatSum}");
            return;
        }
        public override void Reset()
        {
            DoubleRepeatSum = 0;
            FullRepeatSum = 0;
            rangeList.Clear();
        }

        private void FindInvalidId(long min, long max)
        {
            for (long current = max; current >= min; current--)
            {
                DoubleRepeat(current);
                FullRepeat(current);
            }
        }

        private void DoubleRepeat(long current)
        {
            string currentString = current.ToString();
            if (currentString.Length%2 == 1) { return; }
            var subStringLenght = currentString.Length/2;
            string firstString = currentString.Substring(0, subStringLenght);
            string secondString = currentString.Substring(subStringLenght);

            if (firstString == secondString && firstString[0] != '0')
            {
                //Console.WriteLine($"DoubleRepeat values: {current}, {firstString}, {secondString}");
                DoubleRepeatSum += current;
            }
        }
        private void FullRepeat(long current)
        {
            var currentValue = current.ToString();
            if (currentValue is null) {  return; }
            var selectionLength = (int)(currentValue.Length / 2);
            for (int targetIndices = selectionLength; targetIndices >= 1; targetIndices--)
            {
                var maxIndex = (long)(currentValue.Length - targetIndices);
                //Console.WriteLine($"string: {currentValue}\tindicesLength: {targetIndices}\tTarget index: {targetIndices}\tMax index: {maxIndex}");
                for (int firstIndex = 0; firstIndex + targetIndices <= maxIndex; firstIndex++)
                {
                    var secondIndex = firstIndex + targetIndices;
                    var firstString = currentValue.Substring(firstIndex, targetIndices);
                    var potentialRepeatString = firstString;
                    while (potentialRepeatString.Length < currentValue.Length)
                    {
                        if (potentialRepeatString.Length == currentValue.Length) { break; }
                        potentialRepeatString += firstString;
                    }
                    if (potentialRepeatString.Length != currentValue.Length) { continue; }

                    if (potentialRepeatString == currentValue)
                    {
                        FullRepeatSum += current;
                        Console.WriteLine($"Value traced: {firstString} \tRepeat match found: {potentialRepeatString}");
                        return;
                    }

                }
            }
            return;
        }
        private void SetRange()
        {
            rangeList.Clear();
            var listOfRanges = InputReader.ReadSeparatedValues(',');
            if (listOfRanges is null) { return; }
            foreach (var rangeString in listOfRanges)
            {
                var separatorIndex = rangeString.IndexOf('-');   
                var minValueString = rangeString.Substring(0, separatorIndex);
                var maxValueString = rangeString.Substring(separatorIndex + 1);
                if (long.TryParse(minValueString, out var minValue) && long.TryParse(maxValueString, out var maxValue))
                {
                    //Console.WriteLine($"Range found: {minValue}, {maxValue}");
                    rangeList.Add(new Tuple<long, long>(minValue,maxValue));                
                }
                else { return; }
            }
        }
    }
}
