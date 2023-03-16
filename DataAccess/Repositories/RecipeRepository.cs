using Application.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly FitFoodBookDbContext _context;

    public RecipeRepository(FitFoodBookDbContext context)
    {
        _context = context;
    }

    public async Task<List<Recipe>?> GetRecipes()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task<Recipe?> GetRecipeById(Guid id)
    {
        return await _context.Recipes.Include(r => r.RecipeTags).Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Recipe> CreateRecipe(Recipe recipe)
    {
        await _context.AddAsync(recipe);
        await _context.SaveChangesAsync();
        return recipe;
    }

    public async Task<Recipe> UpdateRecipe(Guid id, Recipe recipe)
    {
        throw new NotImplementedException();
        // var recipeToUpdate = await _context.Recipes.Include(r => r.RecipeTags).Include(r => r.Ingredients).FirstOrDefaultAsync(r => r.Id == id);
        // if (recipeToUpdate is null) throw new Exception($"User with id {id} was not found.");
        // recipeToUpdate.RecipeTags = recipe.RecipeTags;
        // recipeToUpdate.Ingredients = recipe.Ingredients;
        // recipeToUpdate.UserId = recipe.UserId;
        // recipeToUpdate.Carbohydrates = recipe.Carbohydrates;
        // recipeToUpdate.Calories = recipe.Calories;
        // recipeToUpdate.Fats = recipe.Fats;
        // recipeToUpdate.Name = recipe.Name;
        // recipeToUpdate.Proteins = recipe.Proteins;
        // recipeToUpdate.User = recipe.User;
        // recipeToUpdate.AmountOfServings = recipe.AmountOfServings;
        // recipeToUpdate.AddedDate = recipe.AddedDate;
        // recipeToUpdate.ModifiedDate = DateTime.Now;
        // recipeToUpdate.TimeOfPreparing = recipe.TimeOfPreparing;
        //
        // await _context.AddAsync(recipeToUpdate);
        // return recipeToUpdate;
    }


    public Task<Unit> DeleteRecipe(Guid id)
    {
        throw new NotImplementedException();
    }
}