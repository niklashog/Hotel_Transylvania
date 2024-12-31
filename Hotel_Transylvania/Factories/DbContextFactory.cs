using Autofac;
using Hotel_Transylvania.Data;

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
