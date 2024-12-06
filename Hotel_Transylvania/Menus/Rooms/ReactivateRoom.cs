using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Menus.MenuServices;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ReactivateRoom : IReactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var numberOfInactiveRooms = Room.ListOfAllRooms
                .Where(g => g.IsRoomActive == false)
                .Count();

            if (numberOfInactiveRooms >= 1)
            {
                Console.WriteLine("Chose a room to reactivate..");

                int x = 40;
                int y = 9;

                Room.ListOfAllRooms
                    .Where(r => r.IsRoomActive == false)
                    .ToList()
                    .ForEach(r =>
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Room ID: {r.RoomID}, Name: {r.RoomType} {r.RoomSize}");
                    });


                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Enter RoomID of the room you want to reactivate..");
                Console.Write("RoomID: ");
                var roomToReactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write("\nPress 'Enter' to save..");
                Console.ReadKey();

                Room.ListOfAllRooms
                    .First(r => r.RoomID == roomToReactivate)
                    .IsRoomActive = true;
            }
            else
            {
                Console.WriteLine("There are no inactive guests in the system." +
                    "\nPress any key to go back.");
                Console.WriteLine(numberOfInactiveRooms);
                Console.ReadKey();
                return;
            }

            Console.ReadKey();
        }
    }
}
