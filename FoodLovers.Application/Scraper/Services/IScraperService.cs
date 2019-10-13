
using System.Threading.Tasks;

namespace FoodLovers.Application.Scraper.Services
{
    public interface IScraperService
    {
        Task<int> AddRecipes();
    }
}
