using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuBilet.Migrations
{
    public partial class Flight17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Flight_FlightId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_FlightId",
                table: "Seat");

            migrationBuilder.AlterColumn<string>(
                name: "FlightId",
                table: "Seat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightId",
                table: "Seat",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightId",
                table: "Seat",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Flight_FlightId",
                table: "Seat",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
