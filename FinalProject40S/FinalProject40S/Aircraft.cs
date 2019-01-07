using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FinalProject40S
{
    public class Aircraft
    {
        public Aircraft next, previous;

        public Aircraft(string ID, PointF pos, int maxSpeed, int maxAltitude, string model)
        {
            Data.ID = ID;
            Data.MaxSpeed = maxSpeed;
            Data.MaxAltitude = maxAltitude;
            Data.Position = pos;
            Data.Model = model;
        }

        public Aircraft(Data data)
        {
            Data = data;
            if (data.ID == null)
            {
                //generate random ID
            }
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

        /// <summary>
        /// publisher event for leaving screen
        /// </summary>
        public void LeaveEvent()
        {

        }

    }
}