using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class DeleteUser : IRequest<Unit>
{
    public Guid Id { get; set; }
}