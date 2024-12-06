using Autofac;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Reservations;

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
            builder.RegisterType<NewReservation>().As<INewReservation>();
            builder.RegisterType<ShowReservations>().As<IShowReservations>();

            builder.RegisterType<NavigateReservationsMenu>().As<INavigateReservationsMenu>();
            builder.RegisterType<ExecuteReservationsMenu>().As<IExecuteReservationsMenu>();
        }
    }
}
