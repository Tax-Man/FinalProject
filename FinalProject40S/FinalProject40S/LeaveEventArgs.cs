using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject40S
{
    class LeaveEventArgs : EventArgs
    {
        public LeaveEventArgs(string s) => Message = s;
        public string Message { get; }
    }
}
