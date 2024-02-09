namespace testSibers.Controllers.Commands.Users.Validation;

public interface IUserUpdateCommand
{
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string MiddleName { get; init; }
    
    public string Email { get; init; }
}