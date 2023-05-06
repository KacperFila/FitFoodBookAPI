using Application.Abstractions;
using Application.Recipes.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.CommandHandlers;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    public CreateRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Unit> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = new Recipe()
        {
            Name = request.Name,
            TimeOfPreparing = request.TimeOfPreparing,
            Calories = request.Calories,
            Proteins = request.Proteins,
            Carbohydrates = request.Carbohydrates,
            Fats = request.Fats,
            AmountOfServings = request.AmountOfServings,
            UserId = request.UserId,
            Ingredients = request.Ingredients,
            RecipeTags = request.RecipeTags
        };

        await _recipeRepository.CreateRecipe(recipe);
        return await Task.FromResult(Unit.Value);
    }
}