using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    public class StartCommand : BaseCommand
    {
        public StartCommand(Drone drone) : base(drone) { }

        public override void Execute() 
        {
            _drone.Start();
        }
    }
}
