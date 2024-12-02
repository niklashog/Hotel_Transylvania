using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Rooms;

namespace Hotel_Transylvania.Factories
{
    public class RoomsFactory
    {
        //public static IContainer _roomsContainer;

        //public static void BuildRoomsContainer()
        //{
        //    var roomsBuilder = new ContainerBuilder();

        //    //Menu
        //    roomsBuilder.RegisterType<RoomsMenu>().As<IRoomsMenu>();

        //    //Rooms
        //    roomsBuilder.RegisterType<DeactivateRoom>().As<IDeactivateRoom>();
        //    roomsBuilder.RegisterType<ReactivateRoom>().As<IReactivateRoom>();
        //    roomsBuilder.RegisterType<ShowAllRooms>().As<IShowAllRooms>();
        //    roomsBuilder.RegisterType<ShowInactiveRooms>().As<IShowInactiveRooms>();
        //    roomsBuilder.RegisterType<UpdateRoom>().As<IUpdateRoom>();

        //    //Menu function
        //    roomsBuilder.RegisterType<NavigateRoomsMenu>().As<INavigateRoomsMenu>();
        //    roomsBuilder.RegisterType<ExecuteRoomsMenu>().As<IExecuteRoomsMenu>();

        //    _roomsContainer = roomsBuilder.Build();
        //}

        //public static T ResolveRooms<T>()
        //{
        //    return _roomsContainer.Resolve<T>();

        //}
    }
}
