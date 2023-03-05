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

        //MANY TO MANY z IngredientTag
        builder.HasMany(x => x.IngredientTags)
            .WithMany(x => x.Ingredients)
            .UsingEntity<IngredientIngredientTag>(
                
                x => x.HasOne(c => c.IngredientTag)
                    .WithMany()
                    .HasForeignKey(v => v.IngredientTagId),
                
                x => x.HasOne(c => c.Ingredient)
                    .WithMany()
                    .HasForeignKey(v => v.IngredientId),
                
                x => x.HasKey(c => new {c.IngredientId, c.IngredientTagId})
            );
        
        //MANY TO MANY z Recipe
        builder.HasMany(x => x.Recipes)
            .WithMany(x => x.Ingredients)
            .UsingEntity<IngredientRecipe>(
                x => x.HasOne(c => c.Recipe)
                    .WithMany()
                    .HasForeignKey(v => v.RecipeId),
                
                x => x.HasOne(c => c.Ingredient)
                    .WithMany()
                    .HasForeignKey(v => v.IngredientId),
                
                x => x.HasKey(c => new {c.IngredientId, c.RecipeId})
            );
    }
}