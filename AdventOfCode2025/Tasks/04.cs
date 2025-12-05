using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _04 : BaseTask
    {
        private long RemovableRollSum = 0;
        private long RemovableRollRepeatSum = 0;
        public _04() : base(nameof(_04)) { }

        public override void Reset()
        {
            RemovableRollSum = 0;
        }

        public override void RunProcess()
        {
            /*
             * Get all rows
             * Count rows and columns
             * Iterate through all points, if '@' found then check surrounding points
             * check must be within bounds
             * if check more than 3 then skip point.
             */

            var Rows = InputReader.ReadMultiple();
            LessThan4(Rows);
            Console.WriteLine();
            foreach (var row in Rows)
            {
                Console.WriteLine(row);
            }
            RemovableRollSum = RemovableRollRepeatSum;
            Console.WriteLine($"Rolls with less than 4 surrounding: {RemovableRollSum}");
            var repeat = InputReader.ReadBool("Repeat until all rolls are found?");
            while (repeat)
            {
                var recordedValue = RemovableRollRepeatSum;
                ClearRemovableRolls(Rows);
                LessThan4(Rows);
                if (recordedValue == RemovableRollRepeatSum)
                {
                    repeat = false;
                    break;
                }
            }
            Console.WriteLine($"Result once: {RemovableRollSum}\nResult after repeat: {RemovableRollRepeatSum}");
        }

        private void ClearRemovableRolls(List<string> Rows)
        {
            var RowCount = Rows.Count;
            var ColumnCount = Rows[0].Length;
            for (int y = 0; y < RowCount; y++)
            {
                for(int x = 0; x < ColumnCount; x++)
                {
                    if (Rows[y][x] == 'x')
                    {
                        var newRow = Rows[y];
                        newRow = newRow.Remove(x, 1).Insert(x, ".");
                        Rows[y] = newRow;
                    }
                }
            }
        }

        private void LessThan4(List<string> Rows)
        {
            if (Rows.Count == 0) { return; }
            var RowCount = Rows.Count;
            var ColumnCount = Rows[0].Length;

            for (int y = 0; y < RowCount; y++)
            {
                for(int x = 0; x < ColumnCount; x++)
                {
                    if (Rows[y][x] == '@')
                    {
                        bool valid = true;
                        int surroundingAtCount = 0;
                        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
                        {
                            if (!valid) { continue; }
                            for (int colOffset = -1; colOffset <= 1; colOffset++)
                            {
                                if (!valid) { continue; }
                                if (rowOffset == 0 && colOffset == 0) continue;
                                int newRow = y + rowOffset;
                                int newCol = x + colOffset;
                                if (newRow >= 0 && newRow < RowCount && newCol >= 0 && newCol < ColumnCount)
                                {
                                    if (Rows[newRow][newCol] == '@' || Rows[newRow][newCol] == 'x')
                                    {
                                        surroundingAtCount++;
                                        if (surroundingAtCount >= 4)
                                        {
                                            valid = false;
                                        }
                                    }
                                }
                            }
                        }
                        if (surroundingAtCount < 4)
                        {
                            var newRow = Rows[y];
                            newRow = newRow.Remove(x, 1).Insert(x, "x");
                            Rows[y] = newRow;
                            RemovableRollRepeatSum++;
                        }
                    }
                }
            }
        }
    }
}
