using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Savi.Data.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTransactions_AspNetUsers_AppUserId",
                table: "GroupTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTransactions_Groups_GroupId",
                table: "GroupTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTransactions",
                table: "GroupTransactions");

            migrationBuilder.RenameTable(
                name: "GroupTransactions",
                newName: "GroupsTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTransactions_GroupId",
                table: "GroupsTransaction",
                newName: "IX_GroupsTransaction_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTransactions_AppUserId",
                table: "GroupsTransaction",
                newName: "IX_GroupsTransaction_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpires",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupsTransaction",
                table: "GroupsTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsTransaction_AspNetUsers_AppUserId",
                table: "GroupsTransaction",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsTransaction_Groups_GroupId",
                table: "GroupsTransaction",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsTransaction_AspNetUsers_AppUserId",
                table: "GroupsTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupsTransaction_Groups_GroupId",
                table: "GroupsTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupsTransaction",
                table: "GroupsTransaction");

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpires",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "GroupsTransaction",
                newName: "GroupTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_GroupsTransaction_GroupId",
                table: "GroupTransactions",
                newName: "IX_GroupTransactions_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupsTransaction_AppUserId",
                table: "GroupTransactions",
                newName: "IX_GroupTransactions_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTransactions",
                table: "GroupTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTransactions_AspNetUsers_AppUserId",
                table: "GroupTransactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTransactions_Groups_GroupId",
                table: "GroupTransactions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
