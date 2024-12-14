using Hotel_Transylvania.Interfaces.ModelsInterfaces;
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
        public void AddRoom(IRoom room);

        public IEnumerable<IRoom> GetAllRooms();
        public void DisplayActiveRooms(int x, int y);
        public void DisplayInactiveRooms(int x, int y);
        public void DisplaySingleRoom(int roomId, int x, int y);
        public int CountAllRooms();
        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails);
        public void RemoveRoom(int roomToDelete);
        public void ReActivateRoom(int roomToReactivate);
    }
}
