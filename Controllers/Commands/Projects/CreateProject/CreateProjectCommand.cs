using MediatR;
using testSibers.Controllers.Commands.Projects.Validation;
using testSibers.Controllers.Exceptions;
using testSibers.Models;
using testSibers.Models.Entities;

namespace testSibers.Controllers.Commands.Projects.CreateProject;

//Команда для создания проекта
public class CreateProjectCommand : IRequest<CreateProjectResponse>, IProjectUpdateCommand
{
    public string Name  { get; init; }
    
    public string ClientCompany { get; init; }
    
    public string ContractorCompany { get; init; }
    
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }

    public Guid ManagerId { get; init; }

    public int Priority { get; init; }
    
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
    {
        private readonly SystemDbContext _systemDbContext;

        private readonly ProjectUpdateCommandValidator _validator;

        public CreateProjectCommandHandler(SystemDbContext systemDbContext, ProjectUpdateCommandValidator validator)
        {
            _systemDbContext = systemDbContext;
            _validator = validator;
        }

        public async Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateOrThrow(request);
            
            var user = await _systemDbContext.Users.FindAsync(request.ManagerId);
            
            if (user is null)
            {
                throw new EntityNotFoundException("Сотрудник не найден");
            }

            var newProject = new Project
            (
                request.Name,
                request.ClientCompany,
                request.ContractorCompany,
                request.StartDate,
                request.EndDate,
                user,
                request.Priority
            );

            _systemDbContext.Projects.Add(newProject);
            await _systemDbContext.SaveChangesAsync(cancellationToken);

            return new CreateProjectResponse()
            {
                Id = newProject.Id
            };
        }
    }
}