using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    public class MoveCommand : BaseCommand
    {
        public double Seconds { get; set; }
        public double Direction { get; set; }

        public MoveCommand(Drone drone) : base(drone) { }

        public override void Execute()
        {
            _drone.Move(Seconds, Direction);
        }
    }
}
