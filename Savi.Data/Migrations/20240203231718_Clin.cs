using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Savi.Data.Migrations
{
    public partial class Clin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualStartDate",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedEndDate",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedStartDate",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GroupStatus",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberCount",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextRunTime",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PurposeAndGoal",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RunTime",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SafePortraitImageURL",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaveName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndCondition",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualStartDate",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ExpectedEndDate",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ExpectedStartDate",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupStatus",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "MemberCount",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "NextRunTime",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PurposeAndGoal",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RunTime",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SafePortraitImageURL",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SaveName",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TermsAndCondition",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Groups",
                newName: "Name");
        }
    }
}
