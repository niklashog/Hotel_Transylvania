using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Calendars
{
    public class CalendarNavigation(
        ICalendarData calendarData) : ICalendarNavigation
    {
        public DateTime CalendarNavigate(string checkInOrCheckOut)
        {
            var currentDate = DateTime.Now;
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
                            AnsiConsole.MarkupLine($"\nDu valde: [Yellow]{selectedDate:yyyy-MM-dd}[/]");
                            Console.ReadKey();
                            return selectedDate;
                        }
                        else
                        {
                            Console.WriteLine("Bokningar kan endast göras från dagens datum och framåt. Försök igen.");
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
