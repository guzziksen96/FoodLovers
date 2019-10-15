using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Persistence;

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
            //var recipesScraper = new AllRecipesScraper();
            //var scrapedRecipes = recipesScraper.ScrapRecipe();

            //var seeder = new FoodLoversContextSeedData(_context);

            //seeder.SeedData();
            
            //var scrapedRecipes = new List<RecipeModel> {scrapedRecipe};

            //var recipes = _mapper.Map<ICollection<Domain.Entities.Recipe>>(scrapedRecipes);
            
           
            //_context.Recipes.AddRange(recipes);
            
            return await _context.SaveChangesAsync();
        }
    }
}
