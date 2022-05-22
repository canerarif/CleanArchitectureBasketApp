using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketApp.Infrastructure.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCount = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ProductName", "Stock" },
                values: new object[,]
                {
                    { new Guid("5c95c5d4-c887-493d-9589-0efc9f20e67e"), new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8027), "Paper A4", 10 },
                    { new Guid("f27e09f4-7a24-4890-a595-a02827a98aa4"), new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8029), "Book", 100 },
                    { new Guid("fbc178bf-6751-48bb-8df3-5dfbf00194ec"), new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8016), "Pencil", 20 }
                });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "Id", "CreateDate", "ProductCount", "ProductId" },
                values: new object[,]
                {
                    { new Guid("7a4ccfeb-0174-49e1-a3a2-b1a85c982608"), new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8215), 2, new Guid("fbc178bf-6751-48bb-8df3-5dfbf00194ec") },
                    { new Guid("88dda06e-1796-46ac-adc7-ff4cf90a8a01"), new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8296), 7, new Guid("f27e09f4-7a24-4890-a595-a02827a98aa4") },
                    { new Guid("e02167e2-db7e-4919-af3e-d7a8c5d0b594"), new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8292), 4, new Guid("5c95c5d4-c887-493d-9589-0efc9f20e67e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
