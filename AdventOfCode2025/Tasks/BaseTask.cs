using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class BaseTask
    {
        public BaseTask(string name)
        {
            Action handler = RunProcess;
            MenuHelper.AddMenu(name, handler);
        }
        public virtual void RunProcess()
        {
            return;
        }
        public virtual void Reset()
        {
            return;
        }
    }
}
