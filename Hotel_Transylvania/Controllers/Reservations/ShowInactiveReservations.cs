﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.ControllerInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;

namespace Hotel_Transylvania.Controllers.Reservations
{
    public class ShowInactiveReservations(
        IReservationService reservationService) : IShowInactiveReservations
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            reservationService.ShowInactiveReservations(dbContext);

            Console.ReadKey();
        }
    }
}
