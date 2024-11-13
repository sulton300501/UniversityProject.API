using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Infrastructure.Persistance
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options) { }
      

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Event> Tadbirs { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Books)
                .HasForeignKey(x => x.category_id)
                .IsRequired(false);



            modelBuilder.Entity<Book>()
               .HasOne(e => e.Author)
               .WithMany(e => e.Books)
               .HasForeignKey(x => x.author_id)
               .IsRequired(false);


            modelBuilder.Entity<Book>()
               .HasOne(e => e.Country)
               .WithMany(e => e.Books)
               .HasForeignKey(x => x.countr_id)
               .IsRequired(false);



            modelBuilder.Entity<Author>()
               .HasOne(e => e.Country)
               .WithOne(e => e.Author)
               .HasForeignKey<Author>(x=>x.country_id)
               .IsRequired(false);


            modelBuilder.Entity<Book>()
               .HasOne(e => e.Author)
               .WithMany(e => e.Books)
               .HasForeignKey(x => x.author_id)
               .IsRequired(false);





            modelBuilder.Entity<ApplicationUser>()
    .HasOne(x => x.Report)    
    .WithOne(x => x.User)        
    .HasForeignKey<Report>(x => x.user_id)  
    .IsRequired();


            modelBuilder.Entity<ApplicationUser>()
              .HasOne(u => u.Country)
              .WithMany(c => c.User)
              .HasForeignKey(u => u.country_id)
              .OnDelete(DeleteBehavior.Restrict);






        }






    }
}
