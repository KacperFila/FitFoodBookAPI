﻿using Domain.Entities;

namespace Application.Users.Dtos;

public class UserDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public List<string> RecipesNames { get; } = null!;
}