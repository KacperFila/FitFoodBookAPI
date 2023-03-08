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
        return await _context.Recipes.Include(r => r.RecipeTags).Include(r => r.Ingredients).FirstOrDefaultAsync(r => r.Id == id);
        
    }

    public async Task<Recipe> CreateRecipe(Recipe recipe)
    {
        await _context.AddAsync(recipe);
        await _context.SaveChangesAsync();
        return recipe;
    }

    public Task<Recipe> UpdateRecipe(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> DeleteRecipe(Guid id)
    {
        throw new NotImplementedException();
    }
}