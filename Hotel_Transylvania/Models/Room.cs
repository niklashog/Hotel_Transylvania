using System;
using System.Collections.Generic;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;

namespace Hotel_Transylvania.Models
{
    public enum TypeOfRoom
    {
        Single,
        Double,
        Suite
    }

    public class Room : IRoom
    {
        public int RoomNumber { get; set; }
        public int ReservationID { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }
        public int AdditionalBeddingNumber { get; set; } = 0;
        public bool IsRoomActive { get; set; } = true;
    }
}
