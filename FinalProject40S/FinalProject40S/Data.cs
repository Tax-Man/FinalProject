using System;
using System.Drawing;

namespace FinalProject40S
{
    public class Data
    {


        public Data(string id, PointF position, int maxSpeed, int maxAlt, string model)
        {
            ID = id;
            Position = position;
            MaxSpeed = maxSpeed;
            MaxAltitude = maxAlt;
            Model = model;
            if (Position != default(PointF))
            {
                //calculate 
                Position.Y *= -1;
                if (End.X == 0)
                {
                    //end is on left
                }
                else if (End.X == 800)
                {
                    //end is on right
                }
                else if (End.Y == 0)
                {
                    //end is at bottom
                    if (End.X > Position.X) { Distance = Math.Sqrt(Math.Pow(Position.Y, 2) + Math.Pow(End.X - Position.X, 2)); }
                    else { Distance = Math.Sqrt(Math.Pow(Position.Y, 2) + Math.Pow(Position.X - End.X, 2)); }
                    Angle = Math.Tan(Distance / End.X - Position.X);
                }
                else if (End.Y == 800)
                {
                    if (End.X > Position.X) { Distance = Math.Sqrt(Math.Pow(End.X - Position.X, 2) + Math.Pow(End.Y, 2)); }
                    else { Distance = Math.Sqrt(Math.Pow(Position.X - End.X, 2) + Math.Pow(End.Y, 2)); }
                    Angle = Math.Tan(Distance / End.X - Position.X);
                }
                
            }
        }

        public Data(int maxSpeed, int maxAlt, string model) : this(null, default(PointF), maxSpeed, maxAlt, model) { }

        public string ID
        {
            get => ID;
            set => ID = value;
        }

        public PointF Position;

        public PointF End;

        double Distance;

        public int MaxSpeed
        {
            get => MaxSpeed;
            set => MaxSpeed = value;
        }

        public int MaxAltitude
        {
            get => MaxAltitude;
            set => MaxAltitude = value;
        }

        public string Model
        {
            get => Model;
            set => Model = value;
        }

        public double Angle
        {
            get => Angle;
            set => Angle = value;
        }
    }
}