using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowActiveGuests : IShowActiveGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I SHOW ACTIVE GUESTS:");

            Guest.ListOfAllGuests
                .Where(g => g.IsGuestActive == true)
                .ToList()
                .ForEach((g => Console.WriteLine($"{g.GuestID} {g.FirstName} {g.Surname}")));

            Console.ReadKey();
        }
    }
}
