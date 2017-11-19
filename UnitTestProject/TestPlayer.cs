using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monty_Hall_problem.Models;

namespace UnitTestProject
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void ChoiseADoor()
        {
            int doorNumber = 3;
            Room room = new Room(doorNumber);
            Player.ChooseDoor(room);
            Assert.IsTrue(room.ChosenDoor >= 0 && room.ChosenDoor < room.Doors.Count);
        }

        [TestMethod]
        public void FinalPreparation()
        {
            int doorNumber = 3;
            Room room = new Room(doorNumber);
            Monty.SetPrize(room);
            Player.ChooseDoor(room);
            Monty.MontyOpenDoors(room);
            List<Door> closedDoors = room.Doors.FindAll(d => d.IsOpened == false);
            Assert.IsTrue(closedDoors.Count == 2);
        }


        [TestMethod]
        public void FullTest()
        {
            int doorNumber = 3;
            double prizes = 0;
            List<Room> rooms = new List<Room>();
            for (int i = 0; i < 10000; i++)
            {
                rooms.Add(new Room(doorNumber));
            }
            foreach (var room in rooms)
            {
                Monty.SetPrize(room);
                Player.ChooseDoor(room);
                Monty.MontyOpenDoors(room);
                if (Player.ChangeDecision(room))
                    prizes++;
            }

            Assert.IsTrue(prizes / 100 >= 65 && prizes / 100 <= 68);
        }
    }
}
