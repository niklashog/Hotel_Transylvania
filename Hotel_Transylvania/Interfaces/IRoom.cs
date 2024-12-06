using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces
{
    public interface IRoom
    {
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }
        public bool HasAdditionalBedding { get; set; }
        public int AdditionalBeddingNumber { get; set; }
        public bool IsRoomActive { get; set; }
        public static List<IRoom> ListOfAllRooms { get; set; } = new List<IRoom>();
    }
}
