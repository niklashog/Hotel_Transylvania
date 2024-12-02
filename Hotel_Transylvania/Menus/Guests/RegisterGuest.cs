using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class RegisterGuest : IRegisterGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I REGISTER GUEST");
            Console.ReadKey();
        }
    }
}
