﻿using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands;

public class CreateRecipeCommand : IRequest
{
    public string Name { get; set; }
    public int TimeOfPreparing { get; set; }
    public int Calories { get; set; }
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fats { get; set; }
    public int AmountOfServings { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<RecipeTag?> RecipeTags { get; set; }
}