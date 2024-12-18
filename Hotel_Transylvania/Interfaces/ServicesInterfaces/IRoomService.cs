using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IRoomService
    {
        public void AddRoom(Room room);

        public IEnumerable<Room> GetAllRooms();
        public void GetActiveRooms(int x, int y);
        public void GetInactiveRooms(int x, int y);
        public void DisplaySingleRoom(int roomId, int x, int y);
        public int CountAllRooms();
        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails);
        public void RemoveRoom(int roomToDelete);
        public void ReActivateRoom(int roomToReactivate);
    }
}
