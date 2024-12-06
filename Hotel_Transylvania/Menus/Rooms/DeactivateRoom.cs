using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Menus.MenuServices;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class DeactivateRoom : IDeactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var room = MainFactory.Resolve<IRoom>();

            if (Room.ListOfAllRooms
            .Where(r => r.IsRoomActive = true)
                .ToList()
                .Count >= 1)
            {
                Console.WriteLine("Chose a room to deactivate..");
                int x = 40;
                int y = 9;

                Room.ListOfAllRooms
                    .Where(r => r.IsRoomActive == true)
                    .ToList()
                    .ForEach(r =>
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Room ID: {r.RoomID}, Name: {r.RoomType} {r.RoomSize}");
                    });

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Enter RoomID of the room you want to deactivate..");
                Console.Write("RoomID: ");
                var roomToDeactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write($"\nPress 'Enter' to deactivate room {roomToDeactivate}..");
                Console.ReadKey();

                Room.ListOfAllRooms
                    .First(r => r.RoomID == roomToDeactivate)
                    .IsRoomActive = false;
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
