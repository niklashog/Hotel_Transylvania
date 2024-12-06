using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class RegisterGuest : IRegisterGuest
    {
        public void Execute()
        {
            var newGuest = MainFactory.Resolve<IGuest>();

            Console.Clear();
            DisplayLogo.Paint();
            Console.CursorVisible = true;
            Console.WriteLine("Enter guest details..");
            Console.Write("First Name: ");
            newGuest.FirstName = Console.ReadLine();
            Console.Write("Surname: ");
            newGuest.Surname = Console.ReadLine();
            Console.Write("E-mail: ");
            newGuest.Email = Console.ReadLine();
            Console.Write("Phone number: ");
            newGuest.Phone = Console.ReadLine();
            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();

            newGuest.GuestID = Guest.ListOfAllGuests.Count + 1;
            Guest.ListOfAllGuests.Add(newGuest);
        }
    }
}
