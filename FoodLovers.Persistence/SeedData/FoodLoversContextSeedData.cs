using System.Collections.Generic;
using FizzWare.NBuilder;
using FoodLovers.Domain.Entities;

namespace FoodLovers.Persistence.SeedData
{
    public class FoodLoversContextSeedData
    {
        private readonly FoodLoversDbContext _context;

        public FoodLoversContextSeedData(FoodLoversDbContext context)
        {
            _context = context;
        }
  
        public void AddRecipes()
        {
            var recipes = Builder<Recipe>.CreateListOfSize(50000)
                .All()
                .With(c => c.Id = 0)
                .With(c => c.Name = Faker.Lorem.Sentence())
                .With(c => c.Directions = Faker.Lorem.Paragraph())
                .With(c => c.PreparationTimeInMinutes = Faker.RandomNumber.Next(10, 60).ToString())
                .Build();

            _context.Recipes.AddRange(recipes);
            _context.SaveChanges();
        }

        public void AddRecipeTags()
        {
            var i = 15030;
            var recipeTags = Builder<RecipeTag>.CreateListOfSize(50215)
                .All()
                .With(c => c.TagId = Faker.RandomNumber.Next(1, 16))
                .With(c => c.RecipeId = i+1)
                .Build();

            _context.RecipeTags.AddRange(recipeTags);
            _context.SaveChanges();
        }

        public void AddIngredients()
        {
            var ingredients = Builder<Ingredient>.CreateListOfSize(50000)
                .All()
                .With(c => c.Name = Faker.Lorem.Sentence())
                .With(c => c.Id = 0)
                .Build();
            
            _context.Ingredients.AddRange(ingredients);
            _context.SaveChanges();
           
        }

        private void AddRecipeIngredients()
        {
            // 1 - 213 real recipies 
            // 1 - 2268 real ingredients 
            //to generate a random number between
            // ABS(CHECKSUM(NEWID()) % (@max - @min + 1)) + @min

            // DECLARE @max int = 213
            //DECLARE @min int = 1
            //update dbo.Ingredients set RecipeId = ABS(CHECKSUM(NEWID()) % (@max - @min + 1)) + @min  where Id > 2268

        }
        public void AddTags()
        {
            var tags = new List<Tag>
            {
                new Tag {Name = "Appetizers"},
                new Tag {Name = "Snacks"},
                new Tag {Name = "Breakfast"},
                new Tag {Name = "Brunch"},
                new Tag {Name = "Cake Recipes"},
                new Tag {Name = "Cookies"},
                new Tag {Name = "Chicken Recipes"},
                new Tag {Name = "Soups"},
                new Tag {Name = "Dinner"},
                new Tag {Name = "Gluten Free"},
                new Tag {Name = "Healthy"},
                new Tag {Name = "Vegan"},
                new Tag {Name = "Vegetarian"},
                new Tag {Name = "Low Fat"},
                new Tag {Name = "Low Calories"},
                new Tag {Name = "Diabetic"},
            };

            _context.Tags.AddRange(tags);
            _context.SaveChanges();
        }
    }
}
