using System;
using System.Collections.Generic;

namespace Hotel_Transylvania.Models
{
    public enum TypeOfRoom
    {
        Single,
        Double,
        Suite
    }

    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int? ReservationId { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }
        public int AdditionalBeddingNumber { get; set; }
        public bool IsRoomActive { get; set; } = true;
    }
}