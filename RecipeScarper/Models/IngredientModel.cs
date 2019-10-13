using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeScarper.Models
{
    public class IngredientModel
    {
        public IngredientModel() {}
        public IngredientModel(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
