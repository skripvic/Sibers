using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Projects.DeleteUserFromProject;

//Команда для удаления сотрудника из проекта
public class DeleteUserFromProjectCommand: IRequest
{
    public DeleteUserFromProjectCommand(int projectId, Guid userId)
    {
        ProjectId = projectId;
        UserId = userId;
    }

    private int ProjectId  { get; init; }

    private Guid UserId { get; init; }
    
    public class DeleteUserFromProjectCommandHandler : IRequestHandler<DeleteUserFromProjectCommand>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        public DeleteUserFromProjectCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task Handle(DeleteUserFromProjectCommand request,
            CancellationToken cancellationToken)
        {
            
            var user = await _systemDbContext.Users.FindAsync(request.UserId);
            
            if (user is null)
            {
                throw new EntityNotFoundException("Сотрудник не найден");
            }
            
            var project = await _systemDbContext.Projects
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);

            if (project is null)
            {
                throw new EntityNotFoundException("Проект не найден");
            }

            if (project.Users.All(u => u.Id != user.Id))
            {
                throw new BadRequestException("Сотрудник не записан на данный проект");
            }

            project.Users.Remove(user);
            
            await _systemDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}