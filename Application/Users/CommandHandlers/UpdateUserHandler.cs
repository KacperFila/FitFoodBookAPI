using Application.Abstractions;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.Identity.Client;

namespace Application.Users.CommandHandlers;

public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
{
    private readonly IUserRepository _repository;

    public UpdateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var userToUpdate = new User
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Recipes = request.Recipes
        };
        var result = _repository.UpdateUser(userToUpdate, userToUpdate.Id);
        return result;
    }
}