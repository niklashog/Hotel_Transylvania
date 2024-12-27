using Hotel_Transylvania.Data;
using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IReservationService
    {
        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate,
            ApplicationDbContext dbContext);
        public void DisplayAvailableRoomsForReservations(DateTime checkinDate, DateTime checkoutDate, 
            ApplicationDbContext dbContext);
        public void ClearLinesAboveReservationInfo();
        public void SetCorrectRowAboveReservationInfo();
        public void AddReservation(string guestIdString, DateTime checkinDate, DateTime checkoutDate,
            string roomNumber, ApplicationDbContext dbContext);
        public int CountReservations(
            ApplicationDbContext dbContext);
        public void ShowReservations(
            ApplicationDbContext dbContext);
        public void ShowInactiveReservations(
            ApplicationDbContext dbContext);
        public void ShowReservationDetails(Reservation reservationToChange, 
            ApplicationDbContext dbContext);
        public void UpdateReservationDetails(Reservation reservation, int roomNumber, 
            DateTime checkinDate, DateTime checkoutDate, 
            int extraBeds, ApplicationDbContext dbContext);
        public Reservation GetReservation(int findReservationById, 
            ApplicationDbContext dbContext);
        public void RemoveReservation(int id, 
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