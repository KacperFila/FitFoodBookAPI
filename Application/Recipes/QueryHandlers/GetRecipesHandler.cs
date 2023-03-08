using Application.Abstractions;
using Application.Recipes.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.QueryHandlers;

public class GetRecipesHandler : IRequestHandler<GetRecipes, List<Recipe>?>
{
    private readonly IRecipeRepository _repository;

    public GetRecipesHandler(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Recipe>?> Handle(GetRecipes request, CancellationToken cancellationToken)
    {
        return await _repository.GetRecipes();
    }
}