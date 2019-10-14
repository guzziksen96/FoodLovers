using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodLovers.Application.Recipe.Models;

namespace FoodLovers.Application.Recipe.Services
{
    public interface IAutocompleteService
    {
        Task<bool> CreateIndexAsync(string indexName);
        Task IndexAsync(string indexName, List<RecipeElasticModel> recipes);
        Task<RecipeSuggestResponse> SuggestAsync(string indexName, string query );
    }
}
