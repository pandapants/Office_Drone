using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    class InitialPositionCommand : BaseCommand
    {
        public double XValue { get; set; }
        public double YValue { get; set; }

        public InitialPositionCommand(Drone drone) : base(drone) { }

        public override void Execute()
        {
            _drone.SetInitialPosition(XValue, YValue);
        }
    }
}
