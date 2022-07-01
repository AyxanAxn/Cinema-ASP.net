using Cinema.EntityBases;
using Cinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DB
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
        DbSet<IdentityUser> Users { get; set; } 
        DbSet<Room> Rooms { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Seans> Seans { get; set; }
        DbSet<Chair> Chairs { get; set; }
        DbSet<Reserve> Reserves{ get; set; }
        DbSet<SeansReserves> SeansReserves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Movie>().HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}
