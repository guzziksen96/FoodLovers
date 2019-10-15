using Nest;

namespace FoodLovers.Application.Recipe.Models
{
    public class RecipeElasticModel
    {
        public string Name { get; set; }
        public CompletionField Suggest { get; set; }
    }
}
