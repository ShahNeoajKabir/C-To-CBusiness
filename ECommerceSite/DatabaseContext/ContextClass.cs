using ECommerce.DTO.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public class ContextClass : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public  DbSet<State> State { get; set; }
        public  DbSet<City> City { get; set; }
        public  DbSet<Division> Division { get; set; }
        public  DbSet<Country> Country { get; set; }
        public  DbSet<UserPhoto> UserPhoto { get; set; }
        public  DbSet<Brand> Brand { get; set; }
        public  DbSet<Category> Category { get; set; }
        public  DbSet<Color> Color { get; set; }
        public  DbSet<Product> Product { get; set; }
        public  DbSet<ProductColor> ProductColor { get; set; }
        public  DbSet<ProductPhoto> ProductPhoto { get; set; }
        public  DbSet<ProductSize> productSize { get; set; }
        public  DbSet<Size> Size { get; set; }
        public  DbSet<SubCategory> SubCategory { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<State>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(o => o.City)
                .WithMany(p => p.State)
                .HasForeignKey(f => f.CityId)
                .OnDelete(DeleteBehavior.NoAction);


                entity.HasMany(p => p.AppUser)
                .WithOne(prop => prop.State)
                .HasForeignKey(f => f.StateId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<City>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(o => o.Division)
                .WithMany(p => p.City)
                .HasForeignKey(f => f.DivisionId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(p => p.AppUser)
               .WithOne(prop => prop.City)
               .HasForeignKey(f => f.CityId)
               .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Division>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(o => o.Country)
                .WithMany(p => p.Division)
                .HasForeignKey(f => f.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(p => p.AppUser)
               .WithOne(prop => prop.Division)
               .HasForeignKey(f => f.DivisionId)
               .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(p => p.AppUser)
               .WithOne(prop => prop.Country)
               .HasForeignKey(f => f.CountryId)
               .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<AppUser>()
                .HasMany(p => p.UserRole)
                .WithOne(p => p.User)
                .HasForeignKey(f => f.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
               .HasMany(p => p.UserRole)
               .WithOne(p => p.Role)
               .HasForeignKey(f => f.RoleId)
               .IsRequired();
        }
    }
}
