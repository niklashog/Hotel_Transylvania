using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Reservations;

namespace Hotel_Transylvania.Factories
{
    public class ReservationsFactory
    {
        //public static IContainer _reservationsContainer;

        //public static void BuildReservationsContainer()
        //{
        //    var reservationsBuilder = new ContainerBuilder();

        //    //Menu
        //    reservationsBuilder.RegisterType<ReservationsMenu>().As<IReservationsMenu>();
        //    reservationsBuilder.RegisterType<CancelledReservations>().As<ICancelledReservations>();
        //    reservationsBuilder.RegisterType<CancelReservation>().As<ICancelReservation>();
        //    reservationsBuilder.RegisterType<ChangeReservation>().As<IChangeReservation>();
        //    reservationsBuilder.RegisterType<NewReservation>().As<INewReservation>();
        //    reservationsBuilder.RegisterType<ShowReservations>().As<IShowReservations>();

        //    reservationsBuilder.RegisterType<NavigateReservationsMenu>().As<INavigateReservationsMenu>();
        //    reservationsBuilder.RegisterType<ExecuteReservationsMenu>().As<IExecuteReservationsMenu>();

        //    _reservationsContainer = reservationsBuilder.Build();
        //}

        //public static T ResolveReservations<T>()
        //{

        //    return _reservationsContainer.Resolve<T>();

        //}
    }
}
