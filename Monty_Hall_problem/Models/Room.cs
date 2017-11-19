using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Monty_Hall_problem.Models
{
    public class Room
    {
        public List<Door> Doors = new List<Door>();
        private int _chosenDoor;
        public int ChosenDoor
        {
            get { return _chosenDoor; }
            set
            {
                if (value > Doors.Count-1)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be lower than doors count");

                _chosenDoor = value;
            }
        }

        public Room(int doorsNumber)
        {
            for (int i = 0; i < doorsNumber; i++)
            {
                Doors.Add(new Door());
            }
        }        
    }
}
