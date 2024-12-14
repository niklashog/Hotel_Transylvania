using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.MenuNavigation
{
    public class CalendarNavigation(
        ICalendarData calendarData) : ICalendarNavigation
    {
        public DateTime CalendarNavigate(string checkInOrCheckOut, DateTime allowedDate)
        {
            var currentDate = allowedDate;
            var selectedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day);

            while (true)
            {
                Console.Clear();
                calendarData.RenderCalendar(selectedDate, checkInOrCheckOut);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        selectedDate = selectedDate.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedDate = selectedDate.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        selectedDate = selectedDate.AddDays(-7);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedDate = selectedDate.AddDays(7);
                        break;
                    case ConsoleKey.Enter:
                        if (selectedDate.Date >= currentDate.Date)
                        {
                            AnsiConsole.MarkupLine($"\nSelected date: [Yellow]{selectedDate:yyyy-MM-dd}[/]");
                            Console.ReadKey();
                            return selectedDate;
                        }
                        else
                        {
                            Console.WriteLine("Bookings can only be made from today's date and forward. Try again.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.Escape:
                        break;
                }
            }
        }
    }
}
