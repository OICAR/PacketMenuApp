﻿using Microsoft.EntityFrameworkCore;

namespace PocketMenuUI.Models
{
  
        public static class ModelBuilderExtensions
        {
            public static void Seed(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Meal>().HasData(
                    new Meal
                    {
                        ID = 1,
                        Title = "Salad",
                        Ingredients = "Sauce,Lettuce,Leafs",
                        Amount = 1,
                        Price = 18
                     
                    },   new Meal
                    {
                        ID = 2,
                        Title = "Pizza",
                        Ingredients = "Cheese,Ham,Tomato sauce",
                        Amount = 1,
                        Price = 33,
                    },   new Meal
                    {
                        ID = 3,
                        Title = "Spaghetti bolognese",
                        Ingredients = "Meat,sauce",
                        Amount = 1,
                        Price =26,
                    }
                    
                );
            }
        }
    }
