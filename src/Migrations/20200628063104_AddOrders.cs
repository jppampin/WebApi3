using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AddOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemsIds = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("05284a3a-ce7b-48ed-b2f8-1db52f4e7db3"), "ARS", "1,2,3" });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("fde167d5-8721-41d0-9503-65bd8f1af67b"), "EUR", "1,2,3" });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("9e99cf8b-ba6f-48ad-87ad-3e2127ffff21"), "USD", "1,2,3" });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("4e7ac029-8816-426c-b689-447d213a7086"), "BRL", "1,2,3" });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("7f55bcef-c616-4e61-b15c-d867021b8699"), "???", "1,2,3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "order");
        }
    }
}
