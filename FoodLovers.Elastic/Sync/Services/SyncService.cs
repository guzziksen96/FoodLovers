﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Elastic.Recipe.Search.Models;
using FoodLovers.Infrastructure.Elastic;
using FoodLovers.Persistence;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace FoodLovers.Elastic.Sync.Services
{
    public class SyncService : ISyncService
    {
        private readonly ElasticClient _elasticClient;
        private IMapper _mapper;
        private readonly FoodLoversDbContext _dbContext;
        private readonly string indexName = "recipes";
        public SyncService(ElasticClientProvider provider, IMapper mapper, FoodLoversDbContext dbContext)
        {
            _elasticClient = provider.Client;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task SyncData()
        {
            //1290213 = 13x100000
            for(int i = 1; i < 14; i++)
            {
                var recepies = await _dbContext
                .Recipes.Where(r => r.Id <= 100000*i && r.Id > 100000*(i-1))
                .Include(r => r.Ingredients)
                .Include(r => r.RecipeTag)
                .ThenInclude(rt => rt.Tag)
                .ToListAsync();

                var recepiesEsModel = _mapper.Map<List<RecipeSearchModel>>(recepies);

                var request = new BulkRequest(indexName)
                {
                    Operations = new List<IBulkOperation>()
                };

                var bulkOperations = recepiesEsModel.Select(r => new BulkIndexOperation<RecipeSearchModel>(r));
                request.Operations.AddRange(bulkOperations);

                await _elasticClient.BulkAsync(request);
            }
           
            
            Console.WriteLine("Sync completed");
        }


    }
}
