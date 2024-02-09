using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Users.DeleteUser;

//Команда для удаления сотрудника
public class DeleteUserCommand: IRequest
{
    public DeleteUserCommand(Guid userId)
    {
        UserId = userId;
    }

    private Guid UserId { get; init; }
    
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        public DeleteUserCommandHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _systemDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user is null)
            {
                throw new EntityNotFoundException("Сотрудник не найден");
            }
            
            _systemDbContext.Users.Remove(user);

            await _systemDbContext.SaveChangesAsync(cancellationToken);

        }
    }
}