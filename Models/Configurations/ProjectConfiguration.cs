using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testSibers.Models.Entities;
using testSibers.Models.EntityTypes;

namespace testSibers.Models.Configurations;

//Конфигурация проекта для базы данных
public class ProjectConfiguration: IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");
        
        builder.HasKey(p => p.Id);
        
        builder
            .HasMany(p => p.Users)
            .WithMany(u => u.Projects)
            .UsingEntity(cfg => cfg.ToTable("UserProjects"));
        
        builder
            .HasOne(p => p.Manager)
            .WithMany();
        
        builder
            .Property(p => p.Name)
            .HasMaxLength(EntityConstants.Projects.Name.Max);
       
        builder
            .Property(p => p.ClientCompany)
            .HasMaxLength(EntityConstants.Projects.ClientCompany.Max);
        
        builder
            .Property(p => p.ContractorCompany)
            .HasMaxLength(EntityConstants.Projects.ContractorCompany.Max);
    }
}