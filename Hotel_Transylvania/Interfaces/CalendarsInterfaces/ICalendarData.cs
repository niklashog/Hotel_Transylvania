using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.CalendarsInterfaces
{
    public interface ICalendarData
    {
        public void RenderCalendar(DateTime selectedDate, string checkInOrCheckOut);
    }
}
