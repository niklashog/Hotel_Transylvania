using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Transylvania.Migrations
{
    /// <inheritdoc />
    public partial class ReservationGuestIDrenamedtoReservationGuestId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuestID",
                table: "Reservations",
                newName: "GuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "Reservations",
                newName: "GuestID");
        }
    }
}
