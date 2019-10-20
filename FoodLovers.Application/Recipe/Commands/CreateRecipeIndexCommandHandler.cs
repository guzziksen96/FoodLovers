using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FoodLovers.Application.Recipe.Commands
{
    //public class CreateRecipeIndexCommandHandler : IRequestHandler<CreateRecipeIndexCommand, int>
    //{
    //    private readonly IAutocompleteService _autocompleteService;

    //    public CreateRecipeIndexCommandHandler(IAutocompleteService autocompleteService)
    //    {
    //        _autocompleteService = autocompleteService;
    //    }

    //    public async Task<int> Handle(CreateRecipeIndexCommand request, CancellationToken cancellationToken)
    //    {
    //        string recipeSuggestIndex = "Name";
    //        //bool isCreated = _autocompleteService.CreateIndexAsync("Name").Result;

    //        //if (isCreated)
    //        //{
    //        //    _autocompleteService.IndexAsync("Name", products).Wait();
    //        //}
    //        return 1; //todo
    //    }

    //}
}
