using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _07 : BaseTask
    {
        private List<Tuple<int,int>> positionOfInterest = new();
        private List<string> rows = new();
        public _07() : base(nameof(_07)) { }
        public override void RunProcess()
        {
            rows = InputReader.ReadMultiple();
            SetStart(rows);

        }
        private void Step(List<string> Rows)
        {
            List<Tuple<int, int>> newPOI = new();
            foreach(var position in positionOfInterest)
            {
                int x = position.Item1;
                int y = position.Item2;
                var row = Rows[y + 1];
                if (row[x] == '.')
                {
                    row = row.Remove(x).Insert(x, "|");
                    Rows[y + 1] = row;
                    newPOI.Add(new Tuple<int, int> ( x, y+1 ));
                }
                else if (row[x] == '^')
                {

                }
            }
            positionOfInterest = newPOI;
        }

        private void SetStart(List<string> Rows)
        {
            for (int x = 0; x < Rows[0].Length ; x++)
            {
                if (Rows[0][x] == 'S')
                {
                    positionOfInterest.Add(new Tuple<int, int>(x,0));
                }
            }
        }
    }
}
