using Application.Recipes.Dtos;
using MediatR;

namespace Application.Recipes.Queries;

public class GetAllRecipesQuery : GetRecipeDto, IRequest<List<GetRecipeDto>>
{
    
}