using EventGarden.Entities.Entitity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DAL.Contexts
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRole>().HasData(new AppRole() { Id = 1, ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole() { Id = 2, ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "Member", NormalizedName = "MEMBER" });
            builder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Movie" });            
            base.OnModelCreating(builder);  
        }
        //public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketEvent> BasketEvents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Etkinlik> Etkinliks { get; set; }

    }
}
