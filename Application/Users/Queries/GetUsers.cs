using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetUsers : IRequest<List<User>>, IRequest<User>
{
}