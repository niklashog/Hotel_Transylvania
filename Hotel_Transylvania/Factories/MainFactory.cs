using Autofac;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Menus.Main;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Menus.MenuServices;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MainMenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;

namespace Hotel_Transylvania.Factories
{
    public class MainFactory
    {
        public static IContainer _container;

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            GuestsFactory.GuestsContainer(builder);
            ReservationsFactory.ReservationsContainer(builder);
            RoomsFactory.RoomsContainer(builder);

            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<NavigateMainMenu>().As<INavigateMainMenu>();
            builder.RegisterType<ExecuteMainMenu>().As<IExecuteMainMenu>();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<MenuHighlight>().As<IMenuHighlight>();
            builder.RegisterType<PrintInactiveGuests>().As<IPrintInactiveGuests>();
            builder.RegisterType<PrintActiveGuests>().As<IPrintActiveGuests>();


            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
