using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Queries.Tasks.GetTaskInfo;

//Получение информации о задаче по ID
public class GetTaskInfoQuery: IRequest<GetTaskInfoResponse>
{
    public GetTaskInfoQuery(int taskId)
    {
        TaskId = taskId;
    }

    private int TaskId { get; init; }

    public sealed class GetTaskInfoQueryHandler : IRequestHandler<GetTaskInfoQuery, GetTaskInfoResponse>
    {
        private readonly ISystemDbContext _systemDbContext;

        public GetTaskInfoQueryHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task<GetTaskInfoResponse> Handle(GetTaskInfoQuery request, CancellationToken cancellationToken)
        {
            var task = await _systemDbContext
                .Tasks
                .Include(t => t.Assignee)
                .Include(t => t.Creator)
                .Include(t => t.TaskProject)
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            
            if (task is null)
            {
                throw new EntityNotFoundException("Задача не найдена");
            }

            return new GetTaskInfoResponse
            {
                Id = task.Id,
                Name = task.Name,
                CreatorLastName = task.Creator.LastName,
                CreatorFirstName = task.Creator.FirstName,
                AssigneeLastName = task.Assignee?.LastName,
                AssigneeFirstName = task.Assignee?.FirstName,
                Status = (StatusType)task.Status,
                Comment = task.Comment,
                Priority = task.Priority,
                TaskProjectName = task.TaskProject.Name
            };
        }
    }

}