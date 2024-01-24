using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Savi.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "Wallets",
                newName: "WalletNumber");

            migrationBuilder.AddColumn<decimal>(
                name: "CumulativeAmount",
                table: "WalletFundings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "WalletNumber",
                table: "WalletFundings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CumulativeAmount",
                table: "WalletFundings");

            migrationBuilder.DropColumn(
                name: "WalletNumber",
                table: "WalletFundings");

            migrationBuilder.RenameColumn(
                name: "WalletNumber",
                table: "Wallets",
                newName: "WalletId");
        }
    }
}
