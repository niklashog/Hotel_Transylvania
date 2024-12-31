using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace Hotel_Transylvania.Services
{
    public class GuestService : IGuestService
    {
        public void AddGuest(Guest guest, ApplicationDbContext dbContext)
        {
            dbContext.Guests.Add(guest);
            dbContext.SaveChanges();
        }

        public IEnumerable<Guest> GetAllGuests(ApplicationDbContext dbContext)
        {
            return dbContext.Guests;
        }
        public void DisplayActiveGuests(ApplicationDbContext dbContext)
        {
            var activeGuests = dbContext.Guests
                .Where(g => g.IsGuestActive)
                .Include(g => g.Reservations)
                .ToList();

            if (activeGuests.Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]There are no active guests in the system.[/]");
                AnsiConsole.MarkupLine("Press 'Enter' to go back.");
            }
            else
            {
                var table = new Table();
                table.Border = TableBorder.Simple;

                table.AddColumn("Guest Id");
                table.AddColumn("Name");
                table.AddColumn("Phone");
                table.AddColumn("E-mail");
                table.AddColumn("Active Reservation");

                foreach (var guest in activeGuests)
                {
                    var hasActiveReservation = guest.Reservations.Any(r => r.IsReservationActive);

                    table.AddRow(
                        guest.Id.ToString(),
                        $"{guest.FirstName} {guest.Surname}",
                        $"{guest.Phone}",
                        $"{guest.Email}",
                        hasActiveReservation ? "*" : ""
                    );
                }

                AnsiConsole.Write(table);
            }
        }
        public void DisplayInactiveGuests(ApplicationDbContext dbContext)
        {
            var inactiveGuests = dbContext.Guests
                            .Where(g => g.IsGuestActive == false)
                            .ToList();
            if (inactiveGuests.Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]There are no inactive guests in the system.[/]");
                AnsiConsole.MarkupLine("Press 'Enter' to go back.");
            }
            else
            {
                var table = new Table();
                table.Border = TableBorder.Simple;

                table.AddColumn("Guest Id");
                table.AddColumn("Name");
                table.AddColumn("Phone");
                table.AddColumn("E-mail");

                foreach (var guest in inactiveGuests)
                {
                    table.AddRow(
                        guest.Id.ToString(),
                        $"{guest.FirstName} {guest.Surname}",
                        $"{guest.Phone}",
                        $"{guest.Email}"
                    );
                }

                AnsiConsole.Write(table);
            }
        }

        public void DisplayGuestDetails(int guestId, ApplicationDbContext dbContext)
        {
            var selectedGuest = dbContext.Guests
                .First(g => g.Id == guestId);

            var activeStatus = selectedGuest.IsGuestActive ? "Active" : "Inactive";

            var guestTable = new Table();
            guestTable.Border = TableBorder.Simple;

            guestTable.AddColumn("Field");
            guestTable.AddColumn("Details");

            guestTable.AddRow("First Name", selectedGuest.FirstName);
            guestTable.AddRow("Surname", selectedGuest.Surname);
            guestTable.AddRow("E-mail", selectedGuest.Email);
            guestTable.AddRow("Phone Number", selectedGuest.Phone);
            guestTable.AddRow("Status", activeStatus);

            AnsiConsole.Write(guestTable);
        }
        public Guest GetGuestById(int guestId, ApplicationDbContext dbContext)
        {
            var selectedGuest = dbContext.Guests
        .First(g => g.Id == guestId);

            return selectedGuest;
        }
        public List<Guest> ListOfActiveGuests(ApplicationDbContext dbContext)
        {
            var listOfActiveGuests = dbContext.Guests
                .Where(g => g.IsGuestActive)
                .ToList();

            return listOfActiveGuests;
        }
        public List<Guest> ListOfInctiveGuests(ApplicationDbContext dbContext)
        {
            var listOfInctiveGuests = dbContext.Guests
                .Where(g => g.IsGuestActive == false)
                .ToList();

            return listOfInctiveGuests;
        }

        public void UpdateGuestDetails(int guestToEdit, string[] editedGuestDetails, ApplicationDbContext dbContext)
        {
            var guestToUpdate = dbContext.Guests
            .First(g => g.Id == guestToEdit);

            guestToUpdate.FirstName = editedGuestDetails[0];
            guestToUpdate.Surname = editedGuestDetails[1];
            guestToUpdate.Email = editedGuestDetails[2];
            guestToUpdate.Phone = editedGuestDetails[3] ?? "---";

            dbContext.SaveChanges();
        }


        public void RemoveGuest(string guestIdToDelete, ApplicationDbContext dbContext)
        {
            var guestToDelete = int.Parse(guestIdToDelete);

            var guest = dbContext.Guests
                .FirstOrDefault(g => g.Id == guestToDelete);

            var hasActiveReservation = guest.Reservations.Any(r => r.IsReservationActive);


            if (hasActiveReservation)
            {
                AnsiConsole.MarkupLine("[bold red]Cannot delete a customer with an active\t" +
                "reservation.[/] \nRemove reservation first and try again.");
            }
            else
            {
                guest.IsGuestActive = false;
                dbContext.SaveChanges();
                AnsiConsole.MarkupLine("[bold green]Registered..[/]");
            }

        }
        public void ReActivateGuest(string guestIdToReactivate, ApplicationDbContext dbContext)
        {
            var guestToReactivate = int.Parse(guestIdToReactivate);

            var guest = dbContext.Guests
                .FirstOrDefault(g => g.Id == guestToReactivate);

            if (guest == null)
            {
                AnsiConsole.MarkupLine("[bold red]No guest found with that Id.[/] Press 'Enter' to continue.");
            }
            else
            {
                guest.IsGuestActive = true;
                dbContext.SaveChanges();
                AnsiConsole.MarkupLine("[bold green]Registered..[/]");
            }
        }
    }
}