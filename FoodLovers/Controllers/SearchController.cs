using System.Collections.Generic;
using System.Threading.Tasks;
using FoodLovers.Domain.Entities;
using FoodLovers.Elastic.Recipe.Search.Services;
using FoodLovers.Infrastructure.Elastic;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodLovers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost("/index")]
        [SwaggerOperation("Create ElasticSearch Index")]
        public async Task<IActionResult> CreateIndex()
        {
            var indexName = "recipes";
            var result = await _searchService.CreateIndexAsync(indexName);
            return Ok(result);
        }
    }
}