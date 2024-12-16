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
    public class DisplayActiveGuests : IDisplayActiveGuests
    {
        public void ExecuteXY(int x, int y)
        {
            //var activeGuests = guestService.GetAllGuests()
            //.Where(g => g.IsGuestActive == true)
            //.ToList();

            //activeGuests
            //.ForEach(g =>
            //{
            //    var reservation = g.Reservations.FirstOrDefault();

            //    Console.SetCursorPosition(x, y++);
            //    if (reservation != null)
            //        Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname} Reservation: {reservation.RoomNumber}");
            //    else
            //        Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname} Reservation: None.");
            //});
        }
    }
}
