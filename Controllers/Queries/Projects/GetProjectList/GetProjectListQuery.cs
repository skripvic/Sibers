using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Models;

namespace testSibers.Controllers.Queries.Projects.GetProjectList;

//Получение списка всех проектов
public class GetProjectListQuery: IRequest<ICollection<GetProjectListDto>>
{
    public DateTime? StartDate { get; init; }

    public DateTime? EndDate { get; init; }

    public int? Priority { get; init; }
    
    public sealed class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ICollection<GetProjectListDto>>
    {
        private readonly SystemDbContext _systemDbContext;

        public GetProjectListQueryHandler(SystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task<ICollection<GetProjectListDto>> Handle(GetProjectListQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _systemDbContext
                .Projects
                .FilterByPriority(request.Priority)
                .FilterByDateTime(request.StartDate, request.EndDate)
                .SortByProperties()
                .Select(p => new GetProjectListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ClientCompany = p.ClientCompany,
                    ContractorCompany = p.ContractorCompany,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Priority = p.Priority
                })
                .ToListAsync(cancellationToken);

            return users;
        }

    }
}