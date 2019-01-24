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

            Update(position);
        }

        public bool Update(Point position)
        {
            Position = position;
            if (Position.X > 800 || Position.X < 0 || Position.Y > 800 || Position.Y < 0) return false;
            if (Position != default(Point))
            {
                Position.Y *= -1;
                if (End.X < Position.X)
                {
                    //end is to the left of position

                    int x1 = Position.X;
                    int y1 = Position.Y;

                    int x2 = End.X;
                    int y2 = End.Y;

                    Distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                }
                else
                {
                    //end is to the right of position

                    int x1 = End.X;
                    int y1 = End.Y;

                    int x2 = Position.X;
                    int y2 = Position.Y;

                    Distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                }
                Position.Y *= -1;
            }
            else return false;

            Position.X = (int)(Position.X + Math.Cos(Angle) * Speed);
            Position.Y = (int)(Position.Y + Math.Sin(Angle) * Speed);

            int delta_x = End.X - Position.X;
            int delta_y = Position.Y - End.Y;

            Angle = Math.Atan2(delta_y, delta_x); //angle in radians

            return true;
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