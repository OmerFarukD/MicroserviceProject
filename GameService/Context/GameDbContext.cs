using GameService.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameService.Context;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions opt) : base(opt)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}