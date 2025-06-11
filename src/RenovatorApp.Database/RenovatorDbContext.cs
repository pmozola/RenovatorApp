using Microsoft.EntityFrameworkCore;
using RenovatorApp.Domain;

namespace RenovatorApp.Database;

public class RenovatorDbContext(DbContextOptions<RenovatorDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
}