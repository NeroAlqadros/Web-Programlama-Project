using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuBilet.Migrations
{
    public partial class Flights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightNumber);
                });

           

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatNumber);
                    table.ForeignKey(
                        name: "FK_Seat_Flight_FlightNumber",
                        column: x => x.FlightNumber,
                        principalTable: "Flight",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketNumber);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightNumber",
                        column: x => x.FlightNumber,
                        principalTable: "Flight",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightNumber",
                table: "Seat",
                column: "FlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightNumber",
                table: "Ticket",
                column: "FlightNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");


            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
