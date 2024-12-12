using Hotel_Transylvania.Interfaces.DisplayInterfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Display
{
    internal class DisplayActiveGuests(
        IGuestService guestService) : IDisplayActiveGuests
    {
        public void ExecuteXY(int x, int y)
        {
            //var activeGuests = guestService.GetAllGuests()
            //.Where(g => g.IsGuestActive == true)
            //.ToList();

            //activeGuests
            //.ForEach(g =>
            //{
            //    Console.SetCursorPosition(x, y++);
            //    Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
            //});
        }
    }
}
