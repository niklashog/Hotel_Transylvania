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
        public void DisplayActiveRooms(ApplicationDbContext dbContext);
        public void DisplayInactiveRooms(ApplicationDbContext dbContext);
        public void DisplaySingleRoom(int roomId, ApplicationDbContext dbContext);
        public int CountAllRooms(ApplicationDbContext dbContext);

        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails, ApplicationDbContext dbContext);

        public void RemoveRoom(int roomToDelete, ApplicationDbContext dbContext);
        public void ReActivateRoom(int roomToReactivate, ApplicationDbContext dbContext);
        public IEnumerable<string> GetExistingRoomNumbersAsString(ApplicationDbContext dbContext);
    }
}