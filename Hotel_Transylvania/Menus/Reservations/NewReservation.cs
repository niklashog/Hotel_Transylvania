﻿using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class NewReservation : INewReservation
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("I HAS NEW  RESERVATION");
            Console.ReadKey();
        }
    }
}
