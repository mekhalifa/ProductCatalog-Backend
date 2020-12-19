using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.Persistence.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "LastUpdated", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 17, 17, 21, 4, 922, DateTimeKind.Local).AddTicks(9337), "Product 1", "", 10.0 },
                    { 2, new DateTime(2020, 12, 16, 17, 21, 4, 923, DateTimeKind.Local).AddTicks(6685), "Product 2", "", 20.0 },
                    { 3, new DateTime(2020, 12, 15, 17, 21, 4, 923, DateTimeKind.Local).AddTicks(6757), "Product 3", "", 30.0 },
                    { 4, new DateTime(2020, 12, 15, 17, 21, 4, 923, DateTimeKind.Local).AddTicks(6761), "Product 4", "", 40.0 },
                    { 5, new DateTime(2020, 12, 14, 17, 21, 4, 923, DateTimeKind.Local).AddTicks(6762), "Product 5", "", 50.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
