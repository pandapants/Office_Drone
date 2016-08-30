using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APOfficeDrone;

namespace APDroneTests
{
    [TestClass]
    public class DroneTest
    {
        [TestMethod]
        public void StartDrone()
        {
            //-- Arrange
            Drone drone = new Drone();
            bool expected = true;

            //-- Act
            drone.Start();
            bool actual = drone.IsOn;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetBoundaryValid()
        {
            //-- Arrange
            Drone drone = new Drone();
            string expected = "10,10";

            //-- Act
            drone.SetBoundary(10, 10);
            string actual = drone.Boundary;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetBoundaryInvalid()
        {
            //-- Arrange
            Drone drone = new Drone();
            string expected = "Not set";

            //-- Act
            drone.SetBoundary(-10, -10);
            string actual = drone.Boundary;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetInitialPositionValid()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.SetBoundary(20, 20);
            string expected = "10,10"; 

            //-- Act
            drone.SetInitialPosition(10, 10);
            string actual = drone.InitialPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetInitialPositionNoBoundary()
        {
            //-- Arrange
            Drone drone = new Drone();
            string expected = "0,0";

            //-- Act
            drone.SetInitialPosition(10, 10);
            string actual = drone.InitialPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetInitialPositionOutOfBounds()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.SetBoundary(10, 10);
            string expected = "0,0";

            //-- Act
            drone.SetInitialPosition(11, 11);
            string actual = drone.InitialPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveOneXStep()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.SetBoundary(10, 10);
            drone.Start();
            drone.SetInitialPosition(0, 0);
            string expected = "1,0";

            //-- Act
            drone.Move(2, 0);
            string actual = drone.CurrentPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveFiveYSteps()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.SetBoundary(10, 10);
            drone.Start();
            drone.SetInitialPosition(0, 0);
            string expected = "0,5";

            //-- Act
            drone.Move(10, 90);
            string actual = drone.CurrentPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveXAndYSteps()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.SetBoundary(10, 10);
            drone.Start();
            drone.SetInitialPosition(0, 0);
            string expected = "4,8";

            //-- Act
            drone.Move(8, 180);
            drone.Move(16, 270);
            string actual = drone.CurrentPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveBoundaryNotSet()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.Start();
            drone.SetInitialPosition(0, 0);
            string expected = "0,0";

            //-- Act
            drone.Move(4, 90);
            string actual = drone.CurrentPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveOutOfBounds()
        {
            //-- Arrange
            Drone drone = new Drone();
            drone.Start();
            drone.SetBoundary(10, 10);
            drone.SetInitialPosition(0, 0);
            string expected = "0,10";

            //-- Act
            drone.Move(200, 90);
            string actual = drone.CurrentPosition;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}
