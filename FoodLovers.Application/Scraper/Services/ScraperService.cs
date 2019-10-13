using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Domain.Entities;
using FoodLovers.Persistence;
using RecipeScarper.Scrapers;

namespace FoodLovers.Application.Scraper.Services
{
    public class ScraperService: IScraperService
    {
        private readonly FoodLoversDbContext _context;
        private IMapper _mapper;

        public ScraperService(FoodLoversDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddRecipes()
        {
            var recipesScraper = new AllRecipesScraper();
            var scrapedRecipes = recipesScraper.ScrapRecipe();

            //var ingredients = new List<IngredientModel>
            //{
            //    new IngredientModel("1 ½ pounds skinless, boneless chicken breast"),
            //    new IngredientModel("1 teaspoon garam masala"),
            //    new IngredientModel("1 (15 ounce) can tomato sauce"),
            //    new IngredientModel("1 cup butter")

            //};
            
            //var scrapedRecipe = new RecipeModel
            //{
            //    Name = "Butter Chicken",
            //    PreparationTimeInMinutes = "60",
            //    Ingredients = ingredients,
            //    Directions = "Preheat oven to 375 degrees F (190 degrees C). Melt a few tablespoons of butter in a skillet over medium heat. Stir in onion and garlic, and cook slowly until the onion caramelizes to a dark brown, about 15 minutes. Meanwhile melt the remaining butter in a saucepan over medium-high heat along with the tomato sauce, heavy cream, salt, cayenne pepper, and garam masala. Bring to a simmer, then reduce heat to medium-low; cover, and simmer for 30 minutes, stirring occasionally. Then stir in caramelized onions. While the sauce is simmering, toss cubed chicken breast with vegetable oil until coated, then season with tandoori masala and spread out onto a baking sheet. Bake chicken in preheated oven until no longer pink in the center, about 12 minutes. Once done, add the chicken to the sauce and simmer for 5 minutes before serving."
            //};

            //var scrapedRecipes = new List<RecipeModel> {scrapedRecipe};

            var recipes = _mapper.Map<ICollection<Recipe>>(scrapedRecipes);
            
           
            _context.Recipes.AddRange(recipes);
            
            return await _context.SaveChangesAsync();
        }
    }
}
