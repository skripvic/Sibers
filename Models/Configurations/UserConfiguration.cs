using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testSibers.Models.Entities;
using testSibers.Models.EntityTypes;

namespace testSibers.Models.Configurations;

//Конфигурация сотрудника для базы данных
public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(EntityConstants.User.FirstName.Max);

        builder
            .Property(u => u.LastName)
            .HasMaxLength(EntityConstants.User.LastName.Max);
        
        builder
            .Property(u => u.LastName)
            .HasMaxLength(EntityConstants.User.LastName.Max);
        
        builder
            .Property(u => u.MiddleName)
            .HasMaxLength(EntityConstants.User.MiddleName.Max);

        builder
            .Property(u => u.Email)
            .HasMaxLength(EntityConstants.User.Email.Max);

        builder
            .HasMany(u => u.RefreshTokens)
            .WithOne(r => r.Owner);

        builder.HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity<UserRole>(cfg =>
            {
                cfg.ToTable("UserRoles");
                cfg.HasKey(x => new { x.RoleId, x.UserId });
            });
    }
}