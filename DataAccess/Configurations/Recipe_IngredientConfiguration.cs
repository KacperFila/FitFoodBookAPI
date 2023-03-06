using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class Recipe_IngredientConfiguration : IEntityTypeConfiguration<Recipe_Ingredient>
{
    public void Configure(EntityTypeBuilder<Recipe_Ingredient> builder)
    {
       // builder.HasKey(ri => new { ri.IngredientId, ri.RecipeId });
    }
}