using System;
using System.Collections.Generic;
using System.Text;

namespace FoodLovers.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
