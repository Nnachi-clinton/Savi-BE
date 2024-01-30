using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Savi.Data.Migrations
{
    public partial class Another : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutoSave",
                table: "Savings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GoalUrl",
                table: "Savings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoSave",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "GoalUrl",
                table: "Savings");
        }
    }
}
