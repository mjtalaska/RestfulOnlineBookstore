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
        public DbSet<Person> People { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<TranslatedBook> TranslatedBooks { get; set; }
        public DbSet<Translator> Translators { get; set; }

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
                a.HasMany(e => e.KnownTechniques).WithMany(e => e.Artists);
                a.HasMany(e => e.Tasks).WithOne(e => e.Artist);
            });

            builder.Entity<ArtistsTask>(a =>
            {
                a.HasOne(e => e.Artist).WithMany(e => e.Tasks);
                a.HasOne(e => e.Comic).WithMany(e => e.ComicArtists);
            });

            builder.Entity<Author>(a =>
            {
                a.HasMany(e => e.Books).WithMany(e => e.Authors);
            });

            builder.Entity<Book>(b =>
            {
                b.HasOne(e => e.OriginalLanguage).WithMany(e => e.Books);
                b.HasOne(e => e.Status).WithMany(e => e.Books);
                b.HasMany(e => e.Authors).WithMany(e => e.Books);
                b.HasMany(e => e.Genres).WithMany(e => e.Books);
                b.HasMany(e => e.ComicArtists).WithOne(e => e.Comic);
                b.HasMany(e => e.Type).WithMany(e => e.Books);
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
                g.HasMany(e => e.Books).WithMany(e => e.Genres);
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
                t.HasOne(e => e.TranslatedLanguage).WithMany(e => e.Translations);
            });

            builder.Entity<Translator>(t =>
            {
                t.HasMany(e => e.Books).WithOne(e => e.Translator);
                t.HasMany(e => e.KnownLanguages).WithMany(e => e.Translators);
            });

            builder.Entity<ApplicationUser>(u =>
            {
                u.HasMany(e => e.Comments).WithOne(e => e.User);
                u.HasMany(e => e.Purchases).WithOne(e => e.User);
                u.HasMany(e => e.InCart).WithOne(e => e.User);
            });

            builder.Entity<Publisher>().HasData(new Publisher { PublisherId = 1, Name = "Hachette Collections", WebAddress = "https://www.hachette-collections.com/fr-fr/" });
        }
    }
}
