using Bogus;
using Domain.Entities;

namespace DataAccess.Seeders;

public static class DataSeeder
{
    public static void Seed(FitFoodBookDbContext context)
    {

            var recipeTagGenerator = new Faker<RecipeTag>()
                .RuleFor(rt => rt.Name, rt => rt.Lorem.Sentence(new Random().Next(1, 2)));

            var ingredientTagGenerator = new Faker<IngredientTag>()
                .RuleFor(rt => rt.Name, rt => rt.Lorem.Sentence(new Random().Next(1, 2)));

            var ingredientGenerator = new Faker<Ingredient>()
                .RuleFor(i => i.Name, i => i.Lorem.Sentence(new Random().Next(1, 3)))
                .RuleFor(i => i.Proteins, i => i.Random.Number(10, 50))
                .RuleFor(i => i.Carbohydrates, r => r.Random.Number(10, 50))
                .RuleFor(i => i.Fats, i => i.Random.Number(10, 50))
                .RuleFor(i => i.IngredientTags, i => ingredientTagGenerator.Generate(new Random().Next(1, 3)));

            var recipeGenerator = new Faker<Recipe>()
                .RuleFor(r => r.Name, r => r.Lorem.Sentence(new Random().Next(2, 5)))
                .RuleFor(r => r.TimeOfPreparing, r => r.Random.Number(15, 90))
                .RuleFor(r => r.Calories, r => r.Random.Number(500, 1200))
                .RuleFor(r => r.Proteins, r => r.Random.Number(10, 50))
                .RuleFor(r => r.Carbohydrates, r => r.Random.Number(10, 50))
                .RuleFor(r => r.Fats, r => r.Random.Number(10, 50))
                .RuleFor(r => r.AmountOfServings, r => r.Random.Number(1, 4))
                .RuleFor(r => r.Ingredients, r => ingredientGenerator.Generate(new Random().Next(5, 8)))
                .RuleFor(r => r.RecipeTags, r => recipeTagGenerator.Generate(new Random().Next(1, 5)));
        
            var userGenerator = new Faker<User>()
                .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                .RuleFor(u => u.LastName, u => u.Name.LastName())
                .RuleFor(u => u.DateOfBirth, u => u.Date.Past())
                .RuleFor(u => u.Email, u => u.Person.Email)
                .RuleFor(u => u.Recipes, u => recipeGenerator.Generate(new Random().Next(4, 8)));

            var users = userGenerator.Generate(10);
        
            context.AddRange(users);
            context.SaveChanges();
        
    }
}