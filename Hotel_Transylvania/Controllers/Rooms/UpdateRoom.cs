using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
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

            var xcoord = 45;
            var ycoord = 8;
            roomService.DisplayActiveRooms(xcoord, ycoord);

            Console.CursorVisible = true;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Make choice by Room number..");
            Console.SetCursorPosition(2, 9);
            Console.Write("Room to update: ");
            var roomToUpdate = Convert.ToInt32(Console.ReadLine());

            Console.CursorVisible = false;
            Console.Write($"\nPress 'Enter' to update room #{roomToUpdate}..");
            Console.ReadKey();

            Console.Clear();
            DisplayLogo.Paint();

            roomService.DisplaySingleRoom(roomToUpdate, xcoord, ycoord);
            Console.CursorVisible = true;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Enter room details..");
            Console.SetCursorPosition(2, 9);
            Console.Write("Room number ");
            var roomId = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(2, 10);
            Console.Write("RoomType: ");
            var roomType = Console.ReadLine();
            Console.SetCursorPosition(2, 11);
            Console.Write("Room size: ");
            var roomSize = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(2, 12);
            Console.Write("Is room active?: ");
            var isRoomActive = bool.Parse(Console.ReadLine());
            Console.CursorVisible = false;
            Console.SetCursorPosition(2, 14);
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();

            var updatedRoomDetails = new Room 
            {
                RoomID = roomId,
                RoomType = roomType,
                RoomSize = roomSize,
            };

        roomService.UpdateRoomDetails(roomToUpdate, updatedRoomDetails);
            Console.ReadKey();
        }
    }
}
