using Application.Abstractions;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.CommandHandlers;

public class CreateUserHandler : IRequestHandler<CreateUser, User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };
        return await _userRepository.CreateUser(newUser);
    }
}