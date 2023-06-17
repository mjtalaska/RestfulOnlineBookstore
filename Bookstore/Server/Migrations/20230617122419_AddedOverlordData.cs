using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Server.Migrations
{
    public partial class AddedOverlordData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AdvisedAge", "Amount", "Cover", "LanguageId", "Price", "PublisherId", "StatusId", "Title", "Year" },
                values: new object[] { 3, null, 2, "https://cdn.kobo.com/book-images/21843689-7801-4896-96a7-426d24b8b92a/1200/1200/False/overlord-vol-1-light-novel-2.jpg", 1, 32.99m, 2, 1, "The Undead King", 2016 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AdvisedAge", "Amount", "Cover", "LanguageId", "Price", "PublisherId", "StatusId", "Title", "Year" },
                values: new object[] { 4, null, 4, "https://m.media-amazon.com/images/I/51Yf2uZB3tL.jpg", 1, 32.99m, 2, 1, "The Dark Worrior", 2017 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AdvisedAge", "Amount", "Cover", "LanguageId", "Price", "PublisherId", "StatusId", "Title", "Year" },
                values: new object[] { 5, null, 1, "https://m.media-amazon.com/images/I/414xg51k78L._AC_UF1000,1000_QL80_.jpg", 1, 32.99m, 2, 1, "The Bloody Valkyrie", 2018 });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorBookId", "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookGenreId", "BookId", "GenreId" },
                values: new object[,]
                {
                    { 3, 3, 2 },
                    { 4, 3, 5 },
                    { 5, 4, 2 },
                    { 6, 4, 5 },
                    { 7, 5, 2 },
                    { 8, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "BooksInSeries",
                columns: new[] { "BookInSeriesId", "BookId", "Number", "SeriesId" },
                values: new object[,]
                {
                    { 1, 3, 1, 1 },
                    { 2, 4, 2, 1 },
                    { 3, 5, 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "AuthorBookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "AuthorBookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "AuthorBookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "BookGenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "BookGenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "BookGenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "BookGenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "BookGenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "BookGenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BooksInSeries",
                keyColumn: "BookInSeriesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BooksInSeries",
                keyColumn: "BookInSeriesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BooksInSeries",
                keyColumn: "BookInSeriesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);
        }
    }
}
