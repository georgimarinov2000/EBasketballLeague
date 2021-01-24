using System;
using System.Collections.Generic;
using System.Text;
using DataStructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public  DbSet<Arena> Arenas { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerBrand> PlayerBrands { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlayerBrand>()
                .HasKey(x => new { x.PlayerID, x.BrandID });
            modelBuilder.Entity<PlayerBrand>()
                .HasOne(x => x.Player)
                .WithMany(x => x.PlayerBrands)
                .HasForeignKey(x => x.PlayerID);
            modelBuilder.Entity<PlayerBrand>()
                .HasOne(x => x.Brand)
                .WithMany(x => x.PlayerBrands)
                .HasForeignKey(x => x.BrandID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
