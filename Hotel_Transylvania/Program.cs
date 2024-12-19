using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotel_Transylvania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainFactory.BuildContainer();

            Console.WriteLine("Test");

            var app = MainFactory.Resolve<IApplication>();
            app.Run();
        }
    }
}
