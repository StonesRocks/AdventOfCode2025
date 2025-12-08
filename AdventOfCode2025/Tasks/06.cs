using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _06 : BaseTask
    {
        List<string> operations = new();
        List<List<long>> lines = new();

        public _06() : base(nameof(_06)) { }

        public override void Reset()
        {
            operations.Clear();
            lines.Clear();
        }

        public override void RunProcess()
        {
            var inputLines = InputReader.ReadMultiple();
            ParseInput(inputLines, out lines, out operations);
            var resultp1 = ParseOperations(lines, operations);
            ParseAlignmentInput(lines, out lines);
            Console.WriteLine($"Result for p1: {resultp1} \nResult for p2: {ParseOperations(lines, operations)}");
        }

        private void ParseAlignmentInput(List<List<long>> lines, out List<List<long>> alignedList)
        {
            alignedList = new();
            for (long columnIndex = 0; columnIndex < lines.Count; columnIndex++)
            {
                //Find largest number of digits
                int maxDigits = lines[(int)columnIndex].Max(x => x.ToString().Length);
                var columnValues = new List<long>(lines[(int)columnIndex])
                    .Select(x => x.ToString())
                    .ToList();
                List<long> alignedValues = new();
                //If the column index is even reverse the strings effectively inverse the reading order
                    if (columnIndex % 2 == 0)
                    {
                        columnValues = columnValues
                            .Select(x => new string(x.Reverse().ToArray()))
                            .ToList();
                    }
                for (int digit = 0; digit < maxDigits; digit++)
                {
                    var newColumnValue = "";

                    //Loop through each value and build the new column value
                    foreach (var value in columnValues)
                    {
                        if (value.Length > digit)
                        {
                            newColumnValue += value[digit];
                        }
                    }
                    //Added the parsed long to the aligned values
                    alignedValues.Add(long.Parse(newColumnValue));
                }
                alignedList.Add(alignedValues);
            }
            foreach (var column in alignedList)
            {
                Console.Write("Aligned Values: ");
                foreach (var value in column)
                {
                    Console.Write($"{value} ");
                }
                Console.WriteLine("");
            }
        }

        private BigInteger ParseOperations(List<List<long>> lines, List<string> operations)
        {
            BigInteger result = 0;
            for (int i = 0; i < operations.Count; i++)
            {
                var currentOperations = operations[i];
                if (currentOperations == "+")
                {
                    long sum = lines[i].Sum();
                    result += sum;
                    //Console.WriteLine($"Sum: {sum}");
                }
                else if (currentOperations == "*")
                {
                    long product = 1;
                    foreach (var item in lines[i])
                    {
                        product *= item;
                    }
                    result += product;
                    //Console.WriteLine($"Product: {product}");
                }
            }
            return result;
        }

        private void ParseInput(List<string> inputLines, out List<List<long>> columnList, out List<string> operations)
        {
            columnList = new();
            operations = new();
            if (inputLines.Count < 2)
            {
                Console.WriteLine("Insufficient input provided.");
                return;
            }
            for (int i = 0; i < inputLines.Count - 1; i++)
            {
                var parsedInput = inputLines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Select(x => long.Parse(x))
                    .ToList();
                for (int j = 0; j < parsedInput.Count; j++)
                {
                    if (columnList.Count <= j)
                    {
                        columnList.Add(new List<long>());
                    }
                    columnList[j].Add(parsedInput[j]);
                }
            }
            operations = inputLines[inputLines.Count - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            for (int i = 0; i < operations.Count; i++)
            {
                Console.Write($"Operation : {operations[i]}\t Values: ");
                    foreach(var value in columnList[i])
                    {
                        Console.Write($"{value} ");
                    }
                Console.WriteLine("");
            }
        }
    }
}
