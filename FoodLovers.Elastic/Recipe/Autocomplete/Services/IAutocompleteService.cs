using System.Collections.Generic;
using System.Threading.Tasks;
using FoodLovers.Elastic.Recipe.Autocomplete.Models;

namespace FoodLovers.Elastic.Recipe.Autocomplete.Services
{
    public interface IAutocompleteService
    {
        Task<bool> CreateIndexAsync(string indexName);
        Task IndexAsync(string indexName, List<RecipeModel> recipes);
        Task<RecipeSuggestResponse> SuggestAsync(string indexName, string query );
    }
}
