using Application.Abstractions;
using Application.Recipes.Commands;
using Azure.Core;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.CommandHandlers;

public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe, Recipe>
{
    private readonly IRecipeRepository _repository;

    public UpdateRecipeHandler(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public Task<Recipe> Handle(UpdateRecipe request, CancellationToken cancellationToken)
    {
        var updatedRecipe = new Recipe
        {
            Id = request.Id,
            Name = request.Name,
            TimeOfPreparing = request.TimeOfPreparing,
            Calories = request.Calories,
            Proteins = request.Proteins,
            Carbohydrates = request.Carbohydrates,
            Fats = request.Fats,
            AmountOfServings = request.AmountOfServings,
            AddedDate = request.AddedDate,
            ModifiedDate = DateTime.Now,
            Ingredients = request.Ingredients,
            RecipeTags = request.RecipeTags,
            User = request.User,
            UserId = request.UserId
        };

        return _repository.UpdateRecipe(request.Id, updatedRecipe);
    }
}