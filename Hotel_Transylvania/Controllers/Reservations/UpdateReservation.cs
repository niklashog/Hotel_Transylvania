﻿using Hotel_Transylvania.Data;
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
        ICalendarNavigation calendar) : IUpdateReservation
    {
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

            var listOfActiveReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .ToList();

            var numberOfActiveReservations = listOfActiveReservations
                .Count();

            var validReservationIds = listOfActiveReservations
                .Select(r => r.Id)
                .ToList();

            if (numberOfActiveReservations <= 0)
            {
                Console.WriteLine("There are no active guests in the system.\n" +
                    "Press any key to go back.");
            }
            else
            {
                reservationService.ShowReservations(dbContext);

                Console.CursorVisible = true;
                //AnsiConsole.MarkupLine("[bold yellow]Change Additional Bedding[/]");

                string reservationIdInputString = AnsiConsole.Prompt(
                    new TextPrompt<string>("Input [yellow]Reservation Id[/] to update beds: ")
                        .ValidationErrorMessage("[red]Please enter a valid Reservation Id[/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int reservationId))
                            {
                                return ValidationResult.Error("[red]Reservation Id has to be a number[/]");
                            }

                            if (!validReservationIds.Contains(reservationId))
                            {
                                return ValidationResult.Error("[red]Reservation Id doesn't exist or isn't active.[/]");
                               
                            }

                            return ValidationResult.Success();
                        })
                        );

                var reservationIdInput = int.Parse(reservationIdInputString);
                var reservationToUpdate = reservationService.GetReservation(reservationIdInput, dbContext);

                Console.Clear();
                DisplayLogo.Paint();
                reservationService.ShowReservationDetails(reservationToUpdate, dbContext);

                var allowedBedsInRoom = dbContext.Rooms
                    .Where(r => r.RoomNumber == reservationToUpdate.RoomNumber)
                    .Select(r => r.AdditionalBeddingNumber)
                    .FirstOrDefault();

                if (allowedBedsInRoom == 0)
                {
                    AnsiConsole.MarkupLine($"[red]Room is to small to accommodate extra beds. " +
                        $"Change room instead.[/]");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    while (true)
                    {
                        string desiredNumberOfBedsString = AnsiConsole.Prompt(
                            new TextPrompt<string>("Input desired [yellow]number[/] of additional beds: ")
                                .ValidationErrorMessage($"[red]Please enter a valid number of beds[/]")
                                .Validate(input =>
                                {
                                    if (!int.TryParse(input, out int numberOfBeds))
                                    {
                                        return ValidationResult.Error("[red]Input has to be a number[/]");
                                    }

                                    return ValidationResult.Success();
                                })
                                );

                        var desiredNumberOfBeds = int.Parse(desiredNumberOfBedsString);

                        if (desiredNumberOfBeds < 0)
                        {
                            AnsiConsole.MarkupLine($"[red]Number must be between 0 and {allowedBedsInRoom}[/]");
                        }
                        else
                        {
                            if (desiredNumberOfBeds > allowedBedsInRoom)
                            {
                                AnsiConsole.MarkupLine($"[red]Try again. No more than {allowedBedsInRoom} extra beds can be accomodated..[/]");
                            }
                            else
                            {
                                reservationService.UpdateNumberOfAdditionalBeds(reservationIdInput, desiredNumberOfBeds, dbContext);
                                AnsiConsole.MarkupLine("[green]Success! Press 'Enter' to continue.[/]");
                                Console.ReadKey();
                                return;
                            }
                        }
                    }

                }
            }
        }
    }
}