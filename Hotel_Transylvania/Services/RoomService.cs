using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Transylvania.Services
{
    public class RoomService : IRoomService
    {
        public void AddRoom(Room room)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var newRoom = room;

                if (newRoom.RoomSize <= 14 || newRoom.RoomType == "Single")
                {
                    Console.WriteLine("Important note. Per guest security reasons," +
                        "this room is too small to accomodate extra beds.");
                }
                else if (newRoom.RoomSize >= 15 && newRoom.RoomSize <= 19)
                {
                    newRoom.AdditionalBeddingNumber = 1;
                    Console.WriteLine("If requested by guest," +
                        "room can accomodate 1 additonal bed.");
                }
                else
                {
                    newRoom.AdditionalBeddingNumber = 2;
                    Console.WriteLine("If requested by guest," +
                        "room can accomodate 2 additonal beds.");
                }

                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Room> GetAllRooms()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                return dbContext.Rooms;
            }
        }
        public void GetActiveRooms(int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var activeRooms = dbContext.Rooms
                .Where(r => r.IsRoomActive)
                .ToList();

                activeRooms
                    .ForEach(r =>
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"# {r.RoomNumber}, {r.RoomType}, {r.RoomSize}m²");
                    });
            }
        }
        public void GetInactiveRooms(int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var inactiveRooms = dbContext.Rooms
            .Where(r => r.IsRoomActive == false)
            .ToList();

                inactiveRooms
                .ForEach(r =>
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"# {r.RoomNumber}, {r.RoomType}, {r.RoomSize}m²");
                });
            }
        }
        public void DisplaySingleRoom(int roomId, int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var selectedRoom = dbContext.Rooms
            .First(r => r.RoomNumber == roomId);

                var roomStatus = "not set";

                if (selectedRoom.IsRoomActive)
                {
                    roomStatus = "Yes";
                }
                else
                {
                    roomStatus = "No";
                }

                Console.SetCursorPosition(x, y);
                Console.WriteLine($"#{selectedRoom.RoomNumber}");
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine($"Type: {selectedRoom.RoomType}");
                Console.SetCursorPosition(x, y + 2);
                Console.WriteLine($"Size: {selectedRoom.RoomSize}m²");
                Console.SetCursorPosition(x, y + 3);
                Console.WriteLine($"Max number of extra beds: {selectedRoom.AdditionalBeddingNumber}");
                Console.SetCursorPosition(x, y + 4);
                Console.WriteLine($"Room active: {roomStatus}");
            }
        }
        public int CountAllRooms()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                return dbContext.Rooms.Count();
            }
        }

        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var roomToUpdate = dbContext.Rooms
                .First(r => r.RoomNumber == roomIdInput);

                roomToUpdate.RoomNumber = updatedRoomDetails.RoomNumber;
                roomToUpdate.RoomType = updatedRoomDetails.RoomType;
                roomToUpdate.RoomSize = updatedRoomDetails.RoomSize;

                if (roomToUpdate.RoomSize <= 14)
                {
                    Console.WriteLine("This room is too small to accomodate extra beds.");

                    roomToUpdate.AdditionalBeddingNumber = 0;
                }
                else if (roomToUpdate.RoomSize >= 15 && roomToUpdate.RoomSize <= 19)
                {
                    Console.WriteLine("If requested by guest," +
                        "room can accomodate 1 additonal bed.");

                    roomToUpdate.AdditionalBeddingNumber = 1;
                }
                else
                {
                    Console.WriteLine("If requested by guest," +
                        "room can accomodate 2 additonal beds.");

                    roomToUpdate.AdditionalBeddingNumber = 2;
                }
                dbContext.SaveChanges();
            }
        }

        public void RemoveRoom(int roomToDelete)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var room = dbContext.Rooms
                .First(r => r.RoomNumber == roomToDelete);

                if (room != null)
                {
                    room.IsRoomActive = false;
                }
                else
                {
                    Console.WriteLine("No room found with that ID.");
                }
                dbContext.SaveChanges();
            }
        }
        public void ReActivateRoom(int roomToReactivate)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                dbContext.Rooms
                .First(g => g.RoomNumber == roomToReactivate)
                .IsRoomActive = true;

                dbContext.SaveChanges();
            }
        }
    }
}