using System;
using System.Drawing;

namespace FinalProject40S
{
    public class Data
    {

        public Data(string id, Point position, int speed, int altitude, string model)
        {
            ID = id;
            Position = position;
            Speed = speed;
            Altitude = altitude;
            Model = model;

            PositionThing(position);
        }

        public void PositionThing(Point position)
        {
            Position = position;
            if (Position != default(Point))
            {
                //calculate 
                Position.Y *= -1;
                if (End.X < Position.X)
                {
                    //end is to the left of position

                    int x1 = Position.X;
                    int y1 = Position.Y;

                    int x2 = End.X;
                    int y2 = End.Y;

                    double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                }
                else
                {
                    //end is to the right of position

                    int x1 = End.X;
                    int y1 = End.Y;

                    int x2 = Position.X;
                    int y2 = Position.Y;

                    double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                    //if (End.Y > Position.Y) { Distance = Math.Sqrt(Math.Pow(End.Y - Position.Y, 2) + Math.Pow(End.X, 2)); } //a2 + b2 = c2
                    //else { Distance = Math.Sqrt(Math.Pow(Position.Y - End.Y, 2) + Math.Pow(End.X, 2)); }
                    //Angle = Math.Tan(Distance / End.Y - Position.Y);
                }
                Position.Y *= -1;
            }
        }

        public Data(int speed, int altitude, string model) : this(null, default(Point), speed, altitude, model) { }

        public string ID
        {
            get => ID;
            set => ID = value;
        }

        public Point Position;

        public Point End;
        public double Distance;

        public int Speed
        {
            get => Speed;
            set => Speed = value;
        }

        public int Altitude
        {
            get => Altitude;
            set => Altitude = value;
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