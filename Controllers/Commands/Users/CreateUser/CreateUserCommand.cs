using MediatR;
using testSibers.Controllers.Commands.Users.Validation;
using testSibers.Models;
using testSibers.Models.Entities;

namespace testSibers.Controllers.Commands.Users.CreateUser;

//Команда для создания сотрудника
public class CreateUserCommand: IRequest<CreateUserResponse>, IUserUpdateCommand
{
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string MiddleName { get; init; }
    
    public string Email { get; init; }
    
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly ISystemDbContext _systemDbContext;

        private readonly UserUpdateCommandValidator _validator;
        
        public CreateUserCommandHandler(ISystemDbContext systemDbContext, UserUpdateCommandValidator validator)
        {
            _systemDbContext = systemDbContext;
            _validator = validator;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           
            _validator.ValidateOrThrow(request);
            
            var newUser = new User
            (
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Email
            );

            _systemDbContext.Users.Add(newUser);
            await _systemDbContext.SaveChangesAsync(cancellationToken);

            return new CreateUserResponse()
            {
                Id = newUser.Id
            };
        }
    }
}