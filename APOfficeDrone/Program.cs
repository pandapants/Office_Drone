using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;
            Printinstructions();
            Run();
        }

        static void Run()
        {
            Drone drone = new Drone();
            DroneOperator droneOperator = new DroneOperator();

            while (true)
            {
                Drone.DisplayState(drone);
                var userInput = GetConsoleInput("Type your command(s): ");
                if (string.IsNullOrWhiteSpace(userInput)) continue;

                try
                {
                    InputProcessor.ProcessInput(userInput, drone, droneOperator);
                    InputProcessor.DisplayCommandStatus(droneOperator);
                    
                    var answer = GetConsoleInput("Execute these commands? (Y/N): ");
                    
                    if (answer == "Y")
                    {
                        droneOperator.ExecuteCommands();
                    }
                    else
                    {
                        droneOperator.Commands.Clear();
                        continue;
                    }
                         
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong. Try to enter new command(s)");
                    Console.WriteLine("Exception message: " + ex.Message);
                    continue;
                }
            }
        }

        
        public static string GetConsoleInput(string promptMessage = "")
        {
            const string _prompt = "console> ";
            Console.Write(_prompt + promptMessage);
            return Console.ReadLine();
        }

        public static void Printinstructions()
        {
            Console.WriteLine("\n\n---------------------OFFICE DRONE--------------------------\n\n MANAGEMENT COMMANDS\n\n S - Starts the drone\n Bx,y - Sets drone's boundary. X and Y are upper right coordinates (lower left coordinates: 0,0)\n Px,y - Sets drone's initial position.\n\n\n ACTION COMMANDS\n\n Mt,d - Moves drone for t seconds in d direction (only 0, 90, 180, and 270 degrees permitted) at 0.5 m/s\n\n\n Instructions:\n\n Action commands are only accepted once the drone is started and the boundary set.\n Individual commands must be unquoted, starting with a letter followed by any arguments.\n Arguments are separated by commas(no spaces). Multiple commands are separated by spaces.\n\n----------------------------------------------------------\n\n");
        }
    }
}

