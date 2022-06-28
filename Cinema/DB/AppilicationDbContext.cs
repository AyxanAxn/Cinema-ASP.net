using Cinema.EntityBases;
using Cinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DB
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }


        DbSet<User> Users { get; set; } 
        DbSet<Room> Room { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>();
            base.OnModelCreating(builder);
        }


    }
}
