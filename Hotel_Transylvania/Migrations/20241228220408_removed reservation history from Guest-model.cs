using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Transylvania.Migrations
{
    /// <inheritdoc />
    public partial class removedreservationhistoryfromGuestmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationHistory",
                table: "Guests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationHistory",
                table: "Guests",
                type: "int",
                nullable: true);
        }
    }
}
