using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using testSibers.Controllers.Commands.Tasks.Validation;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Tasks.UpdateTask;

//Команда для изменения информации задачи
public class UpdateTaskCommand: IRequest, ITaskUpdateCommand
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public Guid CreatorId { get; init; }
    
    public Guid? AssigneeId { get; init; }
    
    public StatusType Status { get; init; }
    
    public string Comment { get; init; }
    
    public int Priority { get; init; }
    
    public int TaskProjectId { get; init; }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ISystemDbContext _systemDbContext;

        private readonly TaskUpdateCommandValidator _validator;

        public UpdateProjectCommandHandler(ISystemDbContext systemDbContext, TaskUpdateCommandValidator validator)
        {
            _systemDbContext = systemDbContext;
            _validator = validator;
        }

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateOrThrow(request);
            
            var task = await _systemDbContext.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            
            if (task is null)
            {
                throw new EntityNotFoundException("Задача не найдена");
            }

            var creator = await _systemDbContext.Users.FindAsync(request.CreatorId);
            
            if (creator is null)
            {
                throw new EntityNotFoundException("Автор задачи не найден");
            }
            
            var assignee = await _systemDbContext.Users.FindAsync(request.AssigneeId);
            
            var project = await _systemDbContext.Projects.FindAsync(request.TaskProjectId);
            
            if (project is null)
            {
                throw new EntityNotFoundException("Проект не найден");
            }
            

            task.UpdateTask(
                request.Name,
                creator,
                assignee,
                (Models.EntityTypes.StatusType)request.Status,
                request.Comment,
                request.Priority,
                project
            );

            await _systemDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}