using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class FitFoodBookDbContext : DbContext
{
    public FitFoodBookDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientTag> IngredientTags { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
    public DbSet<IngredientIngredientTag> IngredientIngredientTags { get; set; }
    public DbSet<RecipeRecipeTag> RecipeRecipeTags { get; set; }
    
}