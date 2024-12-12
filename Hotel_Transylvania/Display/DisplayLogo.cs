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
    }
}
