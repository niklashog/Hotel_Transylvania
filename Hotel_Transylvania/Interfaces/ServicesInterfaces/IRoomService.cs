using Hotel_Transylvania.Data;
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
        public void AddRoom(ApplicationDbContext dbContext, Room room);

        public IEnumerable<Room> GetAllRooms(ApplicationDbContext dbContext);
        public void GetActiveRooms(int x, int y, ApplicationDbContext dbContext);
        public void GetInactiveRooms(int x, int y, ApplicationDbContext dbContext);
        public void DisplaySingleRoom(int roomId, int x, int y, ApplicationDbContext dbContext);
        public int CountAllRooms(ApplicationDbContext dbContext);

        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails, ApplicationDbContext dbContext);

        public void RemoveRoom(int roomToDelete, ApplicationDbContext dbContext);
        public void ReActivateRoom(int roomToReactivate, ApplicationDbContext dbContext);
    }
}
