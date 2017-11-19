using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monty_Hall_problem.Models;
using Monty_Hall_problem;

namespace UnitTestProject
{
    [TestClass]
    public class TestGenerator
    {
        [TestMethod]
        public void TestGeneration()
        {
            List<Room> rooms = new List<Room>();
            int roomsNumber = 1000;
            int doorsNumber = 3;
            rooms.GenerateRooms(roomsNumber, doorsNumber);
            Assert.IsTrue(rooms[roomsNumber - 1].Doors.Count == doorsNumber);
        }
    }
}
