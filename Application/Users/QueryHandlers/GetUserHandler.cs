using Application.Abstractions;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetUserHandler : IRequestHandler<GetUser, User>
{
    private readonly IUserRepository _repository;

    public GetUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(GetUser request, CancellationToken cancellationToken)
    {
        return await _repository.GetUser(request.Id);
    }
}