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
        public DbSet<Person> People { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookType> BookTypes { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>(p =>
            {
                p.HasKey(e => e.PersonId);
            });

            builder.Entity<Author>(a =>
            {
                a.Property(e => e.Pseudonym).IsRequired(false);
                a.HasMany(e => e.Books).WithOne(e => e.Author);
            });

            builder.Entity<Translator>(t =>
            {
                t.HasMany(e => e.Books).WithOne(e => e.Translator);
            });

            builder.Entity<AuthorBook>(a =>
            {
                a.HasKey(e => e.AuthorBookId);
                a.HasOne(e => e.Author).WithMany(e => e.Books);
            });

            builder.Entity<Book>(b =>
            {
                b.HasKey(e => e.BookId);
                b.Property(e => e.AdvisedAge).IsRequired(false);

                b.HasMany(e => e.Authors).WithOne(e => e.Book);

                b.HasOne(e => e.Status).WithMany(e => e.Books);
                b.HasMany(e => e.Type).WithMany(e => e.Books);
                b.HasMany(e => e.Genres).WithMany(e => e.Books);
                b.HasOne(e => e.OriginalLanguage).WithMany(e => e.Books);
            });
        }
    }
}
