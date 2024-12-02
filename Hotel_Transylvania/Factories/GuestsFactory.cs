using Autofac;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Menus.Guests;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;

namespace Hotel_Transylvania.Factories
{
    public class GuestsFactory
    {
        //public static IContainer _guestsContainer;

        //public static void BuildGuestsContainer()
        //{
        //    var guestsBuilder = new ContainerBuilder();

        //    //Menu
        //    guestsBuilder.RegisterType<GuestsMenu>().As<IGuestsMenu>();
        //    guestsBuilder.RegisterType<DeactivateGuest>().As<IDeactivateGuest>();
        //    guestsBuilder.RegisterType<ReactivateGuest>().As<IReactivateGuest>();
        //    guestsBuilder.RegisterType<RegisterGuest>().As<IRegisterGuest>();
        //    guestsBuilder.RegisterType<ShowAllGuests>().As<IShowAllGuests>();
        //    guestsBuilder.RegisterType<ShowInactiveGuests>().As<IShowInactiveGuests>();
        //    guestsBuilder.RegisterType<UpdateGuest>().As<IUpdateGuest>();

        //    guestsBuilder.RegisterType<NavigateGuestsMenu>().As<INavigateGuestsMenu>();
        //    guestsBuilder.RegisterType<ExecuteGuestsMenu>().As<IExecuteGuestsMenu>();

        //    _guestsContainer = guestsBuilder.Build();
        //}

        //public static T ResolveGuests<T>()
        //{
        //    return _guestsContainer.Resolve<T>();

        //}
    }
}
