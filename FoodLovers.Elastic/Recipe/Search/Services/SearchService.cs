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
        public async Task<IEnumerable<RecipeSearchModel>> SearchAsync(string indexName, string query)
        {
            var searchResponse = await _elasticClient.SearchAsync<Domain.Entities.Recipe>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query(query)
                    )
                )
            );

            var recipe = searchResponse.Documents;

            //var searchResponse = await _elasticClient.SearchAsync<Domain.Entities.Recipe>(s => s
            //    .Size(0)
            //    .Query(q => q
            //        .Match(m => m
            //            .Field(f => f.Name)
            //            .Query("Onion")
            //        )
            //    )
            //    .Aggregations(a => a
            //        .Terms("prep_time", ta => ta
            //            .Field(f => f.PreparationTimeInMinutes)
            //        )
            //    )
            //);

            //var termsAggregation = searchResponse.Aggregations.Terms("prep_time");
            return _mapper.Map<IEnumerable<RecipeSearchModel>>(recipe);
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

        public async Task IndexAsync(string indexName, List<RecipeSearchModel> recipes)
        {
            await _elasticClient.IndexManyAsync(recipes, indexName);
        }

        //public async Task<SearchResult> SearchAsync2(string query, int page, int pageSize)
        //{
        //    var result = await _elasticClient.SearchAsync<RecipeSearchModel>(x => x	
        //        .Query(q => q				
        //            .MultiMatch(mp => mp			
        //                .Query(query)			
        //                .Fields(f => f			
        //                    .Fields(f1 => f1.Name, f2 => f2.Directions))))
        //        .From(page - 1)				
        //        .Size(pageSize));           


        //}
    }
}
