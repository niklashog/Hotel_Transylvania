using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Calendars
{
    public class CalendarData : ICalendarData
    {
        public void RenderCalendar(DateTime selectedDate, string checkInOrCheckOut)
        {
            DisplayLogo.Paint();
            var calendarContent = new StringWriter();

            // Kalenderhuvud
            calendarContent.WriteLine($"[Yellow]{selectedDate:MMMM yyyy}[/]".ToUpper());
            calendarContent.WriteLine("Mån  Tis  Ons  Tor  Fre  Lör  Sön");
            calendarContent.WriteLine("[Yellow]─────────────────────────────────[/]");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = (startDay == 0) ? 6 : startDay - 1; // Justera för måndag som veckostart

            // Fyll med tomma platser innan första dagen i månaden
            for (int i = 0; i < startDay; i++)
            {
                calendarContent.Write("     ");
            }

            // Skriv ut dagarna
            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    // Siffran 2 sätter minimum bredd (även om 1 siffra)
                    calendarContent.Write($"[Yellow]{day,2}[/]   ");
                }
                else
                {
                    calendarContent.Write($"{day,2}   ");
                }

                // Gå till nästa rad efter söndag
                if ((startDay + day) % 7 == 0)
                {
                    calendarContent.WriteLine();
                }
            }

            // Skapa en panel med singel kant
            var panel = new Panel(calendarContent.ToString())
            {
                Border = BoxBorder.Square,
                BorderStyle = new Style(Color.Yellow),
                Header = new PanelHeader(($"[Yellow]{checkInOrCheckOut.ToUpper()}[/]"), Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [Yellow]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [Yellow]Enter[/] för att välja.");
        }
    }
}
