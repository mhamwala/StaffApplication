using Microsoft.EntityFrameworkCore.Migrations;

namespace ThreeAmigosStaff.Migrations.MvcPurchase
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Date = table.Column<int>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    SortCode = table.Column<int>(nullable: false),
                    SecurityNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
