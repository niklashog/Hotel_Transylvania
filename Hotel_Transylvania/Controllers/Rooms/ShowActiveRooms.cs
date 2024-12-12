using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Models;


namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowActiveRooms : IShowActiveRooms
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("All active rooms:");

            Room.ListOfRooms
                .Where(g => g.IsRoomActive == true)
                .ToList()
                .ForEach((g => Console.WriteLine($"Room #: {g.RoomID} Type: {g.RoomType} Size: {g.RoomSize}m²")));

            Console.ReadKey();
        }
    }
}
