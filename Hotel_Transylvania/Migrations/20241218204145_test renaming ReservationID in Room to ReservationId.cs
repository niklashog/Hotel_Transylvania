using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Transylvania.Migrations
{
    /// <inheritdoc />
    public partial class testrenamingReservationIDinRoomtoReservationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationID",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Rooms",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationID",
                table: "Rooms",
                newName: "IX_Rooms_ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Rooms",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms",
                newName: "IX_Rooms_ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationID",
                table: "Rooms",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
