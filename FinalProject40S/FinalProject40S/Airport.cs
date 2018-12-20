using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject40S
{
    public class Airport
    {
        public Aircraft[] Aircraft
        {
            get => Aircraft;
            set => Aircraft = value;
        }

        public int Capacity
        {
            get => Capacity;
            set => Capacity = value;
        }
        
        public Airport(int capacity)
        {
            Capacity = capacity;
            Aircraft = new Aircraft[Capacity];
        }

        public bool Add(Aircraft aircraft)
        {
            for (int i = 0; i <= Capacity; i++)
            {
                if (i == Capacity) return false;
                if (Aircraft[i] == null)
                {
                    Aircraft[i] = aircraft;
                    return true;
                }
            }
            return false;
        }
    }
}