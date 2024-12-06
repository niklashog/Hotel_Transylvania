using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.MenuServices
{
    internal class PrintActiveGuests : IPrintActiveGuests
    {
        public void ExecuteXY(int x, int y)
        {
            Guest.ListOfAllGuests
                .Where(g => g.IsGuestActive == true)
                .ToList()
                    .ForEach(g =>
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
                    });
        }
    }
}
