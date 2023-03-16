using Application.Users.Dtos;
using Domain.Entities;

namespace Application.Abstractions;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<List<User?>> GetUsers();
    Task<User> UpdateUser(User user, Guid id);

    Task DeleteUser(Guid id);
}