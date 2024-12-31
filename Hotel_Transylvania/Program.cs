using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;

namespace Hotel_Transylvania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainFactory.BuildContainer();

            var app = MainFactory.Resolve<IApplication>();
            app.Run();
        }
    }
}
