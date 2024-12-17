﻿using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class CancelReservation(
        IReservationService reservationService) : ICancelReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            reservationService.ShowReservations();

            Console.WriteLine("Type reservation id to remove");
            var reservationIdToRemove = int.Parse(Console.ReadLine());

            reservationService.RemoveReservation(reservationIdToRemove);

            Console.ReadKey();
        }
    }
}
