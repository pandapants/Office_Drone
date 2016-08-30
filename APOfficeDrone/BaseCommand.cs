using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    public abstract class BaseCommand
    {
        protected Drone _drone;

        public BaseCommand(Drone drone)
        {
            _drone = drone;
        }

        public abstract void Execute();
    }
}
