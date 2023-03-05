namespace Domain.Entities;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string TimeOfPreparing { get; set; }
    public string Calories { get; set; }
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fats { get; set; }
    public string AmountOfServings { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid UserId { get; set; }
    public User Author { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    
    public List<RecipeTag>? RecipeTags { get; set; }
}