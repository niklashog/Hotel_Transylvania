﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("There are no active guests in the system.");
                Console.WriteLine("Press 'Enter' to go back.");
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
                Console.WriteLine("There are no inactive guests in the system.");
                Console.WriteLine("Press 'Enter' to go back.");
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
        public void PrintGuestDetails(int guestId, ApplicationDbContext dbContext)
        {
                var selectedGuest = dbContext.Guests
                  .First(g => g.Id == guestId);

                var selectedGuestReservations = selectedGuest.Reservations.ToList(); 

                string activeOrInactive;
                if (selectedGuest.IsGuestActive)
                    activeOrInactive = "Active";
                else
                    activeOrInactive = "Inactive";

                Console.WriteLine($"First Name:\t{selectedGuest.FirstName}");
                Console.WriteLine($"Surname:\t{selectedGuest.Surname}");
                Console.WriteLine($"E-mail:\t\t{selectedGuest.Email}");
                Console.WriteLine($"Phone number:\t{selectedGuest.Phone}");
        }
        public Guest GetGuestById(int guestId, ApplicationDbContext dbContext)
        {
                var selectedGuest = dbContext.Guests
            .First(g => g.Id == guestId);

                return selectedGuest;
        }
        public int CountAllGuests(ApplicationDbContext dbContext)
        {
                return dbContext.Guests.Count();
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

            if (guest == null)
            {
                Console.WriteLine("No guest found with that ID.");
            }
            else
            {
                if (hasActiveReservation == false)
                {
                    guest.IsGuestActive = false;
                    dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Registered..[/]");
                }
                else
                {
                    Console.WriteLine("Cannot delete a customer with an active\t" +
                        "reservation. Remove reservation first and try again.");
                    Console.ReadKey();
                }
            }
                
        }
        public void ReActivateGuest(string guestIdToReactivate, ApplicationDbContext dbContext)
        {
            var guestToReactivate = int.Parse(guestIdToReactivate);

            var guest = dbContext.Guests
                .FirstOrDefault(g => g.Id == guestToReactivate);

            if (guest == null)
            {
                AnsiConsole.WriteLine("No guest found with that Id. Press 'Enter' to continue.");
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