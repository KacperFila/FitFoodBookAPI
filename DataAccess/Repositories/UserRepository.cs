using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUser(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<User?>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        if (!users.Any()) throw new Exception("Users were not found!");
        return users!;
    }

    public async Task<User> UpdateUser(User user, Guid id)
    {
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (userToUpdate is null) throw new Exception($"User with id {id} was not found.");
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Email = user.Email;
        userToUpdate.DateOfBirth = user.DateOfBirth;
        userToUpdate.Recipes = user.Recipes;
        await _context.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task DeleteUser(Guid id)
    {
        var userToRemove = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (userToRemove is null) throw new Exception($"User with id {id} was not found!");
        _context.Remove(userToRemove);
        await _context.SaveChangesAsync();
    }
}