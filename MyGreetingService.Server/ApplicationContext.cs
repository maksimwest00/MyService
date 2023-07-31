using Microsoft.EntityFrameworkCore;

namespace MyGreetingService.Server;

public class ApplicationContext : DbContext
{
    public DbSet<WorkerMessage> Workers { get; set; }
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=avecoder;Username=postgres;Password=maksim22");
    }
}