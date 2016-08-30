using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APOfficeDrone;

namespace APDroneTests
{
    [TestClass]
    public class InputProcessorTest
    {
        [TestMethod]
        public void TryToParseValid()
        {
            //-- Arrange
            string[] stringArr = new string[1];
            stringArr[0] = "4";
            double expected = 4;

            //-- Act
            var parsedArgs = InputProcessor.TryToParse(stringArr, "random code");
            var actual = parsedArgs[0];

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
