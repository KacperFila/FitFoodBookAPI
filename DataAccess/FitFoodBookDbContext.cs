using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class FitFoodBookDbContext : DbContext
{
    public FitFoodBookDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public virtual DbSet<User?> Users { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<IngredientTag> IngredientTags { get; set; }
    public virtual DbSet<RecipeTag> RecipeTags { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Ingredient_IngredientTag> IngredientIngredientTags { get; set; }
    public virtual DbSet<Recipe_Ingredient> RecipeIngredients { get; set; }
    public virtual DbSet<Recipe_RecipeTag> RecipeRecipeTags { get; set; }
}