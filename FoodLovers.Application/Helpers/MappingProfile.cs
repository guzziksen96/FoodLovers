using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodLovers.Domain.Entities;
using RecipeScarper.Models;

namespace FoodLovers.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientModel>().ReverseMap();
            CreateMap<Domain.Entities.Recipe, RecipeModel>().ReverseMap();
        }

    }
}
