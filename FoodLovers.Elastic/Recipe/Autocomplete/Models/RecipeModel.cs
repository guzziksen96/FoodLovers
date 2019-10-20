using Nest;

namespace FoodLovers.Elastic.Recipe.Autocomplete.Models
{
    public class RecipeModel
    {
       // [Text(Name = "name")]
        public string Name { get; set; }
        public CompletionField Suggest { get; set; }
    }
}
