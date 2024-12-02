using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MainMenuInterfaces;

namespace Hotel_Transylvania
{
    public class Application(
        IMainMenu mainMenu) : IApplication
    {
        public void Run()
        {
            mainMenu.Execute();
        }
    }
}
