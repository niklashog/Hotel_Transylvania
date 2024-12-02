using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Rooms;

namespace Hotel_Transylvania.Factories
{
    public static class RoomsFactory
    {
        public static void RoomsContainer(ContainerBuilder builder)
        {
            builder.RegisterType<RoomsMenu>().As<IRoomsMenu>();
            builder.RegisterType<DeactivateRoom>().As<IDeactivateRoom>();
            builder.RegisterType<ReactivateRoom>().As<IReactivateRoom>();
            builder.RegisterType<ShowAllRooms>().As<IShowAllRooms>();
            builder.RegisterType<ShowInactiveRooms>().As<IShowInactiveRooms>();
            builder.RegisterType<UpdateRoom>().As<IUpdateRoom>();

            builder.RegisterType<NavigateRoomsMenu>().As<INavigateRoomsMenu>();
            builder.RegisterType<ExecuteRoomsMenu>().As<IExecuteRoomsMenu>();
        }
    }
}
