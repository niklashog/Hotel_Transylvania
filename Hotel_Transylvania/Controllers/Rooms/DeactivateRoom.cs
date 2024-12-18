using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class DeactivateRoom(): IDeactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var roomService = MainFactory.Resolve<IRoomService>();
            var dbContext = ApplicationDbContext.GetDbContext();


            if (roomService.GetAllRooms(dbContext)
                .Where(g => g.IsRoomActive)
                .ToList()
                .Count >= 1)
            {
                var xcoord = 45;
                var ycoord = 9;
                roomService.GetActiveRooms(xcoord, ycoord, dbContext);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Make choice by Room ID..");
                Console.Write("Room to deactivate: ");
                var roomToDeactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write($"\nPress 'Enter' to deactivate room #{roomToDeactivate}..");

                Console.ReadKey();
                roomService.RemoveRoom(roomToDeactivate, dbContext);
            }
            else
            {
                Console.WriteLine("There are no active rooms in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
        }
    }
}
