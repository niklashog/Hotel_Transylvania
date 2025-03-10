﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IRoomService
    {
        public void AddRoom(Room room, ApplicationDbContext dbContext);

        public IEnumerable<Room> GetAllRooms(ApplicationDbContext dbContext);
        public void DisplayAllRooms(ApplicationDbContext dbContext);
        public void DisplayActiveRooms(ApplicationDbContext dbContext);
        public void DisplayInactiveRooms(ApplicationDbContext dbContext);
        public void DisplaySingleRoom(int roomId, ApplicationDbContext dbContext);
        public int CountAllRooms(ApplicationDbContext dbContext);

        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails, ApplicationDbContext dbContext);

        public void RemoveRoom(int roomToDelete, IEnumerable<Reservation> listOfActiveReservations, ApplicationDbContext dbContext);
        public void ReActivateRoom(int roomToReactivate, ApplicationDbContext dbContext);
        public IEnumerable<string> GetExistingRoomNumbersAsString(ApplicationDbContext dbContext);

        public IEnumerable<Room> ListOfActiveRooms(ApplicationDbContext dbContext);
        public IEnumerable<Room> ListOfInctiveRooms(ApplicationDbContext dbContext);
    }
}