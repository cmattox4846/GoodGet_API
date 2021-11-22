using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Role> Role { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<Products> Products { get; set; }



        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>()
                //.HasColumnType("decimal(,)")
                .HasData(
                new Products { Id = "1", Name = "Samsung TV", Description = "Samsung QLED 55 TV", Price = 1299.99m },
                new Products { Id = "2", Name = "Beats Headphones", Description = "Beats by Dre Wireless Headphones", Price = 199.99m },
                new Products { Id = "3", Name = "GoPro", Description = "GoPro Hero 9", Price = 459.99m },
                new Products { Id = "4", Name = "Ethernet Cable", Description = "Cat 6 Etherenet Cable 25'", Price = 459.99m }

            );

            modelBuilder.Entity<UserRoles>()
               .HasNoKey();


            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }

    }
}
