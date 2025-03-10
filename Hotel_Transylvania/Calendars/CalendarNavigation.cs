﻿using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Spectre.Console;

namespace Hotel_Transylvania.Calendars
{
    public class CalendarNavigation(
        ICalendarData calendarData,
        IMainMenu mainMenu) : ICalendarNavigation
    {
        public DateTime CalendarNavigate(string checkInOrCheckOut, DateTime dateFrom, string prompt)
        {
            var currentDate = dateFrom;
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
                            AnsiConsole.MarkupLine($"\nSelected date: [Yellow]{selectedDate:yyyy-MM-dd}[/]. Press any key to {prompt}.. ");
                            Console.ReadKey();
                            return selectedDate.Date;
                        }
                        else
                        {
                            Console.WriteLine("Reservations can only be made from today and forward. Try again.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.Escape:
                        mainMenu.Execute();
                        break;
                }
            }
        }
    }
}
