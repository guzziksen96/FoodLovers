using System.Collections.Generic;

namespace FoodLovers.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Directions { get; set; }
        public string PreparationTimeInMinutes { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
