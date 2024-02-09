using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Queries.Projects.GetProjectUsersList;
using testSibers.Models;

namespace testSibers.Controllers.Queries.Projects.GetProjectUsers;

//Получение списка сотрудников проекта
public class GetProjectUsersQuery : IRequest<ICollection<GetProjectUsersDto>>
{
    public GetProjectUsersQuery(int projectId)
    {
        ProjectId = projectId;
    }

    private int ProjectId { get; init; }

    public sealed class GetProjectUsersQueryHandler : IRequestHandler<GetProjectUsersQuery, ICollection<GetProjectUsersDto>>
    {
        private readonly ISystemDbContext _systemDbContext;

        public GetProjectUsersQueryHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }


        public async Task<ICollection<GetProjectUsersDto>> Handle(GetProjectUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _systemDbContext
                .Projects
                .Include(p => p.Users)
                .Where(p => p.Id == request.ProjectId)
                .SelectMany(p => p.Users)
                .Select(u => new GetProjectUsersDto()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                })
                .ToListAsync(cancellationToken);
            
            return users;
        }
    }
}