using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace FoodLovers.Application.Recipe.Models
{
    public class RecipeElasticModel
    {
        public string Name { get; set; }
        public CompletionField Suggest { get; set; }
    }
}
