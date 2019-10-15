using AutoMapper;

namespace FoodLovers.Application.Interfaces
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
