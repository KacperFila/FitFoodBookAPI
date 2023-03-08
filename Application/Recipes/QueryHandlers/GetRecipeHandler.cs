using Application.Abstractions;
using Application.Recipes.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.QueryHandlers;

public class GetRecipeHandler : IRequestHandler<GetRecipe, Recipe>
{
    private readonly IRecipeRepository _repository;

    public GetRecipeHandler(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Recipe> Handle(GetRecipe request, CancellationToken cancellationToken)
    {
        // var recipe = new Recipe
        // {
        //     Id = request.Id,
        //     Name = request.Name,
        //     TimeOfPreparing = request.TimeOfPreparing,
        //     Calories = request.Calories,
        //     Proteins = request.Proteins,
        //     Carbohydrates = request.Carbohydrates,
        //     Fats = request.Fats,
        //     AmountOfServings = request.AmountOfServings,
        //     AddedDate = request.AddedDate,
        //     ModifiedDate = request.ModifiedDate,
        //     Ingredients = request.Ingredients,
        //     RecipeTags = request.RecipeTags
        // };

        return (await _repository.GetRecipeById(request.Id))!;
    }
}