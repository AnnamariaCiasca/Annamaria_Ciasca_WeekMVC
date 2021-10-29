using Microsoft.EntityFrameworkCore;
using Restaurant.Core;
using Restaurant.Core.Models;
using Restaurant.EF.Configurations;
using System;

namespace Restaurant.EF
{
    public class RestaurantContext : DbContext
    { 
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Menù> Menus { get; set; }
    public DbSet<User> Users { get; set; }



    public RestaurantContext()
    {

    }

    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=RestaurantDb; Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Dish>(new DishConfiguration());
        modelBuilder.ApplyConfiguration<Menù>(new MenuConfiguration());
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
    }
}
}
