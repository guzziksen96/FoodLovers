using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Elastic.Constants;
using FoodLovers.Elastic.Recipe.Search.Models;
using FoodLovers.Infrastructure.Elastic;
using Nest;

namespace FoodLovers.Elastic.Recipe.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly ElasticClient _elasticClient;
        private IMapper _mapper;
        public SearchService(ElasticClientProvider provider, IMapper mapper)
        {
            _elasticClient = provider.Client;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeSearchModel>> SearchAsync(string indexName, 
            string searchTerm)
        {
            var searchResponse = await _elasticClient.SearchAsync<RecipeSearchModel>(s => s 
                .Index(indexName)
                .Take(50)
                .From(0)
                .Size(50)
                .Query(q => q
                    .MultiMatch(mp => mp
                        .Query(searchTerm)
                        .Fields(f => f
                            .Fields(f1 => f1.Name, f2 => f2.Directions, 
                             f3 => f3.Ingredients, f4 => f4.Tags)))));

            return searchResponse.Documents;
        }

       
        
        
        
        [Obsolete]
        public async Task<bool> CreateIndexAsync(string indexName)
        {
            var indexDescriptor = new CreateIndexDescriptor(indexName)
                .Settings(s => s
                    .Analysis(a => a
                        .Tokenizers(t => t.Pattern(Tokenizer.Comma, p => p.Pattern(",")))
                        .Analyzers(an => an
                            .Custom(Analyzer.CommaLowercaseTrim, ca => ca
                                .Tokenizer(Tokenizer.Comma).Filters(TokenFilter.Lowercase, TokenFilter.Trim)))))
                .Mappings(ms => ms
                    .Map<RecipeSearchModel>(m => m
                        .AutoMap()
                        .Properties(p => p
                            .Text(t => t
                                .Name(n => n.Tags)
                                .Analyzer(Analyzer.CommaLowercaseTrim)))));

            if (_elasticClient.Indices.Exists(indexName.ToLowerInvariant()).Exists)
            {
                _elasticClient.Indices.Delete(indexName.ToLowerInvariant());
            }

            var createIndexResponse = await _elasticClient.Indices
                .CreateAsync(indexDescriptor);

            return createIndexResponse.IsValid;
        }

    }
}
