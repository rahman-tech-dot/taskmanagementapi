using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        // In AppDbContext.cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>().HasData(
        new User 
        { 
            Id = 1, 
            Username = "admin", 
            Password = "admin123", 
            Role = "Admin" 
        },
        new User 
        { 
            Id = 2, 
            Username = "user1", 
            Password = "user123", 
            Role = "User" 
        }
    );
}
    }
}