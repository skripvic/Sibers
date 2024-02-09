using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Commands.Projects.Validation;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Projects.UpdateProject;

//Команда для изменения данных проекта
public class UpdateProjectCommand: IRequest, IProjectUpdateCommand
{
    public int Id  { get; init; }

    public string Name  { get; init; }
    
    public string ClientCompany { get; init; }
    
    public string ContractorCompany { get; init; }
    
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }

    public Guid ManagerId { get; init; }

    public int Priority { get; init; }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly ISystemDbContext _systemDbContext;

        private readonly ProjectUpdateCommandValidator _validator;

        public UpdateProjectCommandHandler(ISystemDbContext systemDbContext, ProjectUpdateCommandValidator validator)
        {
            _systemDbContext = systemDbContext;
            _validator = validator;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateOrThrow(request);
            
            var project = await _systemDbContext.Projects
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            
            if (project is null)
            {
                throw new EntityNotFoundException("Проект не найден");
            }

            var user = await _systemDbContext.Users
            .FindAsync(request.ManagerId);
            
            if (user is null)
            {
                throw new EntityNotFoundException("Сотрудник не найден");
            }

            project.UpdateProject
            (request.Name, 
                request.ClientCompany,
                request.ContractorCompany,
                request.StartDate,
                request.EndDate,
                user,
                request.Priority);

            await _systemDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}