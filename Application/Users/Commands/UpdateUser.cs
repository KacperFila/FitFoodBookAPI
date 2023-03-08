using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class UpdateUser : IRequest<User>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public List<Recipe>? Recipes { get; set; } = new();
}