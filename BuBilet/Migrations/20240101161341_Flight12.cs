using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuBilet.Migrations
{
    public partial class Flight12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeatId",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Ticket");
        }
    }
}
