using Application.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<FitFoodBookDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

app.Run();