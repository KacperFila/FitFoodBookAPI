namespace Domain.Entities;

public class Ingredient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fats { get; set; }
    public List<Recipe>? Recipes { get; set; }
    public List<IngredientTag>? IngredientTags { get; set; }
}