using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProject40S
{
    public class Aircraft
    {
        public Aircraft next, previous;
        static Random _random = new Random();
        public PictureBox icon;

        /// <summary>
        /// Node constructor
        /// </summary>
        /// <param name="data">the properties of the node</param>
        public Aircraft(Data data)
        {
            Data = data;
            Data.Update(Data.Position);
            if (data.ID != null)
            {
                string newID = "";
                newID += GetLetter().ToUpper();
                newID += GetLetter().ToUpper();
                newID += GetLetter().ToUpper();
                newID += GetLetter().ToUpper();
                newID += GetNum();
                newID += GetNum();
                newID += GetNum();
                Data.ID = newID;
            }
            icon.Size = new Size(25, 25);
            Globals.main.Controls.Add(icon);
        }
        /// <summary>
        /// generates a random character 
        /// </summary>
        /// <returns>a random character</returns>
        public string GetLetter()
        {
            int num = _random.Next(0, 26);
            char let = (char)('a' + num);
            return let.ToString();
        }

        /// <summary>
        /// Generates a random number 
        /// </summary>
        /// <returns>A random number</returns>
        public int GetNum()
        {
            return _random.Next(0, 10);
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
        /// Updates a position if in range or deletes it
        /// </summary>
        public void Move()
        {
            if (Data.Update(Data.Position))
            {
                icon.Location = Data.Position;
            }
            else
            {
                Finalize();
            }
        }
    }
}