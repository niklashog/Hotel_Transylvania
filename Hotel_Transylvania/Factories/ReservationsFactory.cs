using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Reservations;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Menus;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Calendars;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;

namespace Hotel_Transylvania.Factories
{
    public static class ReservationsFactory
    {
        public static void ReservationsContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Reservation>().As<IReservation>();

            builder.RegisterType<ReservationsMenu>().As<IReservationsMenu>();
            builder.RegisterType<CancelledReservations>().As<ICancelledReservations>();
            builder.RegisterType<CancelReservation>().As<ICancelReservation>();
            builder.RegisterType<ChangeReservation>().As<IChangeReservation>();
            builder.RegisterType<ReservationMenu>().As<INewReservation>();
            builder.RegisterType<ShowReservations>().As<IShowReservations>();

            builder.RegisterType<NavigateReservationsMenu>().As<INavigateReservationsMenu>();
            builder.RegisterType<ExecuteReservationsMenu>().As<IExecuteReservationsMenu>();

            builder.RegisterType<ReservationService>().As<IReservationService>();

            builder.RegisterType<CalendarData>().As<ICalendarData>();
            builder.RegisterType<CalendarNavigation>().As<ICalendarNavigation>();
        }
    }
}
