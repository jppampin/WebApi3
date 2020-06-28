using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
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
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("9b1df6fe-30d0-4de3-8946-ad55ce6f41ff"), "ARS", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("7b92e37f-f0d4-417d-89d7-3278ede73de3"), "EUR", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("0ddc4a48-60ce-455e-98c9-20b1e4d73ff0"), "USD", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("1ace235f-d628-4c50-bd55-2c97ca1a7382"), "BRL", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Currency", "ItemsIds" },
                values: new object[] { new Guid("f8cea9e3-7fa9-4d4f-b3e9-0173952aa3ad"), "???", "1,2,3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
