using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowAllGuests : IShowAllGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I SHOW ALL GUESTS");
            Console.ReadKey();
        }
    }
}
