using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowData.Migrations
{
    public partial class MovieDbContesrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_showTimings_showTimingId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "showTimingId",
                table: "bookings",
                newName: "ShowTimingId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_showTimingId",
                table: "bookings",
                newName: "IX_bookings_ShowTimingId");

            migrationBuilder.AlterColumn<int>(
                name: "ShowTimingId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_showTimings_ShowTimingId",
                table: "bookings",
                column: "ShowTimingId",
                principalTable: "showTimings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_showTimings_ShowTimingId",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "ShowTimingId",
                table: "bookings",
                newName: "showTimingId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_ShowTimingId",
                table: "bookings",
                newName: "IX_bookings_showTimingId");

            migrationBuilder.AlterColumn<int>(
                name: "showTimingId",
                table: "bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShowId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_showTimings_showTimingId",
                table: "bookings",
                column: "showTimingId",
                principalTable: "showTimings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
