using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class FitFoodBookDbContext : DbContext
{
    public FitFoodBookDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<IngredientTag> IngredientTags { get; set; }
    public virtual DbSet<RecipeTag> RecipeTags { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
}