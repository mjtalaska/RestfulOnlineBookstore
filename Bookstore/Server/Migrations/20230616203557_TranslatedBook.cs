using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class TranslatedBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Languages_TranslatedLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedBooks_TranslatedLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedBooks_LanguageId",
                table: "TranslatedBooks",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Languages_LanguageId",
                table: "TranslatedBooks",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Languages_LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedBooks_LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedBooks_TranslatedLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Languages_TranslatedLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
