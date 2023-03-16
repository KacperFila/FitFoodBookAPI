using Domain.Entities;
using MediatR;

namespace Application.Abstractions;

public interface IRecipeRepository
{
    Task<List<Recipe>?> GetRecipes();
    Task<Recipe?> GetRecipeById(Guid id);
    Task<Recipe> CreateRecipe(Recipe recipe);
    Task<Recipe> UpdateRecipe(Guid id, Recipe recipe);
    Task<Unit> DeleteRecipe(Guid id);
}