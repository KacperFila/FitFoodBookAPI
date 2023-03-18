using Application.Recipes.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<Recipe, GetRecipeWithoutMacrosDto>();
        CreateMap<Recipe, GetRecipeDto>();
    }
}