namespace Hotel_Transylvania.Interfaces.CalendarsInterfaces
{
    public interface ICalendarNavigation
    {
        public DateTime CalendarNavigate(string checkInOrCheckOut, DateTime allowedDate, string prompt);
    }
}
