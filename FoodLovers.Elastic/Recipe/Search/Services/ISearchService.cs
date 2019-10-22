﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLovers.Elastic.Recipe.Search.Models;

namespace FoodLovers.Elastic.Recipe.Search.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<RecipeSearchModel>> SearchAsync(string indexName, string query);

        Task<bool> CreateIndexAsync(string indexName);
        //Task<SearchResult> SearchAsync2(string query, int page, int pageSize);
    }
}
