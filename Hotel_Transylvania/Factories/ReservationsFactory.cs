﻿using Autofac;
using Hotel_Transylvania.Calendars;
using Hotel_Transylvania.Controllers.Reservations;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.ControllerInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Menus;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Reservations;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Factories
{
    public static class ReservationsFactory
    {
        public static void ReservationsContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Reservation>().AsSelf();

            builder.RegisterType<ReservationsMenu>().As<IReservationsMenu>();
            builder.RegisterType<UpdateReservationMenu>().As<IUpdateReservationMenu>();
            builder.RegisterType<AddReservation>().As<IAddReservation>();
            builder.RegisterType<DeactivateReservation>().As<IDeactivateReservation>();
            builder.RegisterType<UpdateReservation>().As<IUpdateReservation>();
            builder.RegisterType<ShowReservations>().As<IShowReservations>();
            builder.RegisterType<ShowInactiveReservations>().As<IShowInactiveReservations>();

            builder.RegisterType<NavigateReservationsMenu>().As<INavigateReservationsMenu>();
            builder.RegisterType<ExecuteReservationsMenu>().As<IExecuteReservationsMenu>();

            builder.RegisterType<NavigateUpdateReservationMenu>().As<INavigateUpdateReservationMenu>();
            builder.RegisterType<ExecuteUpdateReservationMenu>().As<IExecuteUpdateReservationMenu>();

            builder.RegisterType<ReservationService>().As<IReservationService>();

            builder.RegisterType<DisplayCalendar>().As<ICalendarData>();
            builder.RegisterType<CalendarNavigation>().As<ICalendarNavigation>();
        }
    }
}
