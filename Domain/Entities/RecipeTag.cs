namespace Domain.Entities;

public class RecipeTag
{
    public Guid Id { get; set;}
    public string Name { get; set; }
    public List<Recipe>? Recipes { get; set; }
}