namespace Domain.Entities;

public class IngredientRecipe
{
    public Ingredient Ingredient { get; set; }
    public Guid IngredientId { get; set; }
    public Recipe Recipe { get; set; }
    public Guid RecipeId { get; set; }
}