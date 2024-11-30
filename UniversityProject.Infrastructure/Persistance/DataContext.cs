using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Infrastructure.Persistance
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Database migrationni avtomatik ravishda ishga tushiradi
            // Bu jarayon faqat dev/prod muhit uchun mos bo'lishi mumkin.
            Database.Migrate();
        }

        // DbSet'lar
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // **Book -> Author** (Many-to-One)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // O‘chirishni cheklash

            // **Book -> Country** (Many-to-One)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Country)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            // **Book -> Category** (Many-to-Many)
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Category)
                .WithMany(c => c.Books)
                .UsingEntity(j => j.ToTable("BookCategories")); // O‘rta jadval nomi

            // **Author -> Country** (Many-to-One)
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Author)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            // **Country -> ApplicationUser** (One-to-Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Country)
                .WithMany(c => c.User)
                .HasForeignKey(u => u.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            // **Event -> ApplicationUser** (One-to-Many)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // **Report -> ApplicationUser** (One-to-Many)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder); // Asosiy konfiguratsiyani chaqirish
        }
    }
}
