using Hotel_Transylvania.Interfaces;
using Autofac;
using Hotel_Transylvania.Menus.Rooms;
using Hotel_Transylvania.Menus.Guests;
using Hotel_Transylvania.Menus.Reservations;
using Hotel_Transylvania.Menus.Main;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.MenuServices;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MainMenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;

namespace Hotel_Transylvania.Factories
{
    public class ClassFactory
    {
        public static IContainer _container;

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<MenuHighlight>().As<IMenuHighlight>();

            //MainMenu
            builder.RegisterType<MainMenu>().As<IMainMenu>();

            builder.RegisterType<NavigateMainMenu>().As<INavigateMainMenu>();
            builder.RegisterType<ExecuteMainMenu>().As<IExecuteMainMenu>();

            //Guests
            builder.RegisterType<GuestsMenu>().As<IGuestsMenu>();
            builder.RegisterType<DeactivateGuest>().As<IDeactivateGuest>();
            builder.RegisterType<ReactivateGuest>().As<IReactivateGuest>();
            builder.RegisterType<RegisterGuest>().As<IRegisterGuest>();
            builder.RegisterType<ShowAllGuests>().As<IShowAllGuests>();
            builder.RegisterType<ShowInactiveGuests>().As<IShowInactiveGuests>();
            builder.RegisterType<UpdateGuest>().As<IUpdateGuest>();

            builder.RegisterType<NavigateGuestsMenu>().As<INavigateGuestsMenu>();
            builder.RegisterType<ExecuteGuestsMenu>().As<IExecuteGuestsMenu>();

            //Reservations
            builder.RegisterType<ReservationsMenu>().As<IReservationsMenu>();
            builder.RegisterType<CancelledReservations>().As<ICancelledReservations>();
            builder.RegisterType<CancelReservation>().As<ICancelReservation>();
            builder.RegisterType<ChangeReservation>().As<IChangeReservation>();
            builder.RegisterType<NewReservation>().As<INewReservation>();
            builder.RegisterType<ShowReservations>().As<IShowReservations>();

            builder.RegisterType<NavigateReservationsMenu>().As<INavigateReservationsMenu>();
            builder.RegisterType<ExecuteReservationsMenu>().As<IExecuteReservationsMenu>();

            //Rooms
            builder.RegisterType<RoomsMenu>().As<IRoomsMenu>();
            builder.RegisterType<DeactivateRoom>().As<IDeactivateRoom>();
            builder.RegisterType<ReactivateRoom>().As<IReactivateRoom>();
            builder.RegisterType<ShowAllRooms>().As<IShowAllRooms>();
            builder.RegisterType<ShowInactiveRooms>().As<IShowInactiveRooms>();
            builder.RegisterType<UpdateRoom>().As<IUpdateRoom>();

            builder.RegisterType<NavigateRoomsMenu>().As<INavigateRoomsMenu>();
            builder.RegisterType<ExecuteRoomsMenu>().As<IExecuteRoomsMenu>();

            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
