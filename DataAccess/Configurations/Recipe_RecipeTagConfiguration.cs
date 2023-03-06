using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class Recipe_RecipeTagConfiguration : IEntityTypeConfiguration<Recipe_RecipeTag>
{
    public void Configure(EntityTypeBuilder<Recipe_RecipeTag> builder)
    {
      //  builder.HasKey(rrt => new { rrt.RecipeId, rrt.RecipeTagId });
    }
}