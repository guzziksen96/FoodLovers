using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodLovers.Application.Recipe.Models;
using FoodLovers.Infrastructure.Elastic;
using Nest;

namespace FoodLovers.Application.Recipe.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        private readonly ElasticClient _elasticClient;

        public AutocompleteService(ElasticClientProvider provider)
        {
            _elasticClient = provider.Client;
        }
        
        public async Task<bool> CreateIndexAsync(string indexName)
        {
            var createIndexDescriptor = new CreateIndexDescriptor(indexName)
                .Mappings(ms => ms
                    .Map<RecipeElasticModel>(m => m
                        .AutoMap()
                        .Properties(ps => ps
                            .Completion(c => c
                                .Name(p => p.Suggest))))
                );

            if (_elasticClient.Indices.Exists(indexName.ToLowerInvariant()).Exists)
            {
                _elasticClient.Indices.Delete(indexName.ToLowerInvariant());
            }

            var createIndexResponse = await _elasticClient.Indices.CreateAsync(createIndexDescriptor);

            return createIndexResponse.IsValid;
        }

        public async Task IndexAsync(string indexName, List<RecipeElasticModel> recipes)
        {
            await _elasticClient.IndexManyAsync(recipes, indexName);
        }

        public async Task<RecipeSuggestResponse> SuggestAsync(string indexName, string query)
        {
            ISearchResponse<RecipeElasticModel> searchResponse = await _elasticClient.SearchAsync<RecipeElasticModel>(s => s
                .Index(indexName)
                .Suggest(su => su
                    .Completion("suggestions", c => c
                        .Field(f => f.Suggest)
                        .Prefix(query)
                        .Fuzzy(f => f
                            .Fuzziness(Fuzziness.Auto)
                        )
                        .Size(5))
                ));

            var suggests = from suggest in searchResponse.Suggest["suggestions"]
                from option in suggest.Options
                select new RecipeSuggest
                {
                    Name = option.Text,
                    Score = option.Score
                };

            return new RecipeSuggestResponse
            {
                Suggests = suggests
            };
        }
    }
}
