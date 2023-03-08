using Application.Abstractions;
using Application.Recipes.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.CommandHandlers;

public class CreateRecipeHandler : IRequestHandler<CreateRecipe, Recipe>
{
    private readonly IRecipeRepository _repository;

    public CreateRecipeHandler(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Recipe> Handle(CreateRecipe request, CancellationToken cancellationToken)
    {
        var recipe = new Recipe
        {
            Id = request.Id,
            Name = request.Name,
            TimeOfPreparing = request.TimeOfPreparing,
            AddedDate = request.AddedDate,
            ModifiedDate = request.ModifiedDate,
            UserId = request.UserId,
            User = request.User,
            Ingredients = request.Ingredients,
            RecipeTags = request.RecipeTags,
            AmountOfServings = request.AmountOfServings,
            Calories = request.Calories,
            Proteins = request.Proteins,
            Carbohydrates = request.Carbohydrates,
            Fats = request.Fats
        };
        return await _repository.CreateRecipe(recipe);
    }
}