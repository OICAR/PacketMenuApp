﻿using Microsoft.EntityFrameworkCore;
using PocketMenuUI.Models;

namespace PocketMenuUI.Data
{
    public class JelovnikDbContext: DbContext
    {
        public JelovnikDbContext(DbContextOptions<JelovnikDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
     //   public DbSet<Menu> Menus { get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Seed();
     }
    }
    
}