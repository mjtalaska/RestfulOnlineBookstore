using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class TranslatedBookFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_TranslatedBooks_BookId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslatedBooks",
                table: "TranslatedBooks");

            migrationBuilder.DropColumn(
                name: "TranslatedId",
                table: "TranslatedBooks");

            migrationBuilder.RenameColumn(
                name: "TranslatedLanguageId",
                table: "TranslatedBooks",
                newName: "TranslatedBookId");

            migrationBuilder.AlterColumn<int>(
                name: "TranslatedBookId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslatedBooks",
                table: "TranslatedBooks",
                column: "TranslatedBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_TranslatedBooks_BookId",
                table: "Books",
                column: "BookId",
                principalTable: "TranslatedBooks",
                principalColumn: "TranslatedBookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_TranslatedBooks_BookId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslatedBooks",
                table: "TranslatedBooks");

            migrationBuilder.RenameColumn(
                name: "TranslatedBookId",
                table: "TranslatedBooks",
                newName: "TranslatedLanguageId");

            migrationBuilder.AlterColumn<int>(
                name: "TranslatedLanguageId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TranslatedId",
                table: "TranslatedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslatedBooks",
                table: "TranslatedBooks",
                column: "TranslatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_TranslatedBooks_BookId",
                table: "Books",
                column: "BookId",
                principalTable: "TranslatedBooks",
                principalColumn: "TranslatedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
