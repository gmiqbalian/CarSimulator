using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTests.Models
{
    [TestClass]
    public class MainMenuTests
    {
        [TestMethod]
        [DataRow(0, ConsoleKey.DownArrow, 1)]
        [DataRow(7, ConsoleKey.DownArrow, 0)]
        [DataRow(1, ConsoleKey.UpArrow, 0)]
        [DataRow(0, ConsoleKey.UpArrow, 7)]
        public void GetSelection_Returns_Integer(int selection, ConsoleKey keyPressed, int expected)
        {
            //Arrange

            //Act
            var result = MainMenu.GetSelection(selection, keyPressed);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
