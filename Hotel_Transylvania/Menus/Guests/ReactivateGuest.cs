using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ReactivateGuest : IReactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I REACTIVATE GUEST");
            Console.ReadKey();
        }
    }
}
