using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Guests
{
    public class DeactivateGuest : IDeactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("I DEACTIVATE GUEST");
            Console.ReadKey();
        }
    }
}
