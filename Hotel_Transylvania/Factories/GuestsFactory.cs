using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Menus.Guests;
using Hotel_Transylvania.Menus;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;

namespace Hotel_Transylvania.Factories
{
    public class GuestsFactory
    {
        public static void GuestsContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Guest>().AsSelf();

            builder.RegisterType<GuestsMenu>().As<IGuestsMenu>();
            builder.RegisterType<DeactivateGuest>().As<IDeactivateGuest>();
            builder.RegisterType<ReactivateGuest>().As<IReactivateGuest>();
            builder.RegisterType<RegisterGuest>().As<IRegisterGuest>();
            builder.RegisterType<ShowActiveGuests>().As<IShowActiveGuests>();
            builder.RegisterType<ShowInactiveGuests>().As<IShowInactiveGuests>();
            builder.RegisterType<UpdateGuest>().As<IUpdateGuest>();

            builder.RegisterType<NavigateGuestsMenu>().As<INavigateGuestsMenu>();
            builder.RegisterType<ExecuteGuestsMenu>().As<IExecuteGuestsMenu>();

            builder.RegisterType<GuestService>().As<IGuestService>();
        }
    }
}
