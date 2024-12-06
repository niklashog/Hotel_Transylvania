using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;

namespace Hotel_Transylvania.Menus.MenuServices
{
    public class PrintInactiveGuests : IPrintInactiveGuests
    {
        public void ExecuteXY(int x, int y)
        {
            Guest.ListOfAllGuests
                .Where(g => g.IsGuestActive == false)
                .ToList()
                    .ForEach(g =>
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
                    });
        }
    }
}