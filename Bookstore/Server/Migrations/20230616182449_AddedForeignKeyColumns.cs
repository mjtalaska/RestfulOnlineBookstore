using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class AddedForeignKeyColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsTasks_Books_ComicBookId",
                table: "ArtistsTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsTasks_People_ArtistPersonId",
                table: "ArtistsTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Language_OriginalLanguageLanguageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Status_StatusId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Language_TranslatedLanguageLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_People_TranslatorPersonId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedBooks_TranslatedLanguageLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedBooks_TranslatorPersonId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_Books_OriginalLanguageLanguageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_ArtistsTasks_ArtistPersonId",
                table: "ArtistsTasks");

            migrationBuilder.DropIndex(
                name: "IX_ArtistsTasks_ComicBookId",
                table: "ArtistsTasks");

            migrationBuilder.DropColumn(
                name: "TranslatedLanguageLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropColumn(
                name: "TranslatorPersonId",
                table: "TranslatedBooks");

            migrationBuilder.DropColumn(
                name: "OriginalLanguageLanguageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ArtistPersonId",
                table: "ArtistsTasks");

            migrationBuilder.DropColumn(
                name: "ComicBookId",
                table: "ArtistsTasks");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranslatorId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BooksInSeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookInSeriesId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranslatedBookId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ArtistsTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "ArtistsTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Fantasy" },
                    { 3, "Thriller" },
                    { 4, "Detective" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageId", "Name" },
                values: new object[] { 1, "English" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedBooks_LanguageId",
                table: "TranslatedBooks",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedBooks_TranslatorId",
                table: "TranslatedBooks",
                column: "TranslatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTasks_ArtistId",
                table: "ArtistsTasks",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTasks_BookId",
                table: "ArtistsTasks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsTasks_Books_BookId",
                table: "ArtistsTasks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsTasks_People_ArtistId",
                table: "ArtistsTasks",
                column: "ArtistId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Status_StatusId",
                table: "Books",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Language_LanguageId",
                table: "TranslatedBooks",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_People_TranslatorId",
                table: "TranslatedBooks",
                column: "TranslatorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsTasks_Books_BookId",
                table: "ArtistsTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsTasks_People_ArtistId",
                table: "ArtistsTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Status_StatusId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Language_LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_People_TranslatorId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedBooks_LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedBooks_TranslatorId",
                table: "TranslatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_ArtistsTasks_ArtistId",
                table: "ArtistsTasks");

            migrationBuilder.DropIndex(
                name: "IX_ArtistsTasks_BookId",
                table: "ArtistsTasks");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "TranslatedBooks");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "TranslatedBooks");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BooksInSeries");

            migrationBuilder.DropColumn(
                name: "BookInSeriesId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TranslatedBookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ArtistsTasks");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ArtistsTasks");

            migrationBuilder.AddColumn<int>(
                name: "TranslatedLanguageLanguageId",
                table: "TranslatedBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TranslatorPersonId",
                table: "TranslatedBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OriginalLanguageLanguageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistPersonId",
                table: "ArtistsTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComicBookId",
                table: "ArtistsTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedBooks_TranslatedLanguageLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedBooks_TranslatorPersonId",
                table: "TranslatedBooks",
                column: "TranslatorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_OriginalLanguageLanguageId",
                table: "Books",
                column: "OriginalLanguageLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTasks_ArtistPersonId",
                table: "ArtistsTasks",
                column: "ArtistPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTasks_ComicBookId",
                table: "ArtistsTasks",
                column: "ComicBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsTasks_Books_ComicBookId",
                table: "ArtistsTasks",
                column: "ComicBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsTasks_People_ArtistPersonId",
                table: "ArtistsTasks",
                column: "ArtistPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Language_OriginalLanguageLanguageId",
                table: "Books",
                column: "OriginalLanguageLanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Status_StatusId",
                table: "Books",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Language_TranslatedLanguageLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageLanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_People_TranslatorPersonId",
                table: "TranslatedBooks",
                column: "TranslatorPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
