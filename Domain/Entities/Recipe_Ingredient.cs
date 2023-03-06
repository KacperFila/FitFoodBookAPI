namespace Domain.Entities;

public class Recipe_Ingredient
{
    public Recipe Recipe { get; set; }
    public Guid RecipeId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Guid IngredientId { get; set; }
}