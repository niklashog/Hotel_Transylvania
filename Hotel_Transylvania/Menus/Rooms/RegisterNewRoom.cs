using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class RegisterNewRoom : IRegisterNewRoom
    {
        public void Execute()
        {
            var newRoom = MainFactory.Resolve<IRoom>();

            Console.Clear();
            DisplayLogo.Paint();
            Console.CursorVisible = true;
            Console.WriteLine("Specify details of new room..");
            
            Console.Write("Room Number: ");
            newRoom.RoomID = int.Parse(Console.ReadLine());

            Console.Write("Room type (Single, Double, Kingsize): ");
            newRoom.RoomType = Console.ReadLine();

            Console.Write("Room size (m²):");
            newRoom.RoomSize = int.Parse(Console.ReadLine());
            if (newRoom.RoomSize <= 14 || newRoom.RoomType == "Single")
            {
                Console.WriteLine("Important note. Per guest security reasons," +
                    "this room is too small to accomodate extra beds.");
            }
            else if (newRoom.RoomSize >= 15 && newRoom.RoomSize <= 19)
            {
                newRoom.HasAdditionalBedding = true;
                newRoom.AdditionalBeddingNumber = 1;
                Console.WriteLine("If requested by guest," +
                    "room can accomodate 1 additonal bed.");
            }
            else
            {
                newRoom.HasAdditionalBedding = true;
                newRoom.AdditionalBeddingNumber = 2;
                Console.WriteLine("If requested by guest," +
                    "room can accomodate 2 additonal beds.");
            }

            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            Room.ListOfAllRooms.Add(newRoom);
            Console.ReadKey();
        }
    }
}
