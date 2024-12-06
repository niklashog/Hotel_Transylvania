using System;
using System.Collections.Generic;
using Hotel_Transylvania.Interfaces;

namespace Hotel_Transylvania
{
    public enum TypeOfRoom
    {
        Single,
        Double,
        KingSize,
    }

    public class Room : IRoom
    {
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }
        public bool HasAdditionalBedding { get; set; } = false;
        public int AdditionalBeddingNumber { get; set; } = 0;
        public bool IsRoomActive { get; set; } = true;
        public static List<IRoom> ListOfAllRooms { get; set; } = new List<IRoom>();
    }
}
