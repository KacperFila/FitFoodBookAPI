﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.HasMany(u => u.Recipes)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId);
    }
}