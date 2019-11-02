using System.Linq;
using AutoMapper;
using FoodLovers.Domain.Entities;
using FoodLovers.Elastic.Recipe.Search.Models;
using Microsoft.EntityFrameworkCore.Internal;
using RecipeScarper.Models;

namespace FoodLovers.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientModel>()
                .ReverseMap();
            CreateMap<Domain.Entities.Recipe, RecipeModel>()
                .ReverseMap();

            //ES Models
            CreateMap<Domain.Entities.Recipe, RecipeSearchModel>()
                .ForMember(r => r.Tags, m => m.MapFrom(source => source.RecipeTag.Select(rt => rt.Tag.Name).Join(",")))
                .ForMember(r => r.Ingredients, m => m.MapFrom(source => source.Ingredients.ToList()));

            CreateMap<Ingredient, IngredientSearchModel>();
        }

    }
}
