

using System.Collections.Generic;

namespace RecipeScarper.Models
{
    public class RecipeModel 
    {
        public string Name { get; set; }
        public string Directions { get; set; }
        public string PreparationTimeInMinutes { get; set; }
        public ICollection<IngredientModel> Ingredients { get; set; }

    }

}
