namespace Domain.Entities;

public class IngredientTag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Ingredient>? Ingredients { get; set; }
    public Guid? IngredientId { get; set; }
}