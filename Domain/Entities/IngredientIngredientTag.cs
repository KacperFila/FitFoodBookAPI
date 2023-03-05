namespace Domain.Entities;

public class IngredientIngredientTag
{
    public Ingredient Ingredient { get; set; }
    public Guid IngredientId { get; set; }
    public IngredientTag IngredientTag { get; set; }
    public Guid IngredientTagId { get; set; }
}