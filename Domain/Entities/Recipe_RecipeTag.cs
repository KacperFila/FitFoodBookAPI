namespace Domain.Entities;

public class Recipe_RecipeTag
{
    public Guid Id { get; set; }
    public Recipe Recipe { get; set; }
    public Guid RecipeId { get; set; }
    public RecipeTag RecipeTag { get; set; }
    public Guid RecipeTagId { get; set; }
}