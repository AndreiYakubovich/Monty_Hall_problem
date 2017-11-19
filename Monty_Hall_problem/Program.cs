using System;
using System.Collections.Generic;
using Monty_Hall_problem.Models;

namespace Monty_Hall_problem
{
    public static class Program
    {
        public static List<Room> Rooms = new List<Room>();

        public static void Main()
        {
            (int roomsNumber, int doorsNumber) = GetRoomsAndDoorsNumber();
            Rooms.GenerateRooms(roomsNumber, doorsNumber);
            int numbersOfWin = RunExperiment(Rooms);
            Console.WriteLine($"If we change our choice, we will win in {numbersOfWin} of {roomsNumber}. That is {Convert.ToDouble(numbersOfWin) / Convert.ToDouble(roomsNumber) * 100} percents");
            Console.Read();
        }

        private static int RunExperiment(List<Room> rooms)
        {
            int numbersOfWin = 0;
            foreach (Room room in rooms)
            {
                Monty.SetPrize(room);
                Player.ChooseDoor(room);
                Monty.MontyOpenDoors(room);
                if (Player.ChangeDecision(room))
                    numbersOfWin++;
            }

            return numbersOfWin;
        }

        private static (int roomsNumber,int doorsNumber) GetRoomsAndDoorsNumber()
        {
            int roomsNumber, doorsNumber;
            while (true)
            {
                Console.WriteLine("Enter the number of rooms");
                if (int.TryParse(Console.ReadLine(), out roomsNumber) && roomsNumber > 0)
                {
                    Console.WriteLine("Enter the number of doors in each rooms");
                    if (int.TryParse(Console.ReadLine(), out doorsNumber) && doorsNumber > 2)
                        break;
                }
            }
            return (roomsNumber, doorsNumber);
        }

        public static void GenerateRooms(this List<Room> rooms, int roomsNumber, int doorsNumber)
        {
            for (int i = 0; i < roomsNumber; i++)
            {
                rooms.Add(new Room(doorsNumber));
            }
        }
    }
}
