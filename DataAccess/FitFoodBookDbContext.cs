using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class FitFoodBookDbContext : DbContext
{
    public FitFoodBookDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
}