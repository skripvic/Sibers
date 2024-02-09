using MediatR;
using testSibers.Controllers.Commands.Users.Validation;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Commands.Users.UpdateUser;

//Команда для изменения данных сотрудника
public class UpdateUserCommand : IRequest, IUserUpdateCommand
{
    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string MiddleName { get; init; }

    public string Email { get; init; }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ISystemDbContext _systemDbContext;
        
        private readonly UserUpdateCommandValidator _validator;

        public UpdateUserCommandHandler(ISystemDbContext systemDbContext, UserUpdateCommandValidator validator)
        {
            _systemDbContext = systemDbContext;
            _validator = validator;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateOrThrow(request);
            
            var user = await _systemDbContext.Users.FindAsync(request.Id);

            if (user is null)
            {
                throw new EntityNotFoundException("Сотрудник не найден");
            }
            
            user.UpdateUser(
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Email);

            await _systemDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}