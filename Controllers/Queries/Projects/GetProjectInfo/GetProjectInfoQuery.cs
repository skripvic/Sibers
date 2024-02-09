using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Queries.Projects.GetProjectInfo;

//Получение информации о проекте по ID
public class GetProjectInfoQuery : IRequest<GetProjectInfoResponse>
{
    public GetProjectInfoQuery(int projectId)
    {
        ProjectId = projectId;
    }

    private int ProjectId { get; init; }
    
    public sealed class GetProjectInfoQueryHandler : IRequestHandler<GetProjectInfoQuery, GetProjectInfoResponse>
    {
        private readonly ISystemDbContext _systemDbContext;

        public GetProjectInfoQueryHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }
        
        public async Task<GetProjectInfoResponse> Handle(GetProjectInfoQuery request, CancellationToken cancellationToken)
        {
            var projects = await _systemDbContext.Projects
                .Include(p => p.Manager)
                .FirstOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);

            if (projects is null)
            {
                throw new EntityNotFoundException("Проект не найден");
            }

            return new GetProjectInfoResponse
            {
                Id = projects.Id,
                Name = projects.Name,
                ClientCompany = projects.ClientCompany,
                ContractorCompany = projects.ContractorCompany,
                StartDate = projects.StartDate,
                EndDate = projects.EndDate,
                ManagerFirstName = projects.Manager.FirstName,
                ManagerLastName = projects.Manager.LastName,
                Priority = projects.Priority
            };

        }
    }
}