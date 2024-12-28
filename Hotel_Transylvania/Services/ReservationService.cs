using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace Hotel_Transylvania.Services
{
    public class ReservationService : IReservationService
    {

        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate, ApplicationDbContext dbContext)
        {
            var allRooms = dbContext.Rooms
                .ToList();

            var unavailableRooms = dbContext.Reservations
                .Where(r => r.CheckinDate < checkoutDate && r.CheckoutDate > checkinDate && r.IsReservationActive)
                .ToList();

            var reservedRoomNumbers = unavailableRooms
                .Select(r => r.RoomNumber)
                .Distinct()
                .ToList();

            var availableRooms = allRooms
                .Where(r => !reservedRoomNumbers
                .Contains(r.RoomNumber))
                .ToList();

            return availableRooms;
        }
        public void DisplayAvailableRoomsForReservations(DateTime checkinDate, DateTime checkoutDate, ApplicationDbContext dbContext)
        {
            var allRooms = dbContext.Rooms.ToList();

            var unavailableRooms = dbContext.Reservations
                .Where(r => r.CheckinDate < checkoutDate && r.CheckoutDate > checkinDate && r.IsReservationActive)
                .ToList();

            var reservedRoomNumbers = unavailableRooms
                .Select(r => r.RoomNumber)
                .Distinct()
                .ToList();

            var availableRooms = allRooms
                .Where(r => !reservedRoomNumbers.Contains(r.RoomNumber))
                .ToList();

            var desiredAdditionalBeddingRequest = availableRooms
                .Where(r => r.AdditionalBeddingNumber > 0)
                .ToList();

            var table = new Table();
            table.Border = TableBorder.Simple;

            table.AddColumn("Room Number");
            table.AddColumn("Room Type");
            table.AddColumn("Room Size");
            table.AddColumn("Additional bedding");

            foreach (var room in availableRooms)
            {
                table.AddRow(
                    room.RoomNumber.ToString(),
                    room.RoomType.ToString(),
                    $"{room.RoomSize.ToString()}m²",
                    $"#{room.AdditionalBeddingNumber.ToString()}"
                );
            }

            AnsiConsole.MarkupLine("[yellow]Available Rooms[/]");
            AnsiConsole.Write(table);
        }
        public void DisplayAvailableRoomsWithAdditionalBeddingRequest(
            DateTime checkinDate, DateTime checkoutDate, int beddingRequest, ApplicationDbContext dbContext)
        {
            var allRooms = dbContext.Rooms.ToList();

            var unavailableRooms = dbContext.Reservations
                .Where(r => r.CheckinDate < checkoutDate && r.CheckoutDate > checkinDate)
                .Where(r => r.IsReservationActive)
                .Where(r => r.NumberOfAdditionalBeds < beddingRequest)
                .ToList();

            var reservedRoomNumbers = unavailableRooms
                .Select(r => r.RoomNumber)
                .Distinct()
                .ToList();

            var availableRooms = allRooms
                .Where(r => !reservedRoomNumbers.Contains(r.RoomNumber))
                .ToList();


            var table = new Table();
            table.Border = TableBorder.Simple;

            table.AddColumn("Room Number");
            table.AddColumn("Room Type");
            table.AddColumn("Room Size");
            table.AddColumn("Additional bedding");

            foreach (var room in availableRooms)
            {
                table.AddRow(
                    room.RoomNumber.ToString(),
                    room.RoomType.ToString(),
                    $"{room.RoomSize.ToString()}m²",
                    $"#{room.AdditionalBeddingNumber.ToString()}"
                );
            }

            AnsiConsole.MarkupLine("[yellow]Available Rooms[/]");
            AnsiConsole.Write(table);
        }


        public void ClearLinesAboveReservationInfo()
        {
            Console.SetCursorPosition(0, 7);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
        }
        public void SetCorrectRowAboveReservationInfo()
        {
            Console.SetCursorPosition(0, 7);
        }

        public void AddReservation(string guestIdString, 
            DateTime checkinDate, DateTime checkoutDate, 
            string roomNumberString, ApplicationDbContext dbContext)
        {

            var guestId = int.Parse(guestIdString);
            var roomNumber = int.Parse(roomNumberString);

            if (!GetAvailableRooms(checkinDate, checkoutDate, dbContext)
                .Any(r => r.RoomNumber == roomNumber))
            {
                throw new Exception("Room is unavailable on the selected dates. Try again.");
            }
            else
            {
                var guest = dbContext.Guests
                    .FirstOrDefault(g => g.Id == guestId);
                var room = dbContext.Rooms
                    .FirstOrDefault(r => r.RoomNumber == roomNumber);

                if (guest == null || room == null)
                {
                    throw new InvalidOperationException("Guest or Room not found.");
                }
                else
                {
                    var reservation = new Reservation()
                    {
                        GuestId = guestId,
                        RoomNumber = roomNumber,
                        CheckinDate = checkinDate,
                        CheckoutDate = checkoutDate,
                        TimeOfReservation = DateTime.Now,
                        IsReservationActive = true
                    };

                    guest.Reservations.Add(reservation);
                    room.Reservations.Add(reservation);
                    dbContext.Reservations.Add(reservation);

                    dbContext.SaveChanges();
                }
            }
        }

        public int CountReservations(ApplicationDbContext dbContext)
        {
            return dbContext.Reservations.Count();
        }

        public void ShowReservations(ApplicationDbContext dbContext)
        {
            var table = new Table();
            table.Border = TableBorder.Simple;

            table.AddColumn("Primary Guest");
            table.AddColumn("Room");
            table.AddColumn("Check-in");
            table.AddColumn("Check-out");
            table.AddColumn("Reservation Number");

            var guestReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .Include(r => r.Guests)
                .ToList();

            foreach (var reservation in guestReservations)
            {
                foreach (var guest in reservation.Guests)
                {
                    table.AddRow(
                        $"{guest.Id} {guest.FirstName} {guest.Surname}",
                        reservation.RoomNumber.ToString(),

                        reservation.CheckinDate.ToString("yyyy-MM-dd"),
                        reservation.CheckoutDate.ToString("yyyy-MM-dd"),
                        reservation.Id.ToString()
                    );
                }
            }
            AnsiConsole.MarkupLine("[yellow]Active Reservations[/]");
            AnsiConsole.Write(table);
        }
        public void ShowInactiveReservations(ApplicationDbContext dbContext)
        {
            var table = new Table();
            table.Border = TableBorder.Simple;

            table.AddColumn("Primary Guest");
            table.AddColumn("Room");
            table.AddColumn("Check-in");
            table.AddColumn("Check-out");
            table.AddColumn("Reservation Number");

            var guestReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive == false)
                .Include(r => r.Guests)
                .ToList();

            foreach (var reservation in guestReservations)
            {
                foreach (var guest in reservation.Guests)
                {
                    table.AddRow(
                        $"{guest.Id} {guest.FirstName} {guest.Surname}",
                        reservation.RoomNumber.ToString(),
                        reservation.CheckinDate.ToString("yyyy-MM-dd"),
                        reservation.CheckoutDate.ToString("yyyy-MM-dd"),
                        reservation.Id.ToString()
                    );
                }
            }

            AnsiConsole.MarkupLine("[yellow]Inactive Reservations[/]");
            AnsiConsole.Write(table);
        }

        public void ShowReservationDetails(Reservation reservationToChange, 
            ApplicationDbContext dbContext)
        {
            var reservationMatch = dbContext.Reservations
                .Where(r => r.Id == reservationToChange.Id)
                .Include(r => r.Guests)
                .Include(r => r.Rooms)
                .ToList();
            
            var table = new Table();
            table.Border = TableBorder.Simple;

            table.AddColumn("Reservation Id");
            table.AddColumn("Primary Guest");
            table.AddColumn("Room");
            table.AddColumn("Check-in");
            table.AddColumn("Check-out");
            table.AddColumn("Time of Reservation");
            table.AddColumn("Additional bedding");

            foreach (var reservation in reservationMatch)
            {
                foreach (var room in reservation.Rooms)
                {
                    foreach (var guest in reservation.Guests)
                    {
                        table.AddRow(
                            reservation.Id.ToString(),
                            $"{guest.FirstName} {guest.Surname}",
                            reservation.RoomNumber.ToString(),
                            reservation.CheckinDate.ToString("yyyy-MM-dd"),
                            reservation.CheckoutDate.ToString("yyyy-MM-dd"),
                            reservation.TimeOfReservation.ToString("yyyy-MM-dd"),
                            $"{reservation.NumberOfAdditionalBeds.ToString()} / {room.AdditionalBeddingNumber.ToString()}"
                        );
                    }
                }

            }
            AnsiConsole.MarkupLine("[yellow]Reservation Details[/]");
            AnsiConsole.Write(table);
        }

        public void UpdateReservationDetails(Reservation reservation, 
            int roomNumber, DateTime checkinDate, DateTime checkoutDate,
            int extraBeds, ApplicationDbContext dbContext)
        {
            reservation.RoomNumber = roomNumber;
            reservation.CheckinDate = checkinDate;
            reservation.CheckoutDate = checkoutDate;
            reservation.NumberOfAdditionalBeds = extraBeds;

            dbContext.SaveChanges();
        }
        public void RemoveReservation(string reservationToRemoveString, 
            ApplicationDbContext dbContext)
        {
            var reservationToRemove = int.Parse(reservationToRemoveString);

            var guestsWithReservation = dbContext.Guests
                .Where(g => g.Reservations.Count > 0)
                .ToList();

            guestsWithReservation
                .ForEach(g =>
                {
                    g.Reservations
                    .Where(r => r.Id == reservationToRemove)
                    .ToList()
                    .ForEach(r =>
                    {
                        r.IsReservationActive = false;
                    });
                });
            dbContext.SaveChanges();
        }
        public Reservation GetReservation(int findReservationById, 
            ApplicationDbContext dbContext)
        {
            var reservation = dbContext.Reservations
            .First(g => g.Id == findReservationById);

            return reservation;
        }
        public void UpdateNumberOfAdditionalBeds(int reservationId, int numberOfBeds, 
            ApplicationDbContext dbContext)
        {
            var reservationToUpdate = dbContext.Reservations
                .First(r => r.Id == reservationId);

            reservationToUpdate.NumberOfAdditionalBeds = numberOfBeds;

            dbContext.SaveChanges();
        }
        public void UpdateReservedRoom(int reservationId, int roomNumber, 
            ApplicationDbContext dbContext)
        {
            var reservationToUpdate = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .First(r => r.Id == reservationId);
            if (reservationToUpdate.IsReservationActive == false)
            {
                Console.WriteLine("No active reservation with that number.");
            }
            else
            {
                reservationToUpdate.RoomNumber = roomNumber;
                dbContext.SaveChanges();
            }
        }
        public void UpdateReservationDates(int reservationId, 
            DateTime newCheckinDate, DateTime newCheckoutDate, 
            ApplicationDbContext dbContext)
        {
            var reservationToUpdate = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .First(r => r.Id == reservationId);
            if (reservationToUpdate.IsReservationActive == false)
            {
                Console.WriteLine("No active reservation with that number.");
            }
            else
            {
                reservationToUpdate.CheckinDate = newCheckinDate;
                reservationToUpdate.CheckoutDate = newCheckoutDate;
                dbContext.SaveChanges();
            }
        }

        public void DeactivateReservationsByCheckoutDate(ApplicationDbContext dbContext)
        {
            var reservationsToDeactivate = dbContext.Reservations
                .Where(r => r.IsReservationActive && r.CheckoutDate.Date <= DateTime.Today)
                .ToList();

            foreach (var reservation in reservationsToDeactivate)
            {
                reservation.IsReservationActive = false;
            }
            dbContext.SaveChanges();
        }
        public string CheckInCalendarPrompt()
        {
            return "chose desired check-out date.";
        }
        public string CheckOutCalendarPrompt()
        {
            return "chose desired room for the stay.";
        }
        public string CheckInCalendarHeader()
        {
            return "CheckIn─Date";
        }
        public string CheckOutCalendarHeader()
        {
            return "CheckOut─Date";
        }
    }
}