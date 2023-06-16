using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class AddedMoreConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTechnique_Technique_KnownTechniquesTechniqueId",
                table: "ArtistTechnique");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBookType_BookType_TypeBookTypeId",
                table: "BookBookType");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageTranslator_Language_KnownLanguagesLanguageId",
                table: "LanguageTranslator");

            migrationBuilder.DropForeignKey(
                name: "FK_Technique_ArtistsTasks_ArtistsTaskId",
                table: "Technique");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Language_TranslatedLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technique",
                table: "Technique");

            migrationBuilder.DropIndex(
                name: "IX_Technique_ArtistsTaskId",
                table: "Technique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookType",
                table: "BookType");

            migrationBuilder.DropColumn(
                name: "ArtistsTaskId",
                table: "Technique");

            migrationBuilder.RenameTable(
                name: "Technique",
                newName: "Techniques");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "BookType",
                newName: "BookTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Techniques",
                table: "Techniques",
                column: "TechniqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTypes",
                table: "BookTypes",
                column: "BookTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsTaskTechnique_TechniquesTechniqueId",
                table: "ArtistsTaskTechnique",
                column: "TechniquesTechniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTechnique_Techniques_KnownTechniquesTechniqueId",
                table: "ArtistTechnique",
                column: "KnownTechniquesTechniqueId",
                principalTable: "Techniques",
                principalColumn: "TechniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBookType_BookTypes_TypeBookTypeId",
                table: "BookBookType",
                column: "TypeBookTypeId",
                principalTable: "BookTypes",
                principalColumn: "BookTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageTranslator_Languages_KnownLanguagesLanguageId",
                table: "LanguageTranslator",
                column: "KnownLanguagesLanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Languages_TranslatedLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTechnique_Techniques_KnownTechniquesTechniqueId",
                table: "ArtistTechnique");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBookType_BookTypes_TypeBookTypeId",
                table: "BookBookType");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageTranslator_Languages_KnownLanguagesLanguageId",
                table: "LanguageTranslator");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedBooks_Languages_TranslatedLanguageId",
                table: "TranslatedBooks");

            migrationBuilder.DropTable(
                name: "ArtistsTaskTechnique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Techniques",
                table: "Techniques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTypes",
                table: "BookTypes");

            migrationBuilder.RenameTable(
                name: "Techniques",
                newName: "Technique");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "BookTypes",
                newName: "BookType");

            migrationBuilder.AddColumn<int>(
                name: "ArtistsTaskId",
                table: "Technique",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technique",
                table: "Technique",
                column: "TechniqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookType",
                table: "BookType",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Technique_ArtistsTaskId",
                table: "Technique",
                column: "ArtistsTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTechnique_Technique_KnownTechniquesTechniqueId",
                table: "ArtistTechnique",
                column: "KnownTechniquesTechniqueId",
                principalTable: "Technique",
                principalColumn: "TechniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBookType_BookType_TypeBookTypeId",
                table: "BookBookType",
                column: "TypeBookTypeId",
                principalTable: "BookType",
                principalColumn: "BookTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageTranslator_Language_KnownLanguagesLanguageId",
                table: "LanguageTranslator",
                column: "KnownLanguagesLanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technique_ArtistsTasks_ArtistsTaskId",
                table: "Technique",
                column: "ArtistsTaskId",
                principalTable: "ArtistsTasks",
                principalColumn: "ArtistsTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedBooks_Language_TranslatedLanguageId",
                table: "TranslatedBooks",
                column: "TranslatedLanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
