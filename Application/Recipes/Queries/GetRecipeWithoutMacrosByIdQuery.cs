using MediatR;
using Application.Recipes.Dtos;

namespace Application.Recipes.Queries;

public class GetRecipeWithoutMacrosByIdQuery : IRequest<GetRecipeWithoutMacrosDto>
{
    public Guid Id;
    
    public GetRecipeWithoutMacrosByIdQuery(Guid id)
    {
        Id = id;
    }
}