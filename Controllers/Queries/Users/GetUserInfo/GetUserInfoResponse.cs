using testSibers.Models.EntityTypes;

namespace testSibers.Controllers.Queries.Users.GetUserInfo;

public class GetUserInfoResponse
{
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string MiddleName { get; init; }
    
    public string Email { get; init; }
    public IList<RoleType> Roles { get; init; } = Array.Empty<RoleType>();

}