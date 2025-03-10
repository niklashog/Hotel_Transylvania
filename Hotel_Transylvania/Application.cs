﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;

namespace Hotel_Transylvania
{
    public class Application(
        IMainMenu mainMenu
        ) : IApplication
    {
        public void Run()
        {
            DisplayLogo.PaintInitializing();

            using var dbContext = ApplicationDbContext.GetDbContext();
            DataInitializer.MigrateAndSeed(dbContext);
            mainMenu.Execute();
        }
    }
}