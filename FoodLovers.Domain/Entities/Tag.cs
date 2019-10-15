using System.Collections.Generic;

namespace FoodLovers.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
