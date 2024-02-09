using MediatR;
using testSibers.Controllers.Commands.Tasks.Validation;
using testSibers.Controllers.Exceptions;
using testSibers.Models;
using Task = testSibers.Models.Entities.Task;

namespace testSibers.Controllers.Commands.Tasks.CreateTask;

//Команда для создания задачи
public class CreateTaskCommand: IRequest<CreateTaskResponse>, ITaskUpdateCommand
{
    public string Name { get; init; }
    
    public Guid CreatorId { get; init; }
    
    public Guid? AssigneeId { get; init; }
    
    public StatusType Status { get; init; }
    
    public string Comment { get; init; }
    
    public int Priority { get; init; }
    
    public int TaskProjectId { get; init; }
    
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        private readonly TaskUpdateCommandValidator _validator;
        
        public CreateTaskCommandHandler(ISystemDbContext systemDbContext, TaskUpdateCommandValidator validator)
        {
            _systemDbContext = systemDbContext;
            _validator = validator;
        }

        public async Task<CreateTaskResponse> Handle(CreateTaskCommand request,
            CancellationToken cancellationToken)
        {
            _validator.ValidateOrThrow(request);
            
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

            var newTask = new Task(
                request.Name,
                creator,
                assignee,
                (Models.EntityTypes.StatusType)request.Status,
                request.Comment,
                request.Priority,
                project
                );

            _systemDbContext.Tasks.Add(newTask);
            await _systemDbContext.SaveChangesAsync(cancellationToken);

            return new CreateTaskResponse()
            {
                Id = newTask.Id
            };
        }
    }
}