using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;

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
