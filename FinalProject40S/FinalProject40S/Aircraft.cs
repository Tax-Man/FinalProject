﻿using System;
using System.Drawing;

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
                newID += GetLetter().ToUpper();
                newID += GetLetter().ToUpper();
                newID += GetLetter().ToUpper();
                newID += GetLetter().ToUpper();
                newID += GetNum();
                newID += GetNum();
                newID += GetNum();
            }
        }

        public string GetLetter()
        {
            int num = _random.Next(0, 26);
            char let = (char)('a' + num);
            return let.ToString();
        }

        public int GetNum()
        {
            return _random.Next(0, 10);
        }

        public Point Target
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
        
        public void Move()
        {
            Data.Position.X = Data.Position.X + Math.Cos(angle) * Data.Distance;
            new_y = old_y + Math.Sin(angle) * distance;

        }

    }
}