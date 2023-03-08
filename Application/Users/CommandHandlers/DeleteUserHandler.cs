using Application.Abstractions;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.CommandHandlers;

public class DeleteUserHandler : IRequestHandler<DeleteUser>
{
    private readonly IUserRepository _repository;

    public DeleteUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
    {
        await _repository.DeleteUser(request.Id);
        return Unit.Value;
    }
}