using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace FoodLovers.Application.Interfaces
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
