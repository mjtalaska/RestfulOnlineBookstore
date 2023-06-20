using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class MadeOnlyOneCommentPerUserPerBookAllowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.InsertData(
                table: "BookBookTypes",
                columns: new[] { "BookBookTypeId", "BookId", "BookTypeId" },
                values: new object[] { 3, 3, 1 });

            migrationBuilder.InsertData(
                table: "BookBookTypes",
                columns: new[] { "BookBookTypeId", "BookId", "BookTypeId" },
                values: new object[] { 4, 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "BookBookTypes",
                keyColumn: "BookBookTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookBookTypes",
                keyColumn: "BookBookTypeId",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");
        }
    }
}
