using Microsoft.AspNetCore.Identity;
using testSibers.Models.EntityTypes;

namespace testSibers.Models.Entities;

//Cущность роли
public class Role : IdentityRole<Guid>
{
    //Тип роли
    public RoleType Type => Name.MapToRoleType();

}