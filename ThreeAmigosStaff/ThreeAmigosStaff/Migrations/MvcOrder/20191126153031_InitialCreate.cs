using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThreeAmigosStaff.Migrations.MvcOrder
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ShippingAddress = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
