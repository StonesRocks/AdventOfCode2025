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
            ParseAlignmentInput(inputLines, out long sum);
            Console.WriteLine($"Result for p1: {resultp1} \nResult for p2: {sum}");
        }

        private void ParseAlignmentInput(List<string> lines, out long sum)
        {
            sum = 0;
            long partialSum = 0;
            string? currentOperation = null;
            // loop through columns
            for (int idx = 0; idx < lines[0].Length; idx++)
            {
                string valueContainer = string.Empty;
                // catch operator
                string operationString =  lines[lines.Count-1][idx].ToString();
                if (string.IsNullOrEmpty(operationString) || operationString == " ") {}
                else 
                {
                    currentOperation = operationString; 
                    DebugHelper.Log($"Operation found: {currentOperation}");
                }
                // catch all digits in column
                foreach(var line in lines)
                {
                    string stringDigit = line[idx].ToString();
                    if (long.TryParse(stringDigit, out var digit))
                    {
                        valueContainer += digit;
                    }

                }
                //DebugHelper.Log($"Column value was: {valueContainer}");
                // if no number was found in column then reset operator
                if (valueContainer.Length > 0 && long.TryParse(valueContainer, out var value))
                {
                    if (currentOperation is null) {}
                    else if (currentOperation == "*")
                    {
                        if (partialSum is 0) { partialSum = 1; }
                        partialSum *= value;
                    }
                    else if (currentOperation == "+")
                    {
                        partialSum += value;
                    }
                    DebugHelper.Log($"Operation: {currentOperation}, value: {value}, partialSum; {partialSum}");
                }
                else
                {
                    DebugHelper.Log($"Adding {partialSum} to {sum}");
                    var previousSum = sum;
                    sum += partialSum;
                    currentOperation = null;
                    partialSum = 0;
                }
                if (idx == lines[0].Count() - 1)
                {
                    DebugHelper.Log($"Adding {partialSum} to {sum}");
                    var previousSum = sum;
                    sum += partialSum;
                    currentOperation = null;
                    partialSum = 0;
                }
                // parse until full column is empty.
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
