﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IReservationService
    {
        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate,
            ApplicationDbContext dbContext);
        public IEnumerable<Room> GetAvailableRoomsWithBedding(
            DateTime checkinDate, DateTime checkoutDate,
            int beddingRequest, ApplicationDbContext dbContext);
        public void DisplayAvailableRoomsForReservations(DateTime checkinDate, DateTime checkoutDate,
            List<Room> availableRooms, ApplicationDbContext dbContext);
        public void DisplayAvailableRoomsWithAdditionalBeddingRequest(
            DateTime checkinDate, DateTime checkoutDate, int beddingRequest, ApplicationDbContext dbContext);
        public void AddReservation(string guestIdString, DateTime checkinDate, DateTime checkoutDate,
            string roomNumber, int additionalBeddingNumber, ApplicationDbContext dbContext);
        public void ShowReservations(
            ApplicationDbContext dbContext);
        public void ShowInactiveReservations(
            ApplicationDbContext dbContext);
        public void ShowReservationDetails(Reservation reservationToChange,
            ApplicationDbContext dbContext);
        public void UpdateReservationDetails(Reservation reservation, int roomNumber,
            DateTime checkinDate, DateTime checkoutDate,
            int extraBeds, ApplicationDbContext dbContext);
        public IEnumerable<Reservation> GetListOfAllReservations(
    ApplicationDbContext dbContext);
        public Reservation GetReservation(int findReservationById,
            ApplicationDbContext dbContext);
        public void RemoveReservation(string reservationToRemoveString,
            ApplicationDbContext dbContext);
        public void UpdateNumberOfAdditionalBeds(int reservationId, int numberOfBeds,
            ApplicationDbContext dbContext);
        public void UpdateReservedRoom(int reservationId, int roomNumber,
            ApplicationDbContext dbContext);
        public void UpdateReservationDates(int reservationId,
            DateTime newCheckinDate, DateTime newCheckoutDate,
            ApplicationDbContext dbContext);
        public void DeactivateReservationsByCheckoutDate(
            ApplicationDbContext dbContext);
        public string CheckInCalendarPrompt();
        public string CheckOutCalendarPrompt();
        public string CheckInCalendarHeader();
        public string CheckOutCalendarHeader();
    }
}