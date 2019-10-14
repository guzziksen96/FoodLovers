using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLovers.Application.Recipe.Models;
using MediatR;

namespace FoodLovers.Application.Recipe.Queries
{
    public class RecipeSuggestQuery : IRequest<RecipeSuggestResponse>
    {
        public string Keyword { get; set; }
    }
}
