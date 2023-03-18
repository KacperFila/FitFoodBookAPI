using Application.Recipes.Dtos;
using MediatR;

namespace Application.Recipes.Queries;

public class GetRecipeByIdQuery : GetRecipeDto, IRequest<GetRecipeDto>
{
    public Guid Id;
    
    public GetRecipeByIdQuery(Guid id)
    {
        Id = id;
    }
}