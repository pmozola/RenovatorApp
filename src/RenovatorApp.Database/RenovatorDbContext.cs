using Microsoft.EntityFrameworkCore;
using RenovatorApp.Domain;

namespace RenovatorApp.Database;

public class RenovatorDbContext(DbContextOptions<RenovatorDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<ShopListItem> ShopListItems { get; set; }
}

public interface IRenovatorDbContext
{
    public DbSet<ShopListItem> ShopListItems { get; set; }
}