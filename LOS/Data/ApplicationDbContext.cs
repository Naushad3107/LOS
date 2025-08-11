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
            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });  // Composite PK

                entity.HasOne(ur => ur.User)
                    .WithMany(u => u.userRoles)  // Use exact property name from Users model
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.userRoles)  // Use exact property name from Roles model
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<States>(ent =>
            {
                ent.HasOne(x => x.Country)
                .WithMany(x => x.States)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Cities>(ent =>
            {
                ent.HasOne(x => x.State)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.StateId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<PincodeMaster>(ent =>
            {
                ent.HasOne(x => x.City)
                .WithMany(x => x.Pincodes)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);
                ent.HasOne(x => x.States)
                .WithMany(x => x.Pincodes)
                .HasForeignKey(x => x.StateId)
                .OnDelete(DeleteBehavior.Restrict);
                ent.HasOne(x => x.Countries)
                .WithMany(x => x.Pincodes)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
            });


        }

    }

}

