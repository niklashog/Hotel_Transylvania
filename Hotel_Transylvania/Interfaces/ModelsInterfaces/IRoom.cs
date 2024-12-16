using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ModelsInterfaces
{
    public interface IRoom
    {
        public int RoomNumber { get; set; }
        public int ReservationID { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }
        public int AdditionalBeddingNumber { get; set; }
        public bool IsRoomActive { get; set; }

    }
}
