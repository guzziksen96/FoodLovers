using System;
using System.Collections.Generic;
using System.Text;

namespace FoodLovers.Elastic.Recipe.Search.Models
{
    public class RecipeSearchModel
    {
        public string Name { get; set; }
        public string Directions { get; set; }
        public string Tag { get; set; }
        public IEnumerable<string> Ingredients { get; set; }

    }
}
