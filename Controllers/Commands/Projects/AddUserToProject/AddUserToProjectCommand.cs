using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Projects.AddUserToProject;

//Команда для добавления сотрудника в проект
public class AddUserToProjectCommand: IRequest
{
    public int ProjectId  { get; init; }
    
    public Guid UserId { get; init; }
    
    public class AddUserToProjectCommandHandler : IRequestHandler<AddUserToProjectCommand>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        public AddUserToProjectCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task Handle(AddUserToProjectCommand request,
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
            
            if (project.Users.Any(u => u.Id == user.Id))
            {
                return;
            }

            project.Users.Add(user);
            
            await _systemDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}