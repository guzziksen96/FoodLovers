using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FoodLovers.Application.Recipe.Queries
{
    //public class RecipeSuggestQueryHandler : IRequestHandler<RecipeSuggestQuery, RecipeSuggestResponse>
    //{
    //    private readonly IAutocompleteService _autocompleteService;

    //    public RecipeSuggestQueryHandler(IAutocompleteService autocompleteService)
    //    {
    //        _autocompleteService = autocompleteService;
    //    }
    //    public async Task<RecipeSuggestResponse> Handle(RecipeSuggestQuery request, CancellationToken cancellationToken)
    //    {
    //        return await _autocompleteService.SuggestAsync("Name", request.Keyword);
    //    }
    //}
}
