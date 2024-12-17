using System;
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
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext_FAKE _dbContext;

        public void AddReservation(int guestId, Reservation reservation)
        {
            
            
            
            // Nu har jag fått Guest ID och en Reservation.
            // Metod som uppdaterar lista på Guest med Rumsnummer och datum.
            // RoomService behöver metod GetFreeRooms.

            _dbContext.Reservations.Add(reservation);   //?????

        }
    }
}