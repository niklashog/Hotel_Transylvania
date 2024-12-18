using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Display
{
    public class DisplayInactiveGuests(
        IGuestService guestService) : IDisplayInactiveGuests
    {
        public void ExecuteXY(int x, int y)
        {
            var dbContext = ApplicationDbContext.GetDbContext();

            var inactiveGuests = guestService.GetAllGuests(dbContext)
            .Where(g => g.IsGuestActive == false)
            .ToList();

            inactiveGuests
            .ForEach(g =>
            {
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"Guest ID: {g.Id}, Name: {g.FirstName} {g.Surname}");
            });
        }
    }
}