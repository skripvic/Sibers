using Microsoft.EntityFrameworkCore;
using testSibers.Models.Entities;
using Task = testSibers.Models.Entities.Task;

namespace testSibers.Models;

//Интерфейс контекста бд
public interface ISystemDbContext
{
    DbSet<User> Users { get; }
    
    DbSet<Role> Roles { get; }
    
    DbSet<RefreshToken> RefreshTokens { get; }
    
    DbSet<Project> Projects { get; }
    
    DbSet<Task> Tasks { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}