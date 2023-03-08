using Application.Abstractions;
using Application.Users.Commands;
using Application.Users.Queries;
using DataAccess;
using DataAccess.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddDbContext<FitFoodBookDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(CreateUser));
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();


//using var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetService<FitFoodBookDbContext>();
//DataSeeder.Seed(dbContext);

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

app.Run();