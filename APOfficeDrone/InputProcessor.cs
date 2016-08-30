using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    //Restructure this code
    public class InputProcessor
    {
        public static void ProcessInput(string userInput, Drone theDrone, DroneOperator theOperator)
        {
            Dictionary<string, int> commandList =
                new Dictionary<string, int>();
            commandList.Add("S", 0);
            commandList.Add("B", 2);
            commandList.Add("P", 2);
            commandList.Add("M", 2);

            var commandArr = userInput.Trim().Split(' ');

            foreach (string s in commandArr)
            {
                string commandCode = s.Substring(0, 1).ToUpper();
                var argsArr = s.Trim().Substring(1).Split(',');


                if (commandList.ContainsKey(commandCode))
                {
                    var requiredNoOfArgs = commandList[commandCode];
                    if ((argsArr.Length < requiredNoOfArgs))
                    {
                        Console.WriteLine("\n\n------------------------------------------------\n\n Wrong number of arguments passed. Command " + commandCode + " was not added to queue. \n------------------------------------------------\n\n");
                    }
                    else
                    {
                        List<double> parsedArgs = new List<double>();

                        if (requiredNoOfArgs > 0) { parsedArgs = TryToParse(argsArr, commandCode); }

                        switch (commandCode)
                        {
                            case "S":
                                StartCommand startCommand = new StartCommand(theDrone);
                                theOperator.Commands.Enqueue(startCommand);
                                break;
                            case "B":
                                BoundaryCommand boundaryCommand = new BoundaryCommand(theDrone);
                                if (parsedArgs.Count == argsArr.Length)
                                {
                                    boundaryCommand.XValue = parsedArgs[0];
                                    boundaryCommand.YValue = parsedArgs[1];
                                    theOperator.Commands.Enqueue(boundaryCommand);
                                }
                                break;
                            case "P":
                                InitialPositionCommand initialPosCommand = new InitialPositionCommand(theDrone);
                                if (parsedArgs.Count == argsArr.Length)
                                {
                                    initialPosCommand.XValue = parsedArgs[0];
                                    initialPosCommand.YValue = parsedArgs[1];
                                    theOperator.Commands.Enqueue(initialPosCommand);
                                }
                                break;
                            case "M":
                                MoveCommand moveCommand = new MoveCommand(theDrone);
                                if (parsedArgs.Count == argsArr.Length && parsedArgs[0] > 0)
                                {
                                    if (parsedArgs[0] > 0)
                                    {
                                        moveCommand.Seconds = parsedArgs[0];
                                        moveCommand.Direction = parsedArgs[1];
                                        theOperator.Commands.Enqueue(moveCommand);
                                    }
                                    else { Console.WriteLine("\n\n------------------------------------------------\n\nMust pass seconds as positive number to command:" + commandCode + ". Command not added to queue.\n------------------------------------------------\n\n"); }
                                }
                                break;
                            default:
                                Console.WriteLine("No such command.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\n------------------------------------------------\n\nNo command matches command code " + commandCode + ". Command not added to queue.\n------------------------------------------------\n\n");
                }
            }
        }
        
        public static List<double> TryToParse(string[] argsArray, string commandCode)
        {
            var parsedArgs = new List<double>();

            foreach (string s in argsArray)
            {
                double num;
                bool res = Double.TryParse(s.Trim(), out num);

                if (res == false)
                {
                    Console.WriteLine("\n\n------------------------------------------------\n\n" + s + " is not a valid argument to: " + commandCode.ToString() + ".\n------------------------------------------------\n\n");
                }
                else
                {
                    parsedArgs.Add(num);
                }
            }
            if (parsedArgs.Count < argsArray.Length) { Console.WriteLine("\n\n------------------------------------------------\n\nCommand " + commandCode + " will not be added to queue\n\n------------------------------------------------\n"); }
            return parsedArgs;
        }

        public static void DisplayCommandStatus(DroneOperator droneOperator)
        {
            if (droneOperator.Commands.Count == 0)
            {
                Console.WriteLine("\n\n------------------------------------------------\n\nNo commands were added to the queue. Try again.\n\n------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("\n\n************************************************\n\nThe following commands have been added to the queue:\n");

                foreach (BaseCommand c in droneOperator.Commands)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine("\n************************************************\n");
            }
        }
    }
}
