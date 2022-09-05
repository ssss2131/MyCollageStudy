using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreEfCore.Migrations
{
    public partial class inittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "SystemUser");
        }
    }
}
