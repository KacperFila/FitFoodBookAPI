using Application.Users.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetUser : IRequest<UserDto>
{
    public Guid Id { get; set; }

    public GetUser(Guid id)
    {
        Id = id;
    }

}