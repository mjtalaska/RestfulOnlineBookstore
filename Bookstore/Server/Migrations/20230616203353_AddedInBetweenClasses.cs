using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class AddedInBetweenClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistsTaskTechnique");

            migrationBuilder.DropTable(
                name: "ArtistTechnique");

            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookBookType");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "LanguageTranslator");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArtistsTaskTechniques",
                columns: table => new
                {
                    ArtistTechnique = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistTaskId = table.Column<int>(type: "int", nullable: false),
                    TechniqueId = table.Column<int>(type: "int", nullable: false),
                    ArtistsTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistsTaskTechniques", x => x.ArtistTechnique);
                    table.ForeignKey(
                        name: "FK_ArtistsTaskTechniques_ArtistsTasks_ArtistsTaskId",
                        column: x => x.ArtistsTaskId,
                        principalTable: "ArtistsTasks",
                        principalColumn: "ArtistsTaskId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistsTaskTechniques_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "TechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTechniques",
                columns: table => new
                {
                    ArtistTechniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    TechniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTechniques", x => x.ArtistTechniqueId);
                    table.ForeignKey(
                        name: "FK_ArtistTechniques_People_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistTechniques_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "TechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => x.AuthorBookId);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_People_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBookTypes",
                columns: table => new
                {
                    BookBookTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookTypes", x => x.BookBookTypeId);
                    table.ForeignKey(
                        name: "FK_BookBookTypes_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookTypes_BookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "BookTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BookGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => x.BookGenreId);
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslatorLanguages",
                columns: table => new
                {
                    TranslatorLanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranslatorId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatorLanguages", x => x.TranslatorLanguageId);
                    table.ForeignKey(
                        name: "FK_TranslatorLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslatorLanguages_People_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTaskTechniques_ArtistsTaskId",
                table: "ArtistsTaskTechniques",
                column: "ArtistsTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTaskTechniques_TechniqueId",
                table: "ArtistsTaskTechniques",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTechniques_ArtistId",
                table: "ArtistTechniques",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTechniques_TechniqueId",
                table: "ArtistTechniques",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBookTypes_BookId",
                table: "BookBookTypes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBookTypes_BookTypeId",
                table: "BookBookTypes",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_BookId",
                table: "BookGenres",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatorLanguages_LanguageId",
                table: "TranslatorLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatorLanguages_TranslatorId",
                table: "TranslatorLanguages",
                column: "TranslatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistsTaskTechniques");

            migrationBuilder.DropTable(
                name: "ArtistTechniques");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "BookBookTypes");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "TranslatorLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TranslatedBooks");

            migrationBuilder.CreateTable(
                name: "ArtistsTaskTechnique",
                columns: table => new
                {
                    ArtistsTasksArtistsTaskId = table.Column<int>(type: "int", nullable: false),
                    TechniquesTechniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistsTaskTechnique", x => new { x.ArtistsTasksArtistsTaskId, x.TechniquesTechniqueId });
                    table.ForeignKey(
                        name: "FK_ArtistsTaskTechnique_ArtistsTasks_ArtistsTasksArtistsTaskId",
                        column: x => x.ArtistsTasksArtistsTaskId,
                        principalTable: "ArtistsTasks",
                        principalColumn: "ArtistsTaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistsTaskTechnique_Techniques_TechniquesTechniqueId",
                        column: x => x.TechniquesTechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "TechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTechnique",
                columns: table => new
                {
                    ArtistsPersonId = table.Column<int>(type: "int", nullable: false),
                    KnownTechniquesTechniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTechnique", x => new { x.ArtistsPersonId, x.KnownTechniquesTechniqueId });
                    table.ForeignKey(
                        name: "FK_ArtistTechnique_People_ArtistsPersonId",
                        column: x => x.ArtistsPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistTechnique_Techniques_KnownTechniquesTechniqueId",
                        column: x => x.KnownTechniquesTechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "TechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsPersonId = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsPersonId, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_People_AuthorsPersonId",
                        column: x => x.AuthorsPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBookType",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    TypeBookTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookType", x => new { x.BooksBookId, x.TypeBookTypeId });
                    table.ForeignKey(
                        name: "FK_BookBookType_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookType_BookTypes_TypeBookTypeId",
                        column: x => x.TypeBookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "BookTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    GenresGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksBookId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTranslator",
                columns: table => new
                {
                    KnownLanguagesLanguageId = table.Column<int>(type: "int", nullable: false),
                    TranslatorsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTranslator", x => new { x.KnownLanguagesLanguageId, x.TranslatorsPersonId });
                    table.ForeignKey(
                        name: "FK_LanguageTranslator_Languages_KnownLanguagesLanguageId",
                        column: x => x.KnownLanguagesLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageTranslator_People_TranslatorsPersonId",
                        column: x => x.TranslatorsPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTaskTechnique_TechniquesTechniqueId",
                table: "ArtistsTaskTechnique",
                column: "TechniquesTechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTechnique_KnownTechniquesTechniqueId",
                table: "ArtistTechnique",
                column: "KnownTechniquesTechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookId",
                table: "AuthorBook",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBookType_TypeBookTypeId",
                table: "BookBookType",
                column: "TypeBookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresGenreId",
                table: "BookGenre",
                column: "GenresGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTranslator_TranslatorsPersonId",
                table: "LanguageTranslator",
                column: "TranslatorsPersonId");
        }
    }
}
