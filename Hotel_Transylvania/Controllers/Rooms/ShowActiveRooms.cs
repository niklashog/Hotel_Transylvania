﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;


namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowActiveRooms(
        IRoomService roomService) : IShowActiveRooms
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            using var dbContext = ApplicationDbContext.GetDbContext();

            roomService.DisplayActiveRooms(dbContext);
            Console.ReadKey();
        }
    }
}
