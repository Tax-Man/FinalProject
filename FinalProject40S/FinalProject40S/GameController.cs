using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace FinalProject40S
{
    public class GameController
    {
        public GameController(int paths, int startingAircraft, int airports)
        {
            Timer tim = new Timer(3000);
            tim.Elapsed += OnEvent;
        }

        public void OnEvent(object source, ElapsedEventArgs e)
        {
            //do something
        }
    }
}