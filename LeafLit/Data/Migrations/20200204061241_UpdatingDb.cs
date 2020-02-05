using Microsoft.EntityFrameworkCore.Migrations;

namespace LeafLit.Data.Migrations
{
    public partial class UpdatingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "ISBN_10",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN_13",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserBookRatings",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookRatings", x => new { x.UserID, x.BookID });
                    table.ForeignKey(
                        name: "FK_UserBookRatings_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookRatings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBookRatings_BookID",
                table: "UserBookRatings",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBookRatings");

            migrationBuilder.DropColumn(
                name: "ISBN_10",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ISBN_13",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
