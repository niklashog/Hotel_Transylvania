using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace Hotel_Transylvania.Services
{
    public class RoomService : IRoomService
    {
        public void AddRoom(
            Room room,
            ApplicationDbContext dbContext)
        {
            var newRoom = room;

            if (newRoom.RoomSize <= 14 || newRoom.RoomType == "Single")
            {
                newRoom.AdditionalBeddingNumber = 0;
                AnsiConsole.MarkupLine("[bold red]Important note.[/] " +
                    "Per guest security reasons," +
                    "this room cannot accomodate any extra beds.");
            }
            else if (newRoom.RoomSize >= 15 && newRoom.RoomSize <= 19 && (newRoom.RoomType == "Double" || newRoom.RoomType == "Suite"))
            {
                newRoom.AdditionalBeddingNumber = 1;
                AnsiConsole.MarkupLine("If requested by guest," +
                        "room can accomodate [yellow]1[/] additonal bed.");
            }
            else if (newRoom.RoomSize >= 20 && (newRoom.RoomType == "Double" || newRoom.RoomType == "Suite"))
            {
                newRoom.AdditionalBeddingNumber = 2;
                AnsiConsole.MarkupLine("\nIf requested by guest, " +
                        "room can accomodate up to [yellow]2[/] additional beds.");
            }

            dbContext.Rooms.Add(room);
            dbContext.SaveChanges();
        }

        public IEnumerable<Room> GetAllRooms(
            ApplicationDbContext dbContext)
        {
            return dbContext.Rooms;
        }
        public void DisplayAllRooms(
            ApplicationDbContext dbContext)
        {
            var allRooms = dbContext.Rooms
                .ToList();
            if (allRooms.Count == 0)
            {
                AnsiConsole.MarkupLine($"[bold red]No rooms in the system.[/]\n" +
                    $"Press any key to go back.");
                return;
            }
            else
            {
                var table = new Table();
                table.Border = TableBorder.Simple;

                table.AddColumn("Room Number");
                table.AddColumn("Room Type");
                table.AddColumn("Room Size");
                table.AddColumn("Additional bedding");

                foreach (var room in allRooms)
                {
                    table.AddRow(
                        room.RoomNumber.ToString(),
                        room.RoomType.ToString(),
                        $"{room.RoomSize}m²",
                        $"{room.AdditionalBeddingNumber}"
                    );
                }

                AnsiConsole.MarkupLine("[yellow]All Rooms[/]");
                AnsiConsole.Write(table);
            }
        }
        public void DisplayActiveRooms(
            ApplicationDbContext dbContext)
        {
            var activeRooms = dbContext.Rooms
                .Where(r => r.IsRoomActive)
                .ToList();
            if (activeRooms.Count == 0)
            {
                AnsiConsole.MarkupLine($"[bold red]No active rooms in the system.[/]\n" +
                    $"Press any key to go back.");
                return;
            }
            else
            {
                var table = new Table();
                table.Border = TableBorder.Simple;

                table.AddColumn("Room Number");
                table.AddColumn("Room Type");
                table.AddColumn("Room Size");
                table.AddColumn("Additional bedding");

                foreach (var room in activeRooms)
                {
                    table.AddRow(
                        room.RoomNumber.ToString(),
                        room.RoomType.ToString(),
                        $"{room.RoomSize}m²",
                        $"{room.AdditionalBeddingNumber}"
                    );
                }

                AnsiConsole.MarkupLine("[yellow]Active Rooms[/]");
                AnsiConsole.Write(table);
            }
        }
        public void DisplayInactiveRooms(
            ApplicationDbContext dbContext)
        {
            var inactiveRooms = dbContext.Rooms
                .Where(r => r.IsRoomActive == false)
                .ToList();
            if (inactiveRooms.Count == 0)
            {
                AnsiConsole.MarkupLine($"[bold red]No inactive rooms in the system.[/]\n" +
                    $"Press any key to go back.");
                return;
            }
            else
            {
                var table = new Table();
                table.Border = TableBorder.Simple;

                table.AddColumn("Room Number");
                table.AddColumn("Room Type");
                table.AddColumn("Room Size");
                table.AddColumn("Additional bedding");

                foreach (var room in inactiveRooms)
                {
                    table.AddRow(
                        room.RoomNumber.ToString(),
                        room.RoomType.ToString(),
                        $"{room.RoomSize}m²",
                        $"{room.AdditionalBeddingNumber}"
                    );
                }

                AnsiConsole.MarkupLine("[yellow]Inactive Rooms[/]");
                AnsiConsole.Write(table);
            }
        }

        public void DisplaySingleRoom(
            int roomId,
            ApplicationDbContext dbContext)
        {
            var selectedRoom = dbContext.Rooms
                .First(r => r.RoomNumber == roomId);

            var table = new Table();
            table.Border = TableBorder.Simple;

            table.AddColumn("Room Number");
            table.AddColumn("Room Type");
            table.AddColumn("Room Size");
            table.AddColumn("Max number of extra beds");
            table.AddColumn("Room active");

            table.AddRow(
                selectedRoom.RoomNumber.ToString(),
                selectedRoom.RoomType.ToString(),
                $"{selectedRoom.RoomSize}m²",
                selectedRoom.AdditionalBeddingNumber.ToString()
            );

            AnsiConsole.MarkupLine("[yellow]Selected Room[/]");
            AnsiConsole.Write(table);
        }

        public int CountAllRooms(
            ApplicationDbContext dbContext)
        {
            return dbContext.Rooms.Count();
        }

        public void UpdateRoomDetails(
            int roomIdInput,
            Room updatedRoomDetails,
            ApplicationDbContext dbContext)
        {
            var roomToUpdate = dbContext.Rooms
            .First(r => r.RoomNumber == roomIdInput);

            roomToUpdate.RoomNumber = updatedRoomDetails.RoomNumber;
            roomToUpdate.RoomType = updatedRoomDetails.RoomType;
            roomToUpdate.RoomSize = updatedRoomDetails.RoomSize;

            if (roomToUpdate.RoomSize <= 14 || roomToUpdate.RoomType == "Single" && roomToUpdate.RoomSize > 14)
            {
                roomToUpdate.AdditionalBeddingNumber = 0;
                AnsiConsole.MarkupLine("[bold red]Important note.[/] " +
                    "Per guest security reasons," +
                    "this room cannot accomodate any extra beds.");
            }

            else if (roomToUpdate.RoomSize >= 15 && roomToUpdate.RoomSize <= 19 &&
                (roomToUpdate.RoomType == "Double" || roomToUpdate.RoomType == "Suite"))
            {
                roomToUpdate.AdditionalBeddingNumber = 1;
                AnsiConsole.MarkupLine("If requested by guest," +
                        "room can accomodate [yellow]1[/] additonal bed.");
            }
            else if (roomToUpdate.RoomSize >= 20 &&
                (roomToUpdate.RoomType == "Double" ||
                roomToUpdate.RoomType == "Suite"))
            {
                roomToUpdate.AdditionalBeddingNumber = 2;
                AnsiConsole.MarkupLine("\nIf requested by guest, " +
                        "room can accomodate up to [yellow]2[/] additional beds.");
            }
            dbContext.SaveChanges();
        }

        public void RemoveRoom(
            int roomToDelete,
            IEnumerable<Reservation> listOfActiveReservations,
            ApplicationDbContext dbContext)
        {
            var room = dbContext.Rooms
                .Include(r => r.Reservations)
                .Where(r => r.IsRoomActive)
                .FirstOrDefault(r => r.RoomNumber == roomToDelete);

            var hasActiveReservation = listOfActiveReservations
                .Any(r => r.RoomNumber == roomToDelete);

            if (hasActiveReservation)
            {
                AnsiConsole.MarkupLine("[bold red]Cannot delete a room with an active " +
                "reservation.[/] \nRemove reservation first and try again.");
            }
            else
            {
                room.IsRoomActive = false;
                dbContext.SaveChanges();
                AnsiConsole.MarkupLine($"[green]Success! Room is now inactive.[/]");
            }
        }
        public void ReActivateRoom(
            int roomToReactivate,
            ApplicationDbContext dbContext)
        {
            var room = dbContext.Rooms
            .FirstOrDefault(g => g.RoomNumber == roomToReactivate);
            if (room != null)
            {
                room.IsRoomActive = true;
                dbContext.SaveChanges();
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]No room found with that Id.[/]");
            }
        }
        public IEnumerable<string> GetExistingRoomNumbersAsString(
            ApplicationDbContext dbContext)
        {
            var existingRoomNumbers = dbContext.Rooms
                .Select(r => r.RoomNumber.ToString())
                .ToList();

            return existingRoomNumbers;
        }
        public IEnumerable<Room> ListOfActiveRooms(
            ApplicationDbContext dbContext)
        {
            var listOfActiveRooms = dbContext.Rooms
                .Where(g => g.IsRoomActive)
                .ToList();

            return listOfActiveRooms;
        }
        public IEnumerable<Room> ListOfInctiveRooms(
            ApplicationDbContext dbContext)
        {
            var listOfInctiveRooms = dbContext.Rooms
                .Where(g => g.IsRoomActive == false)
                .ToList();

            return listOfInctiveRooms;
        }

    }
}