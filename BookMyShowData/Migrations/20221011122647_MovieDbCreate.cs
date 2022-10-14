using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowData.Migrations
{
    public partial class MovieDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThreatreId",
                table: "showTimings",
                newName: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "showTimings",
                newName: "ThreatreId");
        }
    }
}
