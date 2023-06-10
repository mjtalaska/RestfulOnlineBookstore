using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Data.Migrations
{
    public partial class AddedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_Books_BookId",
                table: "AuthorsBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_People_AuthorPersonId",
                table: "AuthorsBooks");

            migrationBuilder.DropIndex(
                name: "IX_AuthorsBooks_AuthorPersonId",
                table: "AuthorsBooks");

            migrationBuilder.DropColumn(
                name: "AuthorPersonId",
                table: "AuthorsBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "AuthorsBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "AuthorsBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsBooks_AuthorId",
                table: "AuthorsBooks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_Books_BookId",
                table: "AuthorsBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_People_AuthorId",
                table: "AuthorsBooks",
                column: "AuthorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_Books_BookId",
                table: "AuthorsBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_People_AuthorId",
                table: "AuthorsBooks");

            migrationBuilder.DropIndex(
                name: "IX_AuthorsBooks_AuthorId",
                table: "AuthorsBooks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AuthorsBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "AuthorsBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorPersonId",
                table: "AuthorsBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsBooks_AuthorPersonId",
                table: "AuthorsBooks",
                column: "AuthorPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_Books_BookId",
                table: "AuthorsBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_People_AuthorPersonId",
                table: "AuthorsBooks",
                column: "AuthorPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
