using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Savi.Data.Migrations
{
    public partial class AddedExtraproperties2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Savings_AspNetUsers_AppUserId",
                table: "Savings");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Savings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Savings_AppUserId",
                table: "Savings",
                newName: "IX_Savings_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_AspNetUsers_UserId",
                table: "Savings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Savings_AspNetUsers_UserId",
                table: "Savings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Savings",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Savings_UserId",
                table: "Savings",
                newName: "IX_Savings_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_AspNetUsers_AppUserId",
                table: "Savings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
