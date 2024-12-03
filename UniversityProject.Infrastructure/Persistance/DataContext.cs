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
            // Database.EnsureCreated();   
        }

        // DbSet'lar
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Event> Events { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Lazy Loading'ni yoqish
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // **Book -> Author** (Many-to-One)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.SetNull); // O‘chirishni cheklash

            // **Book -> Country** (Many-to-One)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Country)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category) // Book -> Category (One-to-One)
                .WithMany(c => c.Books)  // Category -> Books (One-to-Many)
                .HasForeignKey(b => b.CategoryId) // Foreign key
                .OnDelete(DeleteBehavior.SetNull); // O'chirish cheklovi

            // **Author -> Country** (Many-to-One)
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Author)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            // **Country -> ApplicationUser** (One-to-Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Country)
                .WithMany(c => c.User)
                .HasForeignKey(u => u.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            // **Event -> ApplicationUser** (One-to-Many)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.ApplicationUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // **Report -> ApplicationUser** (One-to-Many)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.ApplicationUserId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder); // Asosiy konfiguratsiyani chaqirish
        }
    }
}
