using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class CreateUser : IRequest<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

}