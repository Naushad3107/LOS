using LOS.Models;
using Microsoft.EntityFrameworkCore;

namespace LOS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<States> States { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<RejectionReason> rejectionReasons { get; set; }
        public DbSet<PincodeMaster> pincodes { get; set; }

        public DbSet<OccupationType> occupationTypes { get; set; }

        public DbSet<EmployementType> employementTypes { get; set; }

        public DbSet<DocumentType> documentTypes { get; set; }

        public DbSet<Department> departments { get; set; }

        public DbSet<Countries> countries { get; set; }
        public DbSet<Cities> cities { get; set; }

        public DbSet<Branch> branches { get; set; }

        public DbSet<Bank> banks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<States>()
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<States>()
       .HasOne(s => s.Country)
       .WithMany(c => c.States)
       .HasForeignKey(s => s.CountryId)
       .OnDelete(DeleteBehavior.Restrict);

            // State - Cities (One-to-Many)
            modelBuilder.Entity<Cities>()
                .HasOne(city => city.State)
                .WithMany(state => state.Cities)
                .HasForeignKey(city => city.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            // PincodeMaster - City (Many-to-One)
            modelBuilder.Entity<PincodeMaster>()
                .HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            // PincodeMaster - States (Many-to-One)
            modelBuilder.Entity<PincodeMaster>()
                .HasOne(p => p.States)
                .WithMany()
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            // PincodeMaster - Countries (Many-to-One)
            modelBuilder.Entity<PincodeMaster>()
                .HasOne(p => p.Countries)
                .WithMany() 
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    } 
 
    }

