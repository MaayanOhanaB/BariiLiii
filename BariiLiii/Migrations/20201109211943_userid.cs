using Microsoft.EntityFrameworkCore.Migrations;

namespace BariiLiii.Migrations
{
    public partial class userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Appointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_userId",
                table: "Appointments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_userId",
                table: "Appointments",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_userId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_userId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Appointments");
        }
    }
}
