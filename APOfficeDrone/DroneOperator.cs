using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    public class DroneOperator
    {
        public Queue<BaseCommand> Commands;

        public DroneOperator()
        {
            Commands = new Queue<BaseCommand>();
        }

        public void ExecuteCommands()
        {
            while (Commands.Count > 0)
            {
                BaseCommand command = Commands.Dequeue();
                command.Execute();
            }
        }
    }
}
