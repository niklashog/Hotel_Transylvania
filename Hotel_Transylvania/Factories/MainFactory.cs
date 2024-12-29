using Autofac;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Menus.MenuExecution;
using Hotel_Transylvania.Menus.MenuNavigation;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Menus;

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
            DbContextFactory.DbContextContainer(builder);

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<MenuHighlight>().As<IMenuHighlight>();
            builder.RegisterType<NavigateMainMenu>().As<INavigateMainMenu>();
            builder.RegisterType<ExecuteMainMenu>().As<IExecuteMainMenu>();

            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
