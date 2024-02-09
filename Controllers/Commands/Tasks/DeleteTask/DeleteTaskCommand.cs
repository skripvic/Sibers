using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Tasks.DeleteTask;

//Команда для удаления задачи
public class DeleteTaskCommand: IRequest
{
    public DeleteTaskCommand(int taskId)
    {
        TaskId = taskId;
    }

    private int TaskId { get; init; }
    
    public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        public DeleteTaskCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {

            var tasks = await _systemDbContext.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);

            if (tasks is null)
            {
                throw new EntityNotFoundException("Задача не найдена");
            }
            
            _systemDbContext.Tasks.Remove(tasks);

            await _systemDbContext.SaveChangesAsync(cancellationToken);

        }
    }
}