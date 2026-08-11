
using Microsoft.EntityFrameworkCore;
using proj1.Entity;
using System.Reflection.Emit;

namespace proj1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Relations> Relations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkilerin tanımlanması (Fluent API)
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Family)
                .WithMany(f => f.Persons).HasForeignKey(p => p.FamilyId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Business)
                .WithMany(b => b.Persons).HasForeignKey(p =>p.BusinessId);
                ;

            modelBuilder.Entity<Relations>()
                 .HasOne(p => p.Person)
                 .WithMany(b => b.Relations).HasForeignKey(p => p.MainPersonId);
        }
        //base ve options neden kullanıldı bilmiyorum araştır
    }
}
