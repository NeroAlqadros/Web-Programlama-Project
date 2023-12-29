using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuBilet.Migrations
{
    public partial class Flight1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Flight_FlightNumber",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flight_FlightNumber",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "Ticket",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_FlightNumber",
                table: "Ticket",
                newName: "IX_Ticket_FlightId");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "Seat",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_FlightNumber",
                table: "Seat",
                newName: "IX_Seat_FlightId");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "Flight",
                newName: "FlightId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Id",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Flight_FlightId",
                table: "Seat",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_Id",
                table: "Ticket",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flight_FlightId",
                table: "Ticket",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Flight_FlightId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_Id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flight_FlightId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_Id",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Ticket",
                newName: "FlightNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                newName: "IX_Ticket_FlightNumber");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Seat",
                newName: "FlightNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_FlightId",
                table: "Seat",
                newName: "IX_Seat_FlightNumber");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Flight",
                newName: "FlightNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Flight_FlightNumber",
                table: "Seat",
                column: "FlightNumber",
                principalTable: "Flight",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flight_FlightNumber",
                table: "Ticket",
                column: "FlightNumber",
                principalTable: "Flight",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
