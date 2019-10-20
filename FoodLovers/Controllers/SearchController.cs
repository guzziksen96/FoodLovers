using FoodLovers.Infrastructure.Elastic;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace FoodLovers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly ElasticClient _elasticClient;

        public SearchController(ElasticClientProvider provider)
        {
            _elasticClient = provider.Client;
        }

        //[HttpPost]
        //[SwaggerOperation("ElasticSearch Index")]
        //public IActionResult Index(string query, ICollection<string> filters)
        //{
        //    var search = new SearchDescriptor<Recipe>()
        //        .Query(qu => qu
        //            .QueryString(queryString => queryString
        //                .Query(query)));

        //    var result = _elasticClient.Search<Recipe>(search);

        //    return Ok(result);
        //}
    }
}