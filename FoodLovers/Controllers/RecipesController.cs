using System.Threading.Tasks;
using FoodLovers.Application.Scraper.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodLovers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : BaseController
    {
        [HttpPost]
        [SwaggerOperation("Add recipes and ingredients to the database by scrapping the website.")]

        public async Task<ActionResult<int>> ScrapRecipes()
        {
            var command = new ScrapRecipesCommand();
            return Ok(await Mediator.Send(command));
        }
    }
}
