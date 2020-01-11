using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Elastic.Recipe.Autocomplete.Models;
using FoodLovers.Persistence;
using FoodLovers.Persistence.SeedData;
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
            var seeder = new FoodLoversContextSeedData(_context);

            // 1.
            // seeder.AddTags();

            // 2.
            //var recipesScraper = new AllRecipesScraper();
            //var scrapedRecipes = recipesScraper.ScrapRecipe();

            //var recipes = _mapper.Map<ICollection<Domain.Entities.Recipe>>(scrapedRecipes);
            //_context.Recipes.AddRange(recipes);

            // 3.
            //seeder.AddRecipes();

            // 4.
            //seeder.AddIngredients();

            // 5.
            //seeder.AddRecipeTags();

            return await _context.SaveChangesAsync();
        }
    }
}
