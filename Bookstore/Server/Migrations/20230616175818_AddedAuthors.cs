using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class AddedAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "DateOfBirht", "Discriminator", "Name", "Pseudonym", "Surname" },
                values: new object[] { 1, new DateTime(1945, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Author", "Stephen", null, "King" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "DateOfBirht", "Discriminator", "Name", "Pseudonym", "Surname" },
                values: new object[] { 2, new DateTime(1990, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Author", "Maruyama", null, "Kagune" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);
        }
    }
}
