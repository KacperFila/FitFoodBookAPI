namespace Domain.Entities;

public class User
{
    public Guid Id { get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public List<Recipe> Recipes { get; set; } = new List<Recipe>();
}