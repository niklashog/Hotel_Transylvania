﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.CalendarsInterfaces
{
    public interface ICalendarNavigation
    {
        public DateTime CalendarNavigate(string checkInOrCheckOut, DateTime allowedDate);
    }
}
