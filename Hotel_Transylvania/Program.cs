using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Autofac;

namespace Hotel_Transylvania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassFactory.BuildContainer();
            var app = ClassFactory.Resolve<IApplication>();
            app.Run();
        }
    }
}
