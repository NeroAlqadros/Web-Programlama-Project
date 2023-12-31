using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuBilet.Migrations
{
    public partial class Flight5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_FlightId",
                table: "Seat");

            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "Seat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "Seat",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "SeatNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightId",
                table: "Seat",
                column: "FlightId");
        }
    }
}
