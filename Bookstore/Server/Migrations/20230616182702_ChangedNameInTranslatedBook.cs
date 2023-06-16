using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class ChangedNameInTranslatedBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Language_LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "TranslatedBooks",
                newName: "TranslatedLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedBooks_LanguageId",
                table: "TranslatedBooks",
                newName: "IX_TranslatedBooks_TranslatedLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Language_TranslatedLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Language_TranslatedLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.RenameColumn(
                name: "TranslatedLanguageId",
                table: "TranslatedBooks",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedBooks_TranslatedLanguageId",
                table: "TranslatedBooks",
                newName: "IX_TranslatedBooks_LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Language_LanguageId",
                table: "TranslatedBooks",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
