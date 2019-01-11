using System;
namespace FinalProject40S
{
    class LeaveEventArgs : EventArgs
    {
        public LeaveEventArgs(string s) => Message = s;
        public string Message { get; }
    }
}
