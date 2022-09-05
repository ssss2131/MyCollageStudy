using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreEfCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountInType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemMenu_SystemMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SystemMenu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsTypeId = table.Column<int>(type: "int", nullable: false),
                    GoodsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountInStore = table.Column<double>(type: "float", nullable: false),
                    OnSeal = table.Column<bool>(type: "bit", nullable: false),
                    CountInSeal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemGoods_GoodsType_GoodsTypeId",
                        column: x => x.GoodsTypeId,
                        principalTable: "GoodsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemOpRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemRoleId = table.Column<int>(type: "int", nullable: false),
                    SystemOperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemOpRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemOpRole_SystemOperation_SystemOperationId",
                        column: x => x.SystemOperationId,
                        principalTable: "SystemOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemOpRole_SystemRole_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "SystemRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUser_SystemRole_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "SystemRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemGoodsRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsHandled = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemGoodsRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemGoodsRecord_SystemGoods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "SystemGoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemGoodsRecord_SystemUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemGoods_GoodsTypeId",
                table: "SystemGoods",
                column: "GoodsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemGoodsRecord_GoodId",
                table: "SystemGoodsRecord",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemGoodsRecord_UserId",
                table: "SystemGoodsRecord",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemMenu_ParentId",
                table: "SystemMenu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemOpRole_SystemOperationId",
                table: "SystemOpRole",
                column: "SystemOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemOpRole_SystemRoleId",
                table: "SystemOpRole",
                column: "SystemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_SysRoleId",
                table: "SystemUser",
                column: "SysRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemGoodsRecord");

            migrationBuilder.DropTable(
                name: "SystemMenu");

            migrationBuilder.DropTable(
                name: "SystemOpRole");

            migrationBuilder.DropTable(
                name: "SystemGoods");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "SystemOperation");

            migrationBuilder.DropTable(
                name: "GoodsType");

            migrationBuilder.DropTable(
                name: "SystemRole");
        }
    }
}
