using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _05 : BaseTask
    {
        private List<long> values = new();
        private List<Tuple<long, long>> ranges = new();
        private List<long> verifiedFresh = new();
        public _05() : base(nameof(_05)) { }
        public override void RunProcess()
        {
            var input = InputReader.ReadMultiple(".");
            ProcessInput(input);
            MergeFreshRange();
            foreach (var range in ranges)
            {
                FreshCheck(range);
            }
            CalculateTotalFresh();
            Console.WriteLine($"Found {verifiedFresh.Count} ingredients");
            Reset();
            return;
        }
        private void CalculateTotalFresh()
        {
            long totalFresh = 0;
            foreach(var range in ranges)
            {
                totalFresh += (range.Item2 - range.Item1) + 1;
            }
            Console.WriteLine($"Total fresh ingredients in ranges: {totalFresh}");
            return;
        }
        private void MergeFreshRange()
        {
            List<Tuple<long, long>> mergedRanges = new List<Tuple<long, long>>(ranges);

            bool changed = true;
            while (changed)
            {
                changed = false;
                Dictionary<long, long> newMergedRanges = new();
                for (int i = 0; i < mergedRanges.Count; i++)
                {
                    var currentLowerRange = mergedRanges[i].Item1;
                    var currentUpperRange = mergedRanges[i].Item2;
                    newMergedRanges[currentLowerRange] = currentUpperRange;
                    for (int j = 0; j < mergedRanges.Count; j++)
                    {
                        var targetLowerRange = mergedRanges[j].Item1;
                        var targetUpperRange = mergedRanges[j].Item2;
                        if (targetLowerRange < currentLowerRange && 
                            currentUpperRange >= targetLowerRange &&
                            currentUpperRange <= targetUpperRange)
                        {
                            // decrease lower range
                            changed = true;
                            newMergedRanges.Remove(currentLowerRange);
                            newMergedRanges[targetLowerRange] = currentUpperRange;
                            currentLowerRange = targetLowerRange;
                        }
                        if (targetUpperRange > currentUpperRange &&
                            currentUpperRange >= targetLowerRange &&
                            targetLowerRange >= currentLowerRange)
                        {
                            // increase upper range
                            changed = true;
                            newMergedRanges[currentLowerRange] = targetUpperRange;
                            currentUpperRange = targetUpperRange;
                        }
                        if (targetLowerRange <= currentLowerRange && 
                            currentUpperRange <= targetUpperRange && 
                            !(currentLowerRange == targetLowerRange && currentUpperRange == targetUpperRange))
                        {
                            // fully contained, remove current
                            changed = true;
                            newMergedRanges.Remove(currentLowerRange);
                            newMergedRanges[targetLowerRange] = targetUpperRange;
                            currentLowerRange = targetLowerRange;
                            currentUpperRange = targetUpperRange;
                        }
                    }
                }
                mergedRanges = new List<Tuple<long, long>>();
                foreach (var range in newMergedRanges)
                {
                    mergedRanges.Add(new Tuple<long, long>(range.Key, range.Value));
                }
            }
            //Console.WriteLine($"Refined Ranges:");
            //foreach(var range in mergedRanges)
            //{
            //    Console.WriteLine($"{range.Item1}-{range.Item2}");
            //}
            ranges = mergedRanges;
            return;
        }
        private void FreshCheck(Tuple<long, long> range)
        {
            List<long> unverifiedList = new();
            foreach(var value in values)
            {
                if (value >= range.Item1 && value <= range.Item2)
                {
                    if (!verifiedFresh.Contains(value))
                    {
                        //Console.WriteLine($"Fresh value found: {value}");
                        verifiedFresh.Add(value);
                    }
                }
                else
                {
                    unverifiedList.Add(value);
                }
            }
            values = unverifiedList;
            return;
        }
        private void ProcessInput(List<string> input)
        {
            if (input == null)
            {
                Console.WriteLine("Input is null");
                return;
            }
            foreach (var item in input)
            {
                if(string.IsNullOrEmpty(item)) continue;
                if (item.Contains('-'))
                {
                    var minValue = long.Parse(item.Split('-')[0]);
                    var maxValue = long.Parse(item.Split('-')[1]);
                    ranges.Add(new Tuple<long, long>(minValue, maxValue));
                    //Console.WriteLine($"Range found: {minValue}-{maxValue}");
                }
                if (long.TryParse(item, out long value))
                {
                    //Console.WriteLine($"Value found: {value}");
                    values.Add(value);
                }
            }

            return;
        }
        public override void Reset()
        {
            values.Clear();
            ranges.Clear();
            verifiedFresh.Clear();
            return;
        }
    }
}
