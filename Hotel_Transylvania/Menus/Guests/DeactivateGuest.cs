using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class DeactivateGuest : IDeactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I DEACTIVATE GUEST");
            Console.ReadKey();
        }
    }
}
