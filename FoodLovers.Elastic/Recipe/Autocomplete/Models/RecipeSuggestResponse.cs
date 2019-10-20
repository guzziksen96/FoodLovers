using System.Collections.Generic;

namespace FoodLovers.Elastic.Recipe.Autocomplete.Models
{
    public class RecipeSuggestResponse
    {
        public IEnumerable<RecipeSuggest> Suggests { get; set; }
    }
    public class RecipeSuggest
    {
        public string Name { get; set; }
        public double Score { get; set; }
    }
}
