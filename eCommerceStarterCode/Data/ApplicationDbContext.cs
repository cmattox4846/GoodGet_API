using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Role> Role { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<Products> Products { get; set; }
        public IEnumerable<object> ShoppingCart { get; internal set; }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Role>()
            //    .HasData(
            //    new Role { Id = 1, RoleName = "Seller" },
            //    new Role { Id = 1, RoleName = "Buyer" }
            //);

            modelBuilder.Entity<UserRoles>()
               .HasNoKey();


            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }

    }
}
