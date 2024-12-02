﻿using Hotel_Transylvania.Interfaces;

namespace Hotel_Transylvania.Graphics
{
    public static class DisplayLogo
    {
        public static void Paint()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"╔╗ ╔═╗╔═╗╦     ┬            │
╠╩╗║ ║║ ║║    ┌┼─           │
╚═╝╚═╝╚═╝╩═╝  └┘            │
╔╗ ╦═╗╔═╗╔═╗╦╔═╔═╗╔═╗╔═╗╔╦╗ │
╠╩╗╠╦╝║╣ ╠═╣╠╩╗╠╣ ╠═╣╚═╗ ║  │
╚═╝╩╚═╚═╝╩ ╩╩ ╩╚  ╩ ╩╚═╝ ╩  │
────────────────────────────┘
");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
