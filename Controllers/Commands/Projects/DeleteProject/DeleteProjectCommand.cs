using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Projects.DeleteProject;

//Команда для удаления проекта
public class DeleteProjectCommand: IRequest
{
    public DeleteProjectCommand(int projectId)
    {
        ProjectId = projectId;
    }

    private int ProjectId { get; init; }
    
    public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        public DeleteProjectCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {

            var project = await _systemDbContext.Projects
                .FirstOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);

            if (project is null)
            {
                throw new EntityNotFoundException("Проект не найден");
            }
            
            _systemDbContext.Projects.Remove(project);

            await _systemDbContext.SaveChangesAsync(cancellationToken);

        }
    }
}