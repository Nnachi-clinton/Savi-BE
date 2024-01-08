using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Savi.Data.Migrations
{
    public partial class AddedExtraproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Savings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NextRuntime",
                table: "Savings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TargetAmount",
                table: "Savings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TargetName",
                table: "Savings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WithdrawalDate",
                table: "Savings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "NextRuntime",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "TargetAmount",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "TargetName",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "WithdrawalDate",
                table: "Savings");
        }
    }
}
