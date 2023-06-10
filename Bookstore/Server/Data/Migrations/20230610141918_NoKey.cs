using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Data.Migrations
{
    public partial class NoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsPersonId",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "People");

            migrationBuilder.AddColumn<int>(
                name: "TranslatorPersonId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TranslatorPersonId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_TranslatorPersonId",
                table: "Languages",
                column: "TranslatorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TranslatorPersonId",
                table: "Books",
                column: "TranslatorPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_People_AuthorsPersonId",
                table: "AuthorBook",
                column: "AuthorsPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_People_TranslatorPersonId",
                table: "Books",
                column: "TranslatorPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_People_TranslatorPersonId",
                table: "Languages",
                column: "TranslatorPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_People_AuthorsPersonId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_People_TranslatorPersonId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_People_TranslatorPersonId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_TranslatorPersonId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Books_TranslatorPersonId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TranslatorPersonId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "TranslatorPersonId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsPersonId",
                table: "AuthorBook",
                column: "AuthorsPersonId",
                principalTable: "Authors",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
