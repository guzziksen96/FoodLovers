﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLovers.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Directions { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredient { get; set; }
        public ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
