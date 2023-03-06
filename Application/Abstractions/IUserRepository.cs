using Domain.Entities;

namespace Application.Abstractions;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(Guid id);
    Task<User> CreateUser(User user);
}