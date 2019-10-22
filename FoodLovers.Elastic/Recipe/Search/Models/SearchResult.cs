using System;
using System.Collections.Generic;
using System.Text;

namespace FoodLovers.Elastic.Recipe.Search.Models
{
    public class SearchResult
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public IEnumerable<RecipeSearchModel> Results { get; set; }
        public int ElapsedMilliseconds { get; set; }
    }
}
