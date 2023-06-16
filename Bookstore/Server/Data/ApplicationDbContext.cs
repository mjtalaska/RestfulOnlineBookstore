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

            builder.Entity<Book>(b =>
            {
                b.HasOne(e => e.Language).WithMany(e => e.Books);
                b.HasOne(e => e.Status).WithMany(e => e.Books);
                b.HasMany(e => e.Authors).WithOne(e => e.Book);
                b.HasMany(e => e.Genres).WithOne(e => e.Book);
                b.HasMany(e => e.ComicArtists).WithOne(e => e.Book);
                b.HasMany(e => e.Type).WithOne(e => e.Book);
                b.HasOne(e => e.Publisher).WithMany(e => e.Books);
                b.HasOne(e => e.TranslatedBook).WithOne(e => e.Book);
                b.HasMany(e => e.Carts).WithOne(e => e.Book);
                b.HasMany(e => e.Purchases).WithOne(e => e.Book);
                b.HasMany(e => e.Comments).WithOne(e => e.Book);
                b.HasOne(e => e.BookInSeries).WithOne(e => e.Book);
                b.Property(e => e.Price).HasColumnType("decimal(5,2)").IsRequired(true);
            });

            builder.Entity<BookInSeries>(b =>
            {
                b.HasOne(e => e.Series).WithMany(e => e.Books);
                b.HasOne(e => e.Book).WithOne(e => e.BookInSeries).HasForeignKey<Book>(e => e.BookId);
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

            builder.Entity<TranslatedBook>(t =>
            {
                t.HasOne(e => e.Book).WithOne(e => e.TranslatedBook).HasForeignKey<Book>(e => e.BookId);
                t.HasOne(e => e.Translator).WithMany(e => e.Books);
                t.HasOne(e => e.Language).WithMany(e => e.Translations);
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

            Publisher p = new Publisher { PublisherId = 1, Name = "Hachette Collections", WebAddress = "https://www.hachette-collections.com/fr-fr/" };
            builder.Entity<Publisher>().HasData(p);

            Author a1 = new Author { PersonId = 1, Name = "Stephen", Surname = "King", DateOfBirht = DateTime.Parse("1945-10-12")};
            Author a2 = new Author { PersonId = 2, Name = "Maruyama", Surname = "Kagune", DateOfBirht = DateTime.Parse("1990-03-30") };
            builder.Entity<Author>().HasData(a1, a2);

            Language l1 = new Language { LanguageId = 1, Name = "English" };
            builder.Entity<Language>().HasData(l1);

            Genre g1 = new Genre { GenreId = 1, Name = "Horror" };
            Genre g2 = new Genre { GenreId = 2, Name = "Fantasy" };
            Genre g3 = new Genre { GenreId = 3, Name = "Thriller" };
            Genre g4 = new Genre { GenreId = 4, Name = "Detective" };
            builder.Entity<Genre>().HasData(g1, g2, g3, g4);

        }
    }
}
