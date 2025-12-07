using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _06 : BaseTask
    {
        private long result = 0;
        public _06() : base(nameof(_06)) { }

        public override void Reset()
        {
            base.Reset();
        }

        public override void RunProcess()
        {
            var inputLines = InputReader.ReadMultiple();
            List<List<long>> lines;
            List<string> operations;
            ParseInput(inputLines, out lines, out operations);
            ParseOperation(lines, operations);

            Console.WriteLine($"Result: {result}");
        }

        private void ParseOperation(List<List<long>> lines, List<string> operations)
        {
            for (int i = 0; i < operations.Count; i++)
            {
                var currentOperations = operations[i];
                if (currentOperations == "+")
                {
                    long sum = lines[i].Sum();
                    result += sum;
                    Console.WriteLine($"Sum: {sum}");
                }
                else if (currentOperations == "*")
                {
                    long product = 1;
                    foreach (var item in lines[i])
                    {
                        product *= item;
                    }
                    result += product;
                    Console.WriteLine($"Product: {product}");
                }
            }
        }

        private void ParseInput(List<string> inputLines, out List<List<long>> columnList, out List<string> operations)
        {
            columnList = new List<List<long>>();
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
