using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Calendars
{
    public class DisplayCalendar : ICalendarData
    {
        public void RenderCalendar(DateTime selectedDate, string checkInOrCheckOut)
        {
            DisplayLogo.Paint();
            var calendarContent = new StringWriter();

            calendarContent.WriteLine($"[Yellow]{selectedDate:MMMM yyyy}[/]".ToUpper());
            calendarContent.WriteLine("Mon  Tue  Wed  Thu  Fri  Sat  Sun");
            calendarContent.WriteLine("[Yellow]─────────────────────────────────[/]");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = startDay == 0 ? 6 : startDay - 1;

            for (int i = 0; i < startDay; i++)
            {
                calendarContent.Write("     ");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    calendarContent.Write($"[Yellow]{day,2}[/]   ");
                }
                else
                {
                    calendarContent.Write($"{day,2}   ");
                }

                if ((startDay + day) % 7 == 0)
                {
                    calendarContent.WriteLine();
                }
            }

            var panel = new Panel(calendarContent.ToString())
            {
                Border = BoxBorder.Square,
                BorderStyle = new Style(Color.Yellow),
                Header = new PanelHeader($"[Yellow]{checkInOrCheckOut.ToUpper()}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nUse arrow keys [Yellow]\u25C4 \u25B2 \u25BA \u25BC[/] to navigate \n" +
                "and use [Yellow]Enter[/] to confirm date.\n" +
                "Press 'Esc' to go back to main menu.");
        }
    }
}
