using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Tasks.ChangeAssignee;

//Команда для изменения исполнителя проекта
public class ChangeAssigneeCommand : IRequest
{
    public int TaskId { get; init; }
    
    public Guid newAssigneeId { get; init; }

    public sealed class ChangeAssigneeCommandHandler : IRequestHandler<ChangeAssigneeCommand>
    {
        private readonly ISystemDbContext _systemDbContext;

        public ChangeAssigneeCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }


        public async Task Handle(ChangeAssigneeCommand request, CancellationToken cancellationToken)
        {
            var task = await _systemDbContext.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            
            if (task is null)
            {
                throw new EntityNotFoundException("Задача не найдена");
            }
            
            var assignee = await _systemDbContext.Users.FindAsync(request.newAssigneeId);
            
            if (assignee is null)
            {
                throw new EntityNotFoundException("Исполнитель задачи не найден");
            }
            
            task.UpdateAssignee(assignee);

            await _systemDbContext.SaveChangesAsync(cancellationToken);
            
        }
    }
}