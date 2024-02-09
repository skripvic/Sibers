using Microsoft.AspNetCore.Identity;

namespace testSibers.Models.Entities;

//Сущность отношения сотрудник-роль
public class UserRole : IdentityUserRole<Guid>
{
    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public UserRole()
    {
    }
}