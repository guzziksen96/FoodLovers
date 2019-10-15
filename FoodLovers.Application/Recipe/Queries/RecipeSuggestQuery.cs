using FoodLovers.Application.Recipe.Models;
using MediatR;

namespace FoodLovers.Application.Recipe.Queries
{
    public class RecipeSuggestQuery : IRequest<RecipeSuggestResponse>
    {
        public string Keyword { get; set; }
    }
}
