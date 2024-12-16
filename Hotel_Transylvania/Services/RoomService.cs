using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext_FAKE _dbContext;

        public RoomService(ApplicationDbContext_FAKE dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddRoom(IRoom room)
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

            _dbContext.Rooms.Add(room);
        }

        public IEnumerable<IRoom> GetAllRooms()
        {
            return _dbContext.Rooms;
        }
        public void GetActiveRooms(int x, int y)
        {
            var activeRooms= _dbContext.Rooms
                .Where(r => r.IsRoomActive)
                .ToList();

            activeRooms
                .ForEach(r =>
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"# {r.RoomID}, {r.RoomType}, {r.RoomSize}m²");
                });
        }
        public void GetInactiveRooms(int x, int y)
        {
            var inactiveRooms = _dbContext.Rooms
            .Where(r => r.IsRoomActive == false)
            .ToList();

            inactiveRooms
            .ForEach(r =>
            {
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"# {r.RoomID}, {r.RoomType}, {r.RoomSize}m²");
            });
        }
        public void DisplaySingleRoom(int roomId, int x, int y)
        {
            var selectedRoom = _dbContext.Rooms
            .First(r => r.RoomID == roomId);

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
            Console.WriteLine($"#{selectedRoom.RoomID}");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine($"Type: {selectedRoom.RoomType}");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine($"Size: {selectedRoom.RoomSize}m²");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine($"Max number of extra beds: {selectedRoom.AdditionalBeddingNumber}");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine($"Room active: {roomStatus}");
        }
        public int CountAllRooms()
        {
            return _dbContext.Rooms.Count();
        }

        public void UpdateRoomDetails(int roomIdInput, Room updatedRoomDetails)
        {
            var roomToUpdate = _dbContext.Rooms
                .Find(r => r.RoomID == roomIdInput);

            roomToUpdate.RoomID = updatedRoomDetails.RoomID;
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
        }

        public void RemoveRoom(int roomToDelete)
        {
            var room = _dbContext.Rooms
                .Find(r => r.RoomID == roomToDelete);

            if (room != null)
            {
                room.IsRoomActive = false;
            }
            else
            {
                Console.WriteLine("No room found with that ID.");
            }
        }
        public void ReActivateRoom(int roomToReactivate)
        {
            _dbContext.Rooms
                .First(g => g.RoomID == roomToReactivate)
                .IsRoomActive = true;
        }
    }
}