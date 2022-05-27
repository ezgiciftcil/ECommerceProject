using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class IX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishingLists",
                columns: table => new
                {
                    WishingListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishingLists", x => x.WishingListId);
                    table.ForeignKey(
                        name: "FK_WishingLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishingListItems",
                columns: table => new
                {
                    WishingListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishingListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishingListItems", x => x.WishingListItemId);
                    table.ForeignKey(
                        name: "FK_WishingListItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishingListItems_WishingLists_WishingListId",
                        column: x => x.WishingListId,
                        principalTable: "WishingLists",
                        principalColumn: "WishingListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishingListItems_ProductId",
                table: "WishingListItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishingListItems_WishingListId",
                table: "WishingListItems",
                column: "WishingListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishingLists_UserId",
                table: "WishingLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishingListItems");

            migrationBuilder.DropTable(
                name: "WishingLists");
        }
    }
}
