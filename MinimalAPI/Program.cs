using System.Reflection;
using Application.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using DataAccess.Seeders;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<FitFoodBookDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.MapGet("hello", (IMediator mediator) => "hello");

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<FitFoodBookDbContext>();
DataSeeder.Seed(dbContext);

app.Run();