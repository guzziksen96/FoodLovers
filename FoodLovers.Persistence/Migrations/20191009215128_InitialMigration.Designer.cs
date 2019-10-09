﻿// <auto-generated />
using System;
using FoodLovers.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodLovers.Persistence.Migrations
{
    [DbContext(typeof(FoodLoversDbContext))]
    [Migration("20191009215128_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodLovers.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("FoodLovers.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Directions");

                    b.Property<string>("Name");

                    b.Property<int>("PreparationTimeInMinutes");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodLovers.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("IngredientId");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("FoodLovers.Domain.Entities.RecipeTag", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("TagId");

                    b.HasKey("RecipeId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("RecipeTags");
                });

            modelBuilder.Entity("FoodLovers.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FoodLovers.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("FoodLovers.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredient")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodLovers.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredient")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FoodLovers.Domain.Entities.RecipeTag", b =>
                {
                    b.HasOne("FoodLovers.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeTag")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodLovers.Domain.Entities.Tag", "Tag")
                        .WithMany("RecipeTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
