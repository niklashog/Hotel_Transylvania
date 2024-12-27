using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class DeactivateReservation(
        IReservationService reservationService) : IDeactivateReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();
            var numberOfReservations = dbContext.Reservations.Count();

            if (numberOfReservations >= 1)
            {
                reservationService.ShowReservations(dbContext);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 7);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Enter Reservation Id to cancel a reservation");
                Console.Write("Reservation Id:");
                var reservationIdToRemove = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;

                Console.SetCursorPosition(0, 7);
                Console.WriteLine($"\nPress 'Enter' to cancel reservation #{reservationIdToRemove}..");
                Console.Write(new string(' ', Console.WindowWidth));
                Console.ReadKey();

                Console.SetCursorPosition(0, 7);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.Write(new string(' ', Console.WindowWidth));

                reservationService.RemoveReservation(reservationIdToRemove, dbContext);
            }
            else
            {
                Console.WriteLine("There are no active guests in the system." +
                    "\nPress any key to go back.");
            }
            Console.ReadKey();
        }
    }
}
