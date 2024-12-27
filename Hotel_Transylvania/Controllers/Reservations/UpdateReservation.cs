using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Spectre.Console;
using System.Xml;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class UpdateReservation(
        IReservationService reservationService,
        ICalendarNavigation calendar,
        IGuestService guestService) : IUpdateReservation
    {
        public void Execute()
        {
            //Console.Clear();
            //DisplayLogo.Paint();

            //using var dbContext = ApplicationDbContext.GetDbContext();

            //var numberOfReservations = dbContext.Reservations
            //    .Where(r => r.IsReservationActive)
            //    .Count();
            //if (numberOfReservations < 1)
            //{
            //    Console.WriteLine("There are no active reservations in the system." +
            //    "\nPress any key to go back.");

            //    Console.ReadKey();
            //}
            //else
            //{
            //    reservationService.ShowReservations(dbContext);

            //    Console.CursorVisible = true;
            //    reservationService.ClearLinesAboveReservationInfo();
            //    reservationService.SetCorrectRowAboveReservationInfo();
            //    Console.WriteLine("Input Reservation Id to update..");
            //    Console.Write("Reservation Id: ");

            //    var reservationIdInput = int.Parse(Console.ReadLine());

            //    Console.CursorVisible = false;

            //    reservationService.SetCorrectRowAboveReservationInfo();

            //    Console.WriteLine($"\nPress 'Enter' to update reservation #{reservationIdInput}..");
            //    Console.Write(new string(' ', Console.WindowWidth));
            //    Console.ReadKey();

            //    reservationService.SetCorrectRowAboveReservationInfo();
            //    Console.Write(new string(' ', Console.WindowWidth));
            //    Console.Write(new string(' ', Console.WindowWidth));

            //    Console.SetCursorPosition(0, 7);
            //    var reservationToUpdate = reservationService.GetReservation(reservationIdInput, dbContext);

            //    Console.Clear();
            //    DisplayLogo.Paint();

            //    reservationService.ShowReservationDetails(reservationToUpdate, dbContext);
            //    reservationService.GetAvailableRooms(dbContext);

            //    reservationService.ClearLinesAboveReservationInfo();
            //    reservationService.SetCorrectRowAboveReservationInfo();
            //    Console.WriteLine($"Enter desired room number.. ");
            //    Console.Write($"Room number: ");
            //    var roomNumber = int.Parse(Console.ReadLine());
        }
        public void ChangeRoomNumber()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            var numberOfReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .Count();
            if (numberOfReservations < 1)
            {
                Console.WriteLine("There are no active reservations in the system." +
                "\nPress any key to go back.");

                Console.ReadKey();
            }
            else
            {
                reservationService.ShowReservations(dbContext);

                Console.CursorVisible = true;
                reservationService.ClearLinesAboveReservationInfo();
                reservationService.SetCorrectRowAboveReservationInfo();
                Console.WriteLine("Input Reservation Id to update..");
                Console.Write("Reservation Id: ");

                var reservationIdInput = int.Parse(Console.ReadLine());

                Console.CursorVisible = false;

                reservationService.SetCorrectRowAboveReservationInfo();

                Console.WriteLine($"\nPress 'Enter' to chose new room for reservation #{reservationIdInput}..");
                Console.Write(new string(' ', Console.WindowWidth));
                Console.ReadKey();

                
                var reservationToUpdate = reservationService.GetReservation(reservationIdInput, dbContext);
                var reservationToUpdateId = reservationToUpdate.Id;
                var checkInDate = reservationToUpdate.CheckinDate;
                var checkOutDate = reservationToUpdate.CheckoutDate;

                Console.Clear();
                DisplayLogo.Paint();
                reservationService.ShowReservationDetails(reservationToUpdate, dbContext);


                var availableRooms = reservationService.GetAvailableRooms(checkInDate, checkOutDate, dbContext)
                .ToList();

                Console.WriteLine("Available Rooms");
                foreach (var room in availableRooms)
                {
                    Console.WriteLine($"#{room.RoomNumber}, {room.RoomType}, {room.RoomSize}m²");
                }

                reservationService.ClearLinesAboveReservationInfo();
                reservationService.SetCorrectRowAboveReservationInfo();
                Console.WriteLine("Enter new room number: ");
                var roomNumber = int.Parse(Console.ReadLine());


                reservationService.UpdateReservedRoom(reservationToUpdateId, roomNumber, dbContext);
                Console.WriteLine("Room updated. Press 'Enter' to continue.");
            }




        }
        public void ChangeDates()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            var numberOfReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .Count();
            if (numberOfReservations < 1)
            {
                Console.WriteLine("There are no active reservations in the system." +
                "\nPress any key to go back.");

                Console.ReadKey();
            }
            else
            {
                reservationService.ShowReservations(dbContext);

                Console.CursorVisible = true;
                Console.WriteLine("Input Reservation Id to update..");
                Console.Write("Reservation Id: ");

                var reservationIdInput = int.Parse(Console.ReadLine());

                Console.CursorVisible = false;

                Console.WriteLine($"\nPress 'Enter' to change dates of reservation #{reservationIdInput}..");
                Console.Write(new string(' ', Console.WindowWidth));
                Console.ReadKey();

                //// Härifrån har jag klistrat in koden för Change Room.
                /// Fixa så att nuvarande bokning inte blockerar möjligheten att bara lägga
                /// till en extra dag tex.
                var reservationToUpdate = reservationService.GetReservation(reservationIdInput, dbContext);
                var reservationToUpdateId = reservationToUpdate.Id;
                var currentDate = DateTime.Now.Date;

                var currentCheckInDate = reservationToUpdate.CheckinDate;
                var currentCheckOutDate = reservationToUpdate.CheckoutDate;

                var newCheckInDate = calendar.CalendarNavigate(reservationService.CheckInCalendarHeader(), currentDate, reservationService.CheckInCalendarPrompt());
                var newCheckOutDate = calendar.CalendarNavigate(reservationService.CheckOutCalendarHeader(), newCheckInDate, reservationService.CheckOutCalendarPrompt());

                Console.Clear();
                DisplayLogo.Paint();

                reservationService.UpdateReservationDates(reservationToUpdateId, newCheckInDate, newCheckOutDate, dbContext);
            }
        }
        public void UpdateAdditionalBedding()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            var numberOfReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .Count();
            if (numberOfReservations < 1)
            {
                Console.WriteLine("There are no active reservations in the system." +
                "\nPress any key to go back.");

                Console.ReadKey();
            }
            else
            {
                reservationService.ShowReservations(dbContext);

                Console.CursorVisible = true;
                reservationService.ClearLinesAboveReservationInfo();
                reservationService.SetCorrectRowAboveReservationInfo();
                Console.WriteLine("Change Additional Bedding by Reservation Id..");
                Console.Write("Reservation Id: ");

                var reservationIdInput = int.Parse(Console.ReadLine());
                var reservationToUpdate = reservationService.GetReservation(reservationIdInput, dbContext);

                Console.Clear();
                DisplayLogo.Paint();
                reservationService.ShowReservationDetails(reservationToUpdate, dbContext);

                Console.CursorVisible = false;

                reservationService.ClearLinesAboveReservationInfo();
                reservationService.SetCorrectRowAboveReservationInfo();
                
                
                var allowedBedsInRoom = dbContext.Rooms
                    .Where(r => r.Id == reservationToUpdate.Id)
                    .Select(r => r.AdditionalBeddingNumber)
                    .FirstOrDefault();

                if (allowedBedsInRoom == 0)
                {
                    Console.WriteLine("Room cannot have additional beds.");
                    Console.WriteLine("To accommodate extra beds, change room instead.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine($"Enter the desired Extra Beds (max {allowedBedsInRoom})");
                        var desiredNumberOfBeds = int.Parse(Console.ReadLine());
                        if (desiredNumberOfBeds < 0)
                        {
                            Console.WriteLine($"Number must be between 0 and {allowedBedsInRoom}");
                        }
                        else
                        {
                            if (desiredNumberOfBeds > allowedBedsInRoom)
                            {
                                Console.WriteLine($"Try again. Maximum beds allowed: {allowedBedsInRoom}.");
                            }
                            else
                            {
                                reservationService.UpdateNumberOfAdditionalBeds(reservationIdInput, desiredNumberOfBeds, dbContext);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}