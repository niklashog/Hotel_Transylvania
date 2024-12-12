using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;


namespace Hotel_Transylvania.Menus.Guests
{
    public class RegisterGuest(
        IGuestService guestService) : IRegisterGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            Console.CursorVisible = true;
            Console.WriteLine("Enter guest details..");
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            Console.Write("E-mail: ");
            var email = Console.ReadLine();
            Console.Write("Phone number: ");
            var phone = Console.ReadLine();
            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();
            int guestCount = guestService.GetAllGuests().Count();
            var guestId = ++guestCount;
            Console.WriteLine(guestCount);

            var newGuest = new Guest
            {
                GuestID = guestId,
                FirstName = firstName,
                Surname = surname,
                Email = email,
                Phone = phone,
            };

            guestService.AddGuest(newGuest);
            Console.ReadKey();
        }
    }
}
