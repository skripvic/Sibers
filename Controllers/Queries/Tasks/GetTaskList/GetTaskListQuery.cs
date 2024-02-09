using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Models;


namespace testSibers.Controllers.Queries.Tasks.GetTaskList;

//Получение списка всех задач
public class GetTaskListQuery : IRequest<ICollection<GetTaskListDto>>
{
    public int? Priority { get; init; }

    public StatusType? StatusType { get; init; } 
    
    public sealed class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, ICollection<GetTaskListDto>>
    {
        private readonly ISystemDbContext _systemDbContext;

        public GetTaskListQueryHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task<ICollection<GetTaskListDto>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _systemDbContext
                .Tasks
                .FilterByPriority(request.Priority)
                .FilterByStatus(request.StatusType)
                .SortByProperties()
                .Select(t => new GetTaskListDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Status = (StatusType)t.Status,
                    Priority = t.Priority
                })
                .ToListAsync(cancellationToken);

            return tasks;

        }
    }
}