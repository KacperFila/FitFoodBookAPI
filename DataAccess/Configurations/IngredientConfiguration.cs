using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(x => x.Proteins)
            .IsRequired();

        builder.Property(x => x.Carbohydrates)
            .IsRequired();

        builder.Property(x => x.Fats)
            .IsRequired();

        builder.HasMany(r => r.IngredientTags)
            .WithMany(rt => rt.Ingredients)
            .UsingEntity<Ingredient_IngredientTag>(
                iit => iit.HasOne(iit => iit.IngredientTag)
                    .WithMany()
                    .HasForeignKey(iit => iit.IngredientTagId),
                iit => iit.HasOne(iit => iit.Ingredient)
                    .WithMany()
                    .HasForeignKey(iit => iit.IngredientId),
                iit => iit.HasKey(iit => new { iit.IngredientId, iit.IngredientTagId })
            );
    }
}