using System.Text.Json.Serialization;
using Application.Abstractions;
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
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
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
        DateOfBirth = user.DateOfBirth
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
    var userToGet = new GetUser(id);
    
    var result = await mediator.Send(userToGet);
    return Results.Ok(result);
});

app.MapDelete("user/{id:guid}", async (IMediator mediator, Guid id) =>
{
    var userToDelete = new DeleteUser { Id = id };
    await mediator.Send(userToDelete);
    return Results.NoContent();
});

app.MapGet("recipe/{id:Guid}", async (IMediator mediator, Guid id) =>
{
    var recipe = new GetRecipeByIdQuery(id);
    var result = await mediator.Send(recipe);
    return Results.Ok(result);
});

app.MapGet("recipeWithoutMacros/{id:Guid}", async (IMediator mediator, Guid id) =>
{
    var recipe = new GetRecipeWithoutMacrosByIdQuery(id);
    var result = await mediator.Send(recipe);
    return Results.Ok(result);
});

app.MapGet("recipes", async (IMediator mediator) =>
{
    var recipes = new GetAllRecipesQuery();
    var result = await mediator.Send(recipes);
    return Results.Ok(result);
});
app.Run();