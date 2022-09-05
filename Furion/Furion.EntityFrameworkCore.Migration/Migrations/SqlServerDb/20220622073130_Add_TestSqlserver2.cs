using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furion.EntityFrameworkCore.MyMigration.Migrations.SqlServerDb
{
    public partial class Add_TestSqlserver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "TestSqlServer",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "TestSqlServer");
        }
    }
}
