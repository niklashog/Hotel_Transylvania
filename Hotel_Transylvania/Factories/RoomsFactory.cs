using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.Rooms;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Menus;
using Hotel_Transylvania.Interfaces.MenuInterfaces;

namespace Hotel_Transylvania.Factories
{
    public static class RoomsFactory
    {
        public static void RoomsContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Room>().As<IRoom>();

            builder.RegisterType<RoomsMenu>().As<IRoomsMenu>();
            builder.RegisterType<DeactivateRoom>().As<IDeactivateRoom>();
            builder.RegisterType<ReactivateRoom>().As<IReactivateRoom>();
            builder.RegisterType<RegisterNewRoom>().As<IRegisterNewRoom>();
            builder.RegisterType<ShowActiveRooms>().As<IShowActiveRooms>();
            builder.RegisterType<ShowInactiveRooms>().As<IShowInactiveRooms>();
            builder.RegisterType<UpdateRoom>().As<IUpdateRoom>();

            builder.RegisterType<NavigateRoomsMenu>().As<INavigateRoomsMenu>();
            builder.RegisterType<ExecuteRoomsMenu>().As<IExecuteRoomsMenu>();

            builder.RegisterType<RoomService>().As<IRoomService>();
        }
    }
}
