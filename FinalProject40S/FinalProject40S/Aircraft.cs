using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FinalProject40S
{
    public abstract class Aircraft
    {
        public Aircraft next, previous;

        public PointF Target
        {
            get => Target;
            set => Target = value;
        }

        public string ID
        {
            get => ID;
            set => ID = value;
        }

        public PointF Position
        {
            get => Position;
            set => Position = value;
        }

        /// <summary>
        /// Wipes out all memory used by this object
        /// </summary>
        public void Finalize()
        {
            ID = null;
            next = previous = null;
        }
    }
}