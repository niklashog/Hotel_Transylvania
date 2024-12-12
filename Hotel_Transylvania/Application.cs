using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania
{
    public class Application(
        IMainMenu mainMenu,
        IDataInitializer dataInitializer
        ) : IApplication
    {
        public void Run()
        {
            dataInitializer.SeedData();
            mainMenu.Execute();
        }
    }
}