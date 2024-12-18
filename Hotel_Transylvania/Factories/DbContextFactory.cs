using Autofac;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Factories
{

    public class DbContextFactory
    {
        public static void DbContextContainer(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().SingleInstance();
        }
    }
}
