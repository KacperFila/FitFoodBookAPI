namespace Domain.Entities;

public class RecipeRecipeTag
{
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public Guid RecipeTagId { get; set; }
    public RecipeTag RecipeTag { get; set; }
}