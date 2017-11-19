using System;
using System.Linq;

namespace Monty_Hall_problem.Models
{
    public static class Monty
    {
        private static Random _randomizator = new Random();

        public static Room MontyOpenDoors(Room room)
        {
            int randomdoor = _randomizator.Next(room.Doors.Count - 1);
            var check = room.Doors[room.ChosenDoor].HasPrize;
            if (check)
            {
                while (true)
                {
                    if (room.ChosenDoor != randomdoor)
                        break;
                    randomdoor = _randomizator.Next(room.Doors.Count - 1);
                }

                foreach (Door door in room.Doors)
                {
                    if (door.HasPrize) continue;
                    door.IsOpened = true;
                }
                room.Doors[randomdoor].IsOpened = false;
            }
            else
            {
                for (var index = 0; index < room.Doors.Count; index++)
                {
                    if (index == room.ChosenDoor || room.Doors[index].HasPrize) continue;
                    room.Doors[index].IsOpened = true;
                }
            }
            return room;
        }

        public static Room SetPrize(Room room)
        {
            room.Doors[_randomizator.Next(room.Doors.Count - 1)].HasPrize = true;
            return room;
        }
    }
}
