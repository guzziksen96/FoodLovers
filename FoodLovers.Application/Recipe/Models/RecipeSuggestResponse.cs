using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLovers.Application.Recipe.Models
{
    public class RecipeSuggestResponse
    {
        public IEnumerable<RecipeSuggest> Suggests { get; set; }
    }
    public class RecipeSuggest
    {
        public string Name { get; set; }
        public double Score { get; set; }
    }
}
