using Application.Abstractions;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetUsersHandler : IRequestHandler<GetUsers, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User?>> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUsers();
    }
}