namespace Hotel_Transylvania.Display
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

        public static void PaintInitializing()
        {
            DisplayLogo.Paint();
            Console.WriteLine("Initializing database.");
            Thread.Sleep(500);
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("Initializing database..");
            Thread.Sleep(500);
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("Initializing database...");
        }
    }
}
