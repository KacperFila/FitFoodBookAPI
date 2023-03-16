using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class Ingredient_IngredientTagConfiguration : IEntityTypeConfiguration<Ingredient_IngredientTag>
{
    public void Configure(EntityTypeBuilder<Ingredient_IngredientTag> builder)
    {
        builder.HasKey(iit => new { iit.IngredientId, iit.IngredientTagId });
    }
}