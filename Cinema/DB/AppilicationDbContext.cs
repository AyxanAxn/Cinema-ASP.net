﻿using Cinema.EntityBases;
using Cinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Cinema.DB
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<SeansReserves> SeansReserves { get; set; }
        public DbSet<Actor> Actors { get; set; }
        




        protected override void OnModelCreating(ModelBuilder builder)
        {
       
            base.OnModelCreating(builder);
        }
    }
}
