using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreEfCore.Migrations
{
    public partial class inittttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "SystemUser");
        }
    }
}
