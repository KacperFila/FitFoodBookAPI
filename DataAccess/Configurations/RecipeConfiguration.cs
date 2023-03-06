using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Calories)
            .IsRequired();

        builder.Property(x => x.Carbohydrates)
            .IsRequired();

        builder.Property(x => x.Proteins)
            .IsRequired();

        builder.Property(x => x.Fats)
            .IsRequired();

        builder.Property(x => x.TimeOfPreparing)
            .IsRequired();

        builder.Property(x => x.AmountOfServings)
            .IsRequired();

        builder.Property(x => x.AddedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.ModifiedDate)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("GETDATE()");

        builder.HasMany(r => r.Ingredients)
            .WithMany(i => i.Recipes)
            .UsingEntity<Recipe_Ingredient>(
                ri => ri.HasOne(ri => ri.Ingredient)
                    .WithMany()
                    .HasForeignKey(ri => ri.IngredientId),
                ri => ri.HasOne(ri => ri.Recipe)
                    .WithMany()
                    .HasForeignKey(ri => ri.RecipeId),
                ri => ri.HasKey(ri => new { ri.IngredientId, ri.RecipeId })
            );

        builder.HasMany(r => r.RecipeTags)
            .WithMany(rt => rt.Recipes)
            .UsingEntity<Recipe_RecipeTag>(
                rrt => rrt.HasOne(rrt => rrt.RecipeTag)
                    .WithMany()
                    .HasForeignKey(rrt => rrt.RecipeTagId),
                rrt => rrt.HasOne(rrt => rrt.Recipe)
                    .WithMany()
                    .HasForeignKey(rrt => rrt.RecipeId),
                rrt => rrt.HasKey(rrt => new { rrt.RecipeId, rrt.RecipeTagId })
            );
    }
}