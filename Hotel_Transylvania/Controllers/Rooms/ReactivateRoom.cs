using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ReactivateRoom(
        IRoomService roomService) : IReactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var dbContext = ApplicationDbContext.GetDbContext();

            if (roomService.GetAllRooms(dbContext)
                .Where(g => g.IsRoomActive == false)
                .ToList()
                .Count >= 1)
            {
                var xcoord = 45;
                var ycoord = 9;
                roomService.GetInactiveRooms(xcoord, ycoord, dbContext);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Make choice by Room number..");
                Console.Write("Room to reactivate: ");
                var roomToReactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write("\nPress 'Enter' to save..");

                Console.ReadKey();
                roomService.ReActivateRoom(roomToReactivate, dbContext);

            }
            else
            {
                Console.WriteLine("There are no inactive rooms in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
        }
    }
}
