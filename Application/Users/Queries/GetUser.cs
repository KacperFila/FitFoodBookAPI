using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetUser : IRequest<User>
{
    public Guid Id { get; set; }

}