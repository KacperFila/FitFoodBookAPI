using Application.Abstractions;
using Application.Users.Dtos;
using Application.Users.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetUserHandler : IRequestHandler<GetUser, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUser request, CancellationToken cancellationToken)
    {
        return  _mapper.Map<UserDto>(await _repository.GetUser(request.Id));
    }
}