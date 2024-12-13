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
                newRoom.HasAdditionalBedding = true;
                newRoom.AdditionalBeddingNumber = 1;
                Console.WriteLine("If requested by guest," +
                    "room can accomodate 1 additonal bed.");
            }
            else
            {
                newRoom.HasAdditionalBedding = true;
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
        public void DisplayActiveRooms(int x, int y)
        {
            var activeRooms= _dbContext.Rooms
                .Where(r => r.IsRoomActive)
                .ToList();

            activeRooms
                .ForEach(r =>
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"Room number #{r.RoomID}, {r.RoomType}");
                });
        }
        public void DisplayInactiveRooms(int x, int y)
        {
            var inactiveRooms = _dbContext.Rooms
            .Where(r => r.IsRoomActive == false)
            .ToList();

            inactiveRooms
            .ForEach(r =>
            {
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"Room number #{r.RoomID}, {r.RoomType}");
            });
        }
        public void DisplaySingleActiveRoom(int roomId, int x, int y)
        {
            var selectedRoom = _dbContext.Rooms
            .First(r => r.IsRoomActive == true && r.RoomID == roomId);


            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Room:\t\t#{selectedRoom.RoomID}");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine($"Room Type:\t{selectedRoom.RoomType}");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine($"Additional beds available:\t{selectedRoom.HasAdditionalBedding}");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine($"Maximum number of additional beds:\t\t{selectedRoom.AdditionalBeddingNumber}");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine($"Room active status:\t{selectedRoom.IsRoomActive}");
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

            if (roomToUpdate.RoomSize <= 14 || roomToUpdate.RoomType == "Single")
            {
                Console.WriteLine("Important note. Per guest security reasons," +
                    "this room is too small to accomodate extra beds.");
                roomToUpdate.HasAdditionalBedding = false;
                roomToUpdate.AdditionalBeddingNumber = 0;
            }
            else if (roomToUpdate.RoomSize >= 15 && roomToUpdate.RoomSize <= 19)
            {
                Console.WriteLine("If requested by guest," +
                    "room can accomodate 1 additonal bed.");

                roomToUpdate.HasAdditionalBedding = true;
                roomToUpdate.AdditionalBeddingNumber = 1;
            }
            else
            {
                Console.WriteLine("If requested by guest," +
                    "room can accomodate 2 additonal beds.");

                roomToUpdate.HasAdditionalBedding = true;
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