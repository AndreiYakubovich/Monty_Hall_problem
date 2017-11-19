using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monty_Hall_problem.Models;

namespace UnitTestProject
{
    [TestClass]
    public class TestMonty
    {
        [TestMethod]
        public void PlaceAPrizeTest()
        {
            int doorNumber = 3;
            int prizeCount = 0;
            Room room = new Room(doorNumber);
            Monty.SetPrize(room);
            foreach (var door in room.Doors)
            {
                if (door.HasPrize)
                    prizeCount++;
            }
            Assert.IsTrue(prizeCount == 1);
        }

        [TestMethod]
        public void OpenDoorsTest()
        {
            int doorNumber = 3;
            int closedDoorsNumber = 0;
            Room room = new Room(doorNumber);
            Monty.SetPrize(room);
            Monty.MontyOpenDoors(room);
            foreach (var door in room.Doors)
            {
                if (!door.IsOpened)
                    closedDoorsNumber++;
            }
            Assert.IsTrue(closedDoorsNumber == 2);
        }
    }
}