using System;

namespace Monty_Hall_problem.Models
{
    public static class Player
    {
        public static Room ChooseDoor(Room room)
        {
            Random rand = new Random();
            room.ChosenDoor = rand.Next(room.Doors.Count);
            return room;
        }

        public static bool OpenChosen(Room room)
        {
            return room.Doors[room.ChosenDoor].HasPrize;
        }

        public static bool ChangeDecision(Room room)
        {
            for (int i = 0; i < room.Doors.Count; i++)
            {
                if (room.Doors[i].IsOpened == false && i != room.ChosenDoor)
                    return room.Doors[i].HasPrize;
            }
            return false;
        }
    }
}
