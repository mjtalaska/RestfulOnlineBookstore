using Bookstore.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Linq;

namespace Bookstore.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistsTask> ArtistsTasks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookInSeries> BooksInSeries { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<TranslatedBook> TranslatedBooks { get; set; }
        public DbSet<Translator> Translators { get; set; }

        public DbSet<BookBookType> BookBookTypes { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<TranslatorLanguage> TranslatorLanguages { get; set; }
        public DbSet<ArtistTechnique> ArtistTechniques { get; set; }
        public DbSet<ArtistsTaskTechnique> ArtistsTaskTechniques { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TranslatedBook>(t =>
            {
                t.HasOne(e => e.Translator).WithMany(e => e.Books);
                t.HasOne(e => e.Language).WithMany(e => e.Translations);
                t.HasOne(e => e.Book).WithOne(e => e.TranslatedBook);
            });

            builder.Entity<Artist>(a =>
            {
                a.HasMany(e => e.KnownTechniques).WithOne(e => e.Artist);
                a.HasMany(e => e.Tasks).WithOne(e => e.Artist);
            });

            builder.Entity<ArtistsTask>(a =>
            {
                a.HasOne(e => e.Artist).WithMany(e => e.Tasks);
                a.HasOne(e => e.Book).WithMany(e => e.ComicArtists);
                a.HasMany(e => e.Techniques).WithOne(e => e.ArtistsTask);
            });

            builder.Entity<Author>(a =>
            {
                a.HasMany(e => e.Books).WithOne(e => e.Author);
            });

            builder.Entity<BookInSeries>(b =>
            {
                b.HasOne(e => e.Series).WithMany(e => e.Books);
                b.HasOne(e => e.Book).WithOne(e => e.BookInSeries);
            });

            builder.Entity<Book>(b =>
            {
                b.HasOne(e => e.Language).WithMany(e => e.Books);
                b.HasOne(e => e.Status).WithMany(e => e.Books);
                b.HasMany(e => e.Authors).WithOne(e => e.Book);
                b.HasMany(e => e.Genres).WithOne(e => e.Book);
                b.HasMany(e => e.ComicArtists).WithOne(e => e.Book);
                b.HasMany(e => e.Type).WithOne(e => e.Book);
                b.HasOne(e => e.Publisher).WithMany(e => e.Books);
                b.HasMany(e => e.Carts).WithOne(e => e.Book);
                b.HasMany(e => e.Purchases).WithOne(e => e.Book);
                b.HasMany(e => e.Comments).WithOne(e => e.Book);
                b.HasOne(e => e.BookInSeries).WithOne(e => e.Book);
                b.Property(e => e.Price).HasColumnType("decimal(5,2)").IsRequired(true);
                b.HasOne(e => e.TranslatedBook).WithOne(e => e.Book);
            });

            builder.Entity<Cart>(c =>
            {
                c.HasOne(e => e.Book).WithMany(e => e.Carts);
                c.HasOne(e => e.User).WithMany(e => e.InCart);
            });

            builder.Entity<Comment>(c =>
            {
                c.HasOne(e => e.Book).WithMany(e => e.Comments);
                c.HasOne(e => e.User).WithMany(e => e.Comments);
            });

            builder.Entity<Genre>(g =>
            {
                g.HasMany(e => e.Books).WithOne(e => e.Genre);
            });

            builder.Entity<Status>(s =>
            {
                s.HasMany(e => e.Books).WithOne(e => e.Status);
            });

            builder.Entity<BookType>(b =>
            {
                b.HasMany(e => e.Books).WithOne(e => e.BookType);
            });

            builder.Entity<Language>(l =>
            {
                l.HasMany(e => e.Books).WithOne(e => e.Language);
                l.HasMany(e => e.Translations).WithOne(e => e.Language);
                l.HasMany(e => e.Translators).WithOne(e => e.Language);
            });

            builder.Entity<Technique>(t =>
            {
                t.HasMany(e => e.Artists).WithOne(e => e.Technique);
                t.HasMany(e => e.ArtistsTasks).WithOne(e => e.Technique);
            });

            builder.Entity<Publisher>(p =>
            {
                p.HasMany(e => e.Books).WithOne(e => e.Publisher);
            });

            builder.Entity<Purchase>(p =>
            {
                p.HasOne(e => e.Book).WithMany(e => e.Purchases);
                p.HasOne(e => e.User).WithMany(e => e.Purchases);
            });

            builder.Entity<Series>(s =>
            {
                s.HasMany(e => e.Books).WithOne(e => e.Series);
            });

            builder.Entity<Translator>(t =>
            {
                t.HasMany(e => e.Books).WithOne(e => e.Translator);
                t.HasMany(e => e.KnownLanguages).WithOne(e => e.Translator);
            });

            builder.Entity<ApplicationUser>(u =>
            {
                u.HasMany(e => e.Comments).WithOne(e => e.User);
                u.HasMany(e => e.Purchases).WithOne(e => e.User);
                u.HasMany(e => e.InCart).WithOne(e => e.User);
            });

            builder.Entity<BookBookType>(b =>
            {
                b.HasOne(e => e.Book).WithMany(e => e.Type);
                b.HasOne(e => e.BookType).WithMany(e => e.Books);
            });

            builder.Entity<BookGenre>(b =>
            {
                b.HasOne(e => e.Book).WithMany(e => e.Genres);
                b.HasOne(e => e.Genre).WithMany(e => e.Books);
            });

            builder.Entity<TranslatorLanguage>(t =>
            {
                t.HasOne(e => e.Translator).WithMany(e => e.KnownLanguages);
                t.HasOne(e => e.Language).WithMany(e => e.Translators);
            });

            builder.Entity<ArtistTechnique>(a =>
            {
                a.HasOne(e => e.Artist).WithMany(e => e.KnownTechniques);
                a.HasOne(e => e.Technique).WithMany(e => e.Artists);
            });

            builder.Entity<ArtistsTaskTechnique>(a =>
            {
                a.HasOne(e => e.ArtistsTask).WithMany(e => e.Techniques);
                a.HasOne(e => e.Technique).WithMany(e => e.ArtistsTasks);
            });

            builder.Entity<AuthorBook>(a =>
            {
                a.HasOne(e => e.Author).WithMany(e => e.Books);
                a.HasOne(e => e.Book).WithMany(e => e.Authors);
            });

            Publisher p1 = new Publisher { PublisherId = 1, Name = "Hachette Collections", WebAddress = "https://www.hachette-collections.com/fr-fr/" };
            Publisher p2 = new Publisher { PublisherId = 2, Name = "Little, Brown & Company", WebAddress = "https://www.hachettebookgroup.com/imprint/little-brown-and-company/" };
            builder.Entity<Publisher>().HasData(p1, p2);

            Author a1 = new Author { PersonId = 1, Name = "Stephen", Surname = "King", DateOfBirht = DateTime.Parse("1945-10-12")};
            Author a2 = new Author { PersonId = 2, Name = "Maruyama", Surname = "Kagune", DateOfBirht = DateTime.Parse("1990-03-30") };
            builder.Entity<Author>().HasData(a1, a2);

            Language l1 = new Language { LanguageId = 1, Name = "English" };
            builder.Entity<Language>().HasData(l1);

            Genre g1 = new Genre { GenreId = 1, Name = "Horror" };
            Genre g2 = new Genre { GenreId = 2, Name = "Fantasy" };
            Genre g3 = new Genre { GenreId = 3, Name = "Thriller" };
            Genre g4 = new Genre { GenreId = 4, Name = "Detective" };
            Genre g5 = new Genre { GenreId = 5, Name = "Science Fiction" };
            builder.Entity<Genre>().HasData(g1, g2, g3, g4, g5);

            BookType bt = new BookType { BookTypeId = 1, Name = "Book" };
            builder.Entity<BookType>().HasData(bt);

            Status st1 = new Status { StatusId = 1, Name = "Available" };
            Status st2 = new Status { StatusId = 2, Name = "Unavailable" };

            builder.Entity<Status>().HasData(st1, st2);

            Series s = new Series { SeriesId = 1, Name = "Overlord" };
            builder.Entity<Series>().HasData(s);

            Book b1 = new Book
            {
                BookId = 1,
                Title = "IT",
                Year = 2002,
                Amount = 120,
                Price = 25.99M,
                Cover = "https://m.media-amazon.com/images/I/712+f2W4uoL._AC_UF1000,1000_QL80_.jpg",
                PublisherId = 1,
                StatusId = 1,
                LanguageId = 1
            };
            Book b2 = new Book
            {
                BookId = 2,
                Title = "Carrie",
                Year = 1998,
                Amount = 125,
                Price = 24.99M,
                Cover = "https://cdn.kobo.com/book-images/36c33e57-6f48-43f5-ba3a-0d60d82e4308/353/569/90/False/carrie-2.jpg",
                PublisherId = 1,
                StatusId = 1,
                LanguageId = 1
            };
            Book b3 = new Book
            {
                BookId = 3,
                Title = "The Undead King",
                Year = 2016,
                Amount = 2,
                Price = 32.99M,
                Cover = "https://cdn.kobo.com/book-images/21843689-7801-4896-96a7-426d24b8b92a/1200/1200/False/overlord-vol-1-light-novel-2.jpg",
                PublisherId = 2,
                StatusId = 1,
                LanguageId = 1
            };
            Book b4 = new Book
            {
                BookId = 4,
                Title = "The Dark Worrior",
                Year = 2017,
                Amount = 4,
                Price = 32.99M,
                Cover = "https://m.media-amazon.com/images/I/51Yf2uZB3tL.jpg",
                PublisherId = 2,
                StatusId = 1,
                LanguageId = 1
            };
            Book b5 = new Book
            {
                BookId = 5,
                Title = "The Bloody Valkyrie",
                Year = 2018,
                Amount = 1,
                Price = 32.99M,
                Cover = "https://m.media-amazon.com/images/I/414xg51k78L._AC_UF1000,1000_QL80_.jpg",
                PublisherId = 2,
                StatusId = 1,
                LanguageId = 1
            };
            builder.Entity<Book>().HasData(b1, b2, b3, b4, b5);

            AuthorBook ab1 = new AuthorBook { AuthorBookId = 1, AuthorId = 1, BookId = 1 };
            AuthorBook ab2 = new AuthorBook { AuthorBookId = 2, AuthorId = 1, BookId = 2 };
            AuthorBook ab3 = new AuthorBook { AuthorBookId = 3, AuthorId = 2, BookId = 3 };
            AuthorBook ab4 = new AuthorBook { AuthorBookId = 4, AuthorId = 2, BookId = 4 };
            AuthorBook ab5 = new AuthorBook { AuthorBookId = 5, AuthorId = 2, BookId = 5 };
            builder.Entity<AuthorBook>().HasData(ab1, ab2, ab3, ab4, ab5);

            BookGenre bg1 = new BookGenre { BookGenreId = 1, BookId = 1, GenreId = 1 };
            BookGenre bg2 = new BookGenre { BookGenreId = 2, BookId = 2, GenreId = 1 };
            BookGenre bg3 = new BookGenre { BookGenreId = 3, BookId = 3, GenreId = 2 };
            BookGenre bg4 = new BookGenre { BookGenreId = 4, BookId = 3, GenreId = 5 };
            BookGenre bg5 = new BookGenre { BookGenreId = 5, BookId = 4, GenreId = 2 };
            BookGenre bg6 = new BookGenre { BookGenreId = 6, BookId = 4, GenreId = 5 };
            BookGenre bg7 = new BookGenre { BookGenreId = 7, BookId = 5, GenreId = 2 };
            BookGenre bg8 = new BookGenre { BookGenreId = 8, BookId = 5, GenreId = 5 };
            builder.Entity<BookGenre>().HasData(bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8);

            BookBookType bbt1 = new BookBookType { BookBookTypeId = 1, BookId = 1, BookTypeId = 1 };
            BookBookType bbt2 = new BookBookType { BookBookTypeId = 2, BookId = 2, BookTypeId = 1 };
            BookBookType bbt3 = new BookBookType { BookBookTypeId = 3, BookId = 3, BookTypeId = 1 };
            BookBookType bbt4 = new BookBookType { BookBookTypeId = 4, BookId = 4, BookTypeId = 1 };
            BookBookType bbt5 = new BookBookType { BookBookTypeId = 5, BookId = 5, BookTypeId = 1 };
            builder.Entity<BookBookType>().HasData(bbt1, bbt2, bbt3, bbt4);

            BookInSeries bis1 = new BookInSeries { BookInSeriesId = 1, BookId = 3, SeriesId = 1, Number = 1 };
            BookInSeries bis2 = new BookInSeries { BookInSeriesId = 2, BookId = 4, SeriesId = 1, Number = 2 };
            BookInSeries bis3 = new BookInSeries { BookInSeriesId = 3, BookId = 5, SeriesId = 1, Number = 3 };
            builder.Entity<BookInSeries>().HasData(bis1, bis2, bis3);
        }
    }
}
