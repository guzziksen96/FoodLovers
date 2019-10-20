using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Elastic.Recipe.Search.Models;
using FoodLovers.Infrastructure.Elastic;
using Nest;

namespace FoodLovers.Elastic.Recipe.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly ElasticClient _elasticClient;
        private IMapper _mapper;
        public SearchService(ElasticClientProvider provider,  IMapper mapper)
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
    }
}
