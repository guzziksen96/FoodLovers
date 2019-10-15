using System.Threading;
using System.Threading.Tasks;
using FoodLovers.Application.Scraper.Services;
using MediatR;

namespace FoodLovers.Application.Scraper.Commands
{
    public class ScrapRecipesCommandHandler : IRequestHandler<ScrapRecipesCommand, int>
    {
        private IScraperService _scraperService { get; set; }

        public ScrapRecipesCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        public async Task<int> Handle(ScrapRecipesCommand request, CancellationToken cancellationToken)
        {
            return await _scraperService.AddRecipes();
        }
    }
}
