﻿using FoodLovers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodLovers.Persistence
{
    public class FoodLoversDbContext : DbContext
    {
        public FoodLoversDbContext(DbContextOptions<FoodLoversDbContext> options)
        : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodLoversDbContext).Assembly);

            modelBuilder.Entity<RecipeTag>().HasKey(ri => new { ri.RecipeId, ri.TagId });

            modelBuilder.Entity<Recipe>()
                .HasMany<RecipeTag>(r => r.RecipeTag);

            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients);

        }
    }
}
