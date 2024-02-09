using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testSibers.Models.Entities;

namespace testSibers.Models.Configurations;

//Конфигурация refresh token для базы данных
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>   
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(r => r.Id); 
    }
}