using Domain.Entities;

namespace Application.Recipes.Dtos;

public class GetRecipeWithoutMacrosDto
{
    public string Name { get; set; }
    public int TimeOfPreparing { get; set; }
    public int AmountOfServings { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<RecipeTag?> RecipeTags { get; set; }
}