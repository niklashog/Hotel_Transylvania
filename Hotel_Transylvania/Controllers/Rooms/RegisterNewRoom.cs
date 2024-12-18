using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class RegisterNewRoom(
        IRoomService roomService) : IRegisterNewRoom
    {
        public void Execute()
        {
            var newRoom = MainFactory.Resolve<Room>();

            Console.Clear();
            DisplayLogo.Paint();
            Console.CursorVisible = true;
            Console.WriteLine("Specify details of new room..");
            
            Console.Write("Room Number: ");
            newRoom.RoomNumber = int.Parse(Console.ReadLine());
            Console.Write("Room type (Single, Double, Kingsize): ");
            newRoom.RoomType = Console.ReadLine();
            Console.Write("Room size (m²):");
            newRoom.RoomSize = int.Parse(Console.ReadLine());

            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            roomService.AddRoom(newRoom);
            Console.ReadKey();
        }
    }
}
