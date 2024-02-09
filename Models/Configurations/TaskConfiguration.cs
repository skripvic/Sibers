using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testSibers.Models.EntityTypes;
using Task = testSibers.Models.Entities.Task;

namespace testSibers.Models.Configurations;

//Конфигурация задачи для базы данных
public class TaskConfiguration: IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Tasks");
        
        builder.HasKey(t => t.Id);
        
        builder
            .HasOne(p => p.Creator)
            .WithMany();
        
        builder
            .HasOne(p => p.Assignee)
            .WithMany();
        
        builder
            .HasOne(p => p.TaskProject)
            .WithMany();
        
        builder
            .Property(p => p.Name)
            .HasMaxLength(EntityConstants.Task.Name.Max);
       
        builder
            .Property(p => p.Comment)
            .HasMaxLength(EntityConstants.Task.Comment.Max);
        
    }
}