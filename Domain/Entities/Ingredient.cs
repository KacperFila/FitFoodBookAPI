namespace Domain.Entities;

public class Ingredient
{
    public Guid Id { get; set; }
    public string Name;
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fats { get; set; }
    public List<IngredientTag>? IngredientTags { get; set; } //moze byc nullable?
    public List<Recipe>? Recipes { get; set; } //moze byc nullable?
}