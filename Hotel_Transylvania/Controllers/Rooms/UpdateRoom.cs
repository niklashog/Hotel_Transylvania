using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class UpdateRoom(
        IRoomService roomService) : IUpdateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            using var dbContext = ApplicationDbContext.GetDbContext();

            roomService.DisplayActiveRooms(dbContext);

            Console.CursorVisible = true;
            Console.WriteLine("Make choice by Room number..");
            Console.Write("Room to update: ");
            var roomToUpdate = Convert.ToInt32(Console.ReadLine());

            Console.CursorVisible = false;
            Console.Write($"\nPress 'Enter' to update room #{roomToUpdate}..");
            Console.ReadKey();

            Console.Clear();
            DisplayLogo.Paint();

            roomService.DisplaySingleRoom(roomToUpdate, dbContext);
            Console.CursorVisible = true;
            Console.WriteLine("Enter room details..");
            Console.Write("Room number ");
            var roomId = int.Parse(Console.ReadLine());
            Console.Write("RoomType: ");
            var roomType = Console.ReadLine();
            Console.Write("Room size: ");
            var roomSize = int.Parse(Console.ReadLine());
            Console.Write("Is room active?: ");
            var isRoomActive = bool.Parse(Console.ReadLine());
            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();

            var updatedRoomDetails = new Room 
            {
                RoomNumber = roomId,
                RoomType = roomType,
                RoomSize = roomSize,
            };

        roomService.UpdateRoomDetails(roomToUpdate, updatedRoomDetails, dbContext);
            Console.ReadKey();
        }
    }
}
