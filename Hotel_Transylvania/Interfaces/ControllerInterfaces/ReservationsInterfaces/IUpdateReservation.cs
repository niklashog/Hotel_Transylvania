﻿using Hotel_Transylvania.Interfaces.ToolsInterfaces;

namespace Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces
{
    public interface IUpdateReservation
    {
        public void ChangeRoomNumber();
        public void ChangeDates();
        public void UpdateAdditionalBedding();
    }
}
