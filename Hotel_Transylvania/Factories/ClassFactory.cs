using Hotel_Transylvania.Interfaces;
using Autofac;
using Hotel_Transylvania.Menus.Rooms;
using Hotel_Transylvania.Menus.Guests;
using Hotel_Transylvania.Menus.Reservations;
using Hotel_Transylvania.Menus.Main;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.MenuServices;

namespace Hotel_Transylvania.Factories
{
    internal class ClassFactory
    {
        public static IContainer _container;

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<NavigateMainMenu>().As<INavigateMainMenu>();

            //Menus
            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<GuestsMenu>().As<IGuestsMenu>();
            builder.RegisterType<ReservationsMenu>().As<IReservationsMenu>();
            builder.RegisterType<RoomsMenu>().As<IRoomsMenu>();

                //Rooms
                builder.RegisterType<DeactivateRoom>().As<IDeactivateRoom>();
                builder.RegisterType<ReactivateRoom>().As<IReactivateRoom>();
                builder.RegisterType<ShowAllRooms>().As<IShowAllRooms>();
                builder.RegisterType<ShowInactiveRooms>().As<IShowInactiveRooms>();
                builder.RegisterType<UpdateRoom>().As<IUpdateRoom>();

                //Guests
                builder.RegisterType<DeactivateGuest>().As<IDeactivateGuest>();
                builder.RegisterType<ReactivateGuest>().As<IReactivateGuest>();
                builder.RegisterType<RegisterGuest>().As<IRegisterGuest>();
                builder.RegisterType<ShowAllGuests>().As<IShowAllGuests>();
                builder.RegisterType<ShowInactiveGuests>().As<IShowInactiveGuests>();
                builder.RegisterType<UpdateGuest>().As<IUpdateGuest>();

                //Reservations
                builder.RegisterType<CancelledReservations>().As<ICancelledReservations>();
                builder.RegisterType<CancelReservation>().As<ICancelReservation>();
                builder.RegisterType<ChangeReservation>().As<IChangeReservation>();
                builder.RegisterType<NewReservation>().As<INewReservation>();
                builder.RegisterType<ShowReservations>().As<IShowReservations>();


            //Menu Service
            builder.RegisterType<NavigateMainMenu>().As<INavigateMainMenu>();
            builder.RegisterType<NavigateRoomsMenu>().As<INavigateRoomsMenu>();
            builder.RegisterType<NavigateGuestsMenu>().As<INavigateGuestsMenu>();
            builder.RegisterType<NavigateReservationsMenu>().As<INavigateReservationsMenu>();
            builder.RegisterType<ExecuteMainMenu>().As<IExecuteMainMenu>();
            builder.RegisterType<ExecuteRoomsMenu>().As<IExecuteRoomsMenu>();
            builder.RegisterType<ExecuteGuestsMenu>().As<IExecuteGuestsMenu>();
            builder.RegisterType<ExecuteReservationsMenu>().As<IExecuteReservationsMenu>();
            builder.RegisterType<MenuHighlight>().As<IMenuHighlight>();

            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();

        }
    }
}
