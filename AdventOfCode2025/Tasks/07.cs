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
        private List<(int x, int y, int id)> positionOfInterest = new();
        private List<string> rows = new();
        private long p1BeamSplits = 0;
        private Dictionary<int, List<int>> NodeID = new();
        public _07() : base(nameof(_07)) { }
        public override void RunProcess()
        {
            rows = InputReader.ReadMultiple();
            //Find starting position
            SetStart(rows);
            while(positionOfInterest.Count > 0)
            {
                AdvanceBeam(rows);
            }
            Console.WriteLine($"Beam splits: {p1BeamSplits}");
            var resultP1 = CountBeams();

            Reset();
        }
        private void AdvanceQuantumBeam(List<string> Rows)
        {
            //S1
            //We need to create a tree.
            //Default left on each node.
            //When branch reaches bottom, step back one node and apply change, continue this pattern.
            //Requires that we track path

            //S2
            //Reuse previous solution
            //Add path tracking, note which node connects to which node.m
                //How to track nodes?
                    //SetPOI also tracks id of who set that POI when it splits
                    //Setting node ID makes sense, how do we track connections?
            //Assign node id and path as id string.
            //each unique id string is its own timeline.


        }
        private void AdvanceBeam(List<string> Rows)
        {
            List<Tuple<int, int>> newPOI = new();
            foreach (var position in positionOfInterest)
            {
                int x = position.x;
                int y = position.y;
                char value = rows[y][x];

                switch (value)
                {
                    case '.':
                        UpdateMatrix(position, '|');
                        SetPOI(newPOI, new Tuple<int, int>(x, y + 1));
                        break;
                    case '|':
                        SetPOI(newPOI,new Tuple<int, int>(x, y + 1));
                        break;
                    case '^':
                        p1BeamSplits++;
                        SetPOI(newPOI, new Tuple<int, int>(x - 1, y + 1));
                        SetPOI(newPOI, new Tuple<int, int>(x + 1, y + 1));
                        break;
                }
            }
            positionOfInterest = newPOI;
        }
        private void NodeTracker(List<string> rows, int x, int y)
        {
            //Assign potential ID to beam(y value) that assigns the id to hit nodes.

        }
        private void SetPOI(List<Tuple<int,int>> POI, Tuple<int,int> position)
        {
            int x = position.Item1;
            int y = position.Item2;
            if (y >= rows.Count()) { return; }
            else if (x >= rows[0].Length || x < 0) { return; }
            else if (POI.Contains(position)) { return; }
            else { POI.Add(position); }
        }
        private string CountBeams()
        {
            int count = 0;
            foreach (var value in rows[rows.Count()-1])
            {
                if (value == '|') count++;
            }
            DebugHelper.Log($"Found beams: {count}");
            return count.ToString();
        }

        private void UpdateMatrix(Tuple<int, int> position, char value)
        {
            int x = position.Item1;
            int y = position.Item2;
            var newRow = rows[y];
            newRow = newRow.Remove(x, 1).Insert(x, value.ToString());
            rows[y] = newRow;
        }

        private void SetStart(List<string> Rows)
        {
            for (int x = 0; x < Rows[0].Length ; x++)
            {
                if (Rows[0][x] == 'S')
                {
                    positionOfInterest.Add(new Tuple<int, int>(x,1));
                }
            }
        }

        public override void Reset()
        {
            positionOfInterest = new();
            rows = new List<string>();
            p1BeamSplits = 0;
        }
    }
}
