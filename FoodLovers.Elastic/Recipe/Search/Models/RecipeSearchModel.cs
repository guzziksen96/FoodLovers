﻿using System;
using System.Collections.Generic;
using System.Text;
using Nest;

namespace FoodLovers.Elastic.Recipe.Search.Models
{
    public class RecipeSearchModel
    {
        public string Name { get; set; }
        public string Directions { get; set; }
        public string Tags { get; set; }

        [Nested]
        public List<string> Ingredients { get; set; }

    }
}
