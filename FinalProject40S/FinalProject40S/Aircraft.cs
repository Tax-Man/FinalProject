using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FinalProject40S
{
    public class Aircraft
    {
        public Aircraft next, previous;
        static Random _random = new Random();
        
        public Aircraft(Data data)
        {
            Data = data;
            if (data.ID == null)
            {
                string newID = "";
                newID += GetLetter();
                newID += GetLetter();
                newID += GetLetter();
                newID += GetLetter();
                newID += GetNum();
                newID += GetNum();
                newID += GetNum();
            }
        }

        public char GetLetter()
        {
            int num = _random.Next(0, 26);
            char let = (char)('a' + num);
            return let;
        }

        public int GetNum()
        {
            return _random.Next(0, 10);
        }

        public PointF Target
        {
            get => Target;
            set => Target = value;
        }

        public Data Data
        {
            get => Data;
            set => Data = value;
        }

        /// <summary>
        /// Wipes out all memory used by this object
        /// </summary>
        public void Finalize()
        {
            Data = null;
            next = previous = null;
        }

        public delegate void LeaveEventHandler(object sender, LeaveEventArgs l);
        
        public void LeaveEventArgs()
        {
            //publisher event
        }

        public void Move()
        {

        }
        
    }
}