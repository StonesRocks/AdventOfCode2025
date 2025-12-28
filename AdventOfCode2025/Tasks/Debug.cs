using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class Debug : BaseTask
    {
        
        public Debug() : base(nameof(Debug)) { }

        public override void RunProcess()
        {
            DebugHelper.SetDebug(
                InputReader.ReadBool($"Debug state is {DebugHelper.Debug}, set state."));
        }
    }
}
