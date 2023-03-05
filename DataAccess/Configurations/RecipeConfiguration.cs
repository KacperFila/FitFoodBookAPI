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
        
        //MANY TO MANY z RecipeTag
        builder.HasMany(x => x.RecipeTags)
            .WithMany(c => c.Recipes)
            .UsingEntity<RecipeRecipeTag>(
                x => x.HasOne(c => c.RecipeTag)
                    .WithMany()
                    .HasForeignKey(v => v.RecipeTagId),
                x => x.HasOne(c => c.Recipe)
                    .WithMany()
                    .HasForeignKey(v => v.RecipeTagId),
                x => x.HasKey(c => new{ c.RecipeId, c.RecipeTagId})
                );
    }
};