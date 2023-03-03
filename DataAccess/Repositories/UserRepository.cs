using Application.Abstractions;
using Domain.Entities;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FitFoodBookDbContext _context;

    public UserRepository(FitFoodBookDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> CreateUser(User user)
    {
        _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
    }
        
    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

}