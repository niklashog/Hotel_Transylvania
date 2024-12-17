﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania.Services
{
    public class ReservationService(
        IGuestService guestService) : IReservationService
    {
        private readonly ApplicationDbContext_FAKE _dbContext;

        //Borde denna ligga i Rooms??
        public IEnumerable<IRoom> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate)
        {
            var dbContext = guestService.GetGuestDbContext();

            var allRooms = dbContext.Rooms.ToList();

            var overlappingDates = dbContext.Reservations
                .Where(r => r.CheckinDate < checkoutDate && r.CheckoutDate > checkinDate)
                .ToList();

            var reservedRoomNumbers = overlappingDates
                .Select(r => r.RoomNumber)
                .Distinct()
                .ToList();

            var availableRooms = allRooms
                .Where(r => !reservedRoomNumbers.Contains(r.RoomNumber))
                .ToList();

            return availableRooms;
        }

        public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber)
        {
            var dbContext = guestService.GetGuestDbContext();

            if (!GetAvailableRooms(checkinDate, checkoutDate).Any(r => r.RoomNumber == roomNumber))
            {
                throw new Exception("Room is unavailable on the selected dates.");
            }

            // Funkar detta för reservation id?
            var nextReservationId = CountReservations();

            var reservation = new Reservation()
            {
                ReservationID = nextReservationId,
                GuestID = guestId,
                RoomNumber = roomNumber,
                CheckinDate = checkinDate,
                CheckoutDate = checkoutDate,
                TimeOfReservation = DateTime.Now,
                IsReservationActive = true
            };

            var guestToCheckin = dbContext.Guests
            .Find(g => g.GuestID == guestId);

            guestToCheckin.Reservations.Add(reservation);
        }

        public int CountReservations()
        {
            var dbContext = guestService.GetGuestDbContext();

            return dbContext.Reservations.Count();
        }

    }
}