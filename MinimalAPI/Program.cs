using System.Text.Json.Serialization;
using Application.Abstractions;
using Application.Recipes.Commands;
using Application.Recipes.Queries;
using Application.Users.Commands;
using Application.Users.Queries;
using DataAccess;
using DataAccess.Repositories;
using DataAccess.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddDbContext<FitFoodBookDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(CreateUser));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<FitFoodBookDbContext>()!;
DataSeeder.Seed(dbContext);

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("user", async (IMediator mediator, User user) =>
{
    var userToCreate = new CreateUser
    {
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        DateOfBirth = user.DateOfBirth,
        Recipes = user.Recipes
    };
    var result = await mediator.Send(userToCreate);
    return Results.Ok(result);
});

app.MapPut("user/{id:guid}", async (IMediator mediator, User user, Guid id) =>
{
    var userToUpdate = new UpdateUser
    {
        Id = id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        DateOfBirth = user.DateOfBirth,
        Recipes = user.Recipes
    };
    var results = await mediator.Send(userToUpdate);
    return Results.Ok(results);
});

app.MapGet("users", async (IMediator mediator) =>
{
    var users = new GetUsers();
    return await mediator.Send(users);
});

app.MapGet("user/{id:guid}", async (IMediator mediator, Guid id) =>
{
    var userToGet = new GetUser { Id = id };
    var result = await mediator.Send(userToGet);
    return Results.Ok(result);
});

app.MapDelete("user/{id:guid}", async (IMediator mediator, Guid id) =>
{
    var userToDelete = new DeleteUser { Id = id };
    await mediator.Send(userToDelete);
    return Results.NoContent();
});

app.MapGet("recipes", async (IMediator mediator) =>
{
    var recipes = new GetRecipes();
    return await mediator.Send(recipes);
});

app.MapGet("recipe/{id:guid}", async (IMediator mediator, Guid id) =>
{
    var recipe = new GetRecipe { Id = id };
    return await mediator.Send(recipe);
});

app.MapPost("recipe", async (IMediator mediator, Recipe recipe) =>
{
    var recipeToCreate = new CreateRecipe
    {
        Id = recipe.Id,
        Name = recipe.Name,
        TimeOfPreparing = recipe.TimeOfPreparing,
        AddedDate = recipe.AddedDate,
        ModifiedDate = recipe.ModifiedDate,
        UserId = recipe.UserId,
        User = recipe.User,
        Ingredients = recipe.Ingredients,
        RecipeTags = recipe.RecipeTags,
        AmountOfServings = recipe.AmountOfServings,
        Calories = recipe.Calories,
        Proteins = recipe.Proteins,
        Carbohydrates = recipe.Carbohydrates,
        Fats = recipe.Fats
    };
    return await mediator.Send(recipeToCreate);
});
app.Run();