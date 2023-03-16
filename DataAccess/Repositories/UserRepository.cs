using Application.Abstractions;
using Application.Users.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FitFoodBookDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(FitFoodBookDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<User> CreateUser(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserDto?> GetUser(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        var userdto = _mapper.Map<UserDto>(user);
        return userdto;
    }

    public async Task<List<User?>> GetUsers()
    {
        return await _context.Users.ToListAsync();
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