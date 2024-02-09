using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Tasks.AddAssignee;

//Команда для добавления исполнителя задания
public class AddAssigneeCommand : IRequest
{
    public int TaskId { get; init; }
    
    public Guid newAssigneeId { get; init; }
    
    public sealed class AddAssigneeCommandHandler : IRequestHandler<AddAssigneeCommand>
    {

        private readonly ISystemDbContext _systemDbContext;

        public AddAssigneeCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task Handle(AddAssigneeCommand request, CancellationToken cancellationToken)
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

            if (task.Assignee is not null)
            {
                throw new BadRequestException("Исполнитель уже назначен");
            }
            
            task.UpdateAssignee(assignee);

            await _systemDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}