using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    public class BoundaryCommand : BaseCommand
    {
        public double XValue { get; set; }
        public double YValue { get; set; }

        public BoundaryCommand(Drone drone) : base(drone) { }

        public override void Execute()
        {
            _drone.SetBoundary(XValue, YValue);
        }
    }
}
