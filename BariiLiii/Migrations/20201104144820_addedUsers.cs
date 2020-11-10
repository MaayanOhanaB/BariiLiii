using Microsoft.EntityFrameworkCore.Migrations;

namespace BariiLiii.Migrations
{
    public partial class addedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DId",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DId",
                table: "Appointments");
        }
    }
}
