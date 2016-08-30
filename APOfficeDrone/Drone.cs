using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APOfficeDrone
{
    public class Drone
    {
        public bool IsOn { get; set; }
        public double BoundaryXValue { get; set; }
        public double BoundaryYValue { get; set; }
        public string Boundary { get; set; }
        public double CurrentXValue { get; set; }
        public double CurrentYValue { get; set; }
        public string CurrentPosition { get; set; }
        //public double InitialXValue { get; set; }
        //public double InitialYValue { get; set; }
        public string InitialPosition { get; set; }

        public Drone()
        {
            InitialPosition = "0,0";
            CurrentPosition = "0,0";
            CurrentXValue = 0;
            CurrentYValue = 0;
            IsOn = false;
            Boundary = "Not set";
        }


        // MANAGEMENT METHODS
        public void Start()
        {
            this.IsOn = true;
            Console.WriteLine("\n\n------------------------------------------------\n\n The drone is now on\n\n------------------------------------------------\n");
        }

        public void SetInitialPosition(double xValue, double yValue)
        {
            //TODO: Check earlier if boundary is set or if boundary command is in the queue - don't proceed with position command otherwise

            if ((this.Boundary == "Not set"))
            {
                Console.WriteLine("\n\n------------------------------------------------\n\nBoundary must be sest before an Initial Position can be set\n\n------------------------------------------------\n");
            }
            else
            {
                if ((xValue > 0 && xValue < this.BoundaryXValue) && (yValue > 0 && yValue < this.BoundaryYValue))
                {
                    this.CurrentXValue = xValue;
                    this.CurrentYValue = yValue;
                    this.CurrentPosition = xValue.ToString() + "," + yValue.ToString();
                    this.InitialPosition = xValue.ToString() + "," + yValue.ToString();
                    Console.WriteLine("\n\n------------------------------------------------\n\nInitial position of drone set to (" + this.InitialPosition + ")\n\n------------------------------------------------\n");
                }
                else
                {
                    Console.WriteLine("\n\n------------------------------------------------\n\nOne or more position value given to InitialPosition command are not within Boundary\n\n------------------------------------------------\n");
                }
            }
        }

        public void SetBoundary(double xValue, double yValue)
        {
            if ((xValue > 0) && (yValue > 0))
            {
                this.BoundaryXValue = xValue;
                this.BoundaryYValue = yValue;
                this.Boundary = xValue.ToString() + "," + yValue.ToString();
                Console.WriteLine("\n\n------------------------------------------------\n\nBoundary set to (" + this.Boundary + ")\n\n------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("\n\n------------------------------------------------\n\nCoordinate values to set Boundary (upper right) must be greater than 0,0 (lower left coordinate values). Boundary not set.\n\n------------------------------------------------\n");
            }
        }

        // ACTION METHODS
        public void Move(double seconds, double direction)
        {
            //TODO: Check before queueing commands that boundary is set and drone is on. 
            if (this.Boundary != "Not set" && this.IsOn == true)
            {
                //TODO: Implement both navigation modules
                var toAdd = (seconds * 0.5);

                if (direction == 0 || direction == 180)
                {
                    if ((this.CurrentXValue + toAdd) > this.BoundaryXValue)
                    {
                        this.CurrentXValue = this.BoundaryXValue;
                        Console.WriteLine("\n\n------------------------------------------------\n\nThe drone hit a wall and stopped.\n\n------------------------------------------------\n");
                    }
                    else
                    {
                        this.CurrentXValue = this.CurrentXValue + toAdd;
                    }
                }

                else if (direction == 90 || direction == 270)
                {
                    if ((this.CurrentYValue + toAdd) > this.BoundaryYValue)
                    {
                        this.CurrentYValue = this.BoundaryYValue;
                        Console.WriteLine("\n\n------------------------------------------------\n\nThe drone hit a wall and stopped.\n\n------------------------------------------------\n");
                    }
                    else
                    {
                        this.CurrentYValue = this.CurrentYValue + toAdd;
                    }
                }

                else { Console.WriteLine("Only accepted direction values are 0, 90, 180, 270"); }

                this.CurrentPosition = this.CurrentXValue.ToString() + ',' + this.CurrentYValue.ToString();
                Console.WriteLine("\n\n------------------------------------------------\n\nThe drone's position is now (" + CurrentPosition + ")\n\n------------------------------------------------\n");
            }
            else
            {

                Console.WriteLine("\n\n------------------------------------------------\n\nThe drone must be started and a boundary set before it can move\n\n------------------------------------------------\n");
            }
        }

        public static void DisplayState(Drone drone)
        {
            var status = drone.IsOn ? "On" : "Off";
            Console.WriteLine(">>>>>>>>>>>>>>>>>> CURRENT STATUS\n The drone is: " + status + "\n Starting position: (" + drone.InitialPosition + ")\n Current position: (" + drone.CurrentPosition + ")\n Boundary (Maximum upper right coordinates): (" + drone.Boundary + ")\n\n>>>>>>>>>>>>>>>>>>\n");
        }
    }
}
