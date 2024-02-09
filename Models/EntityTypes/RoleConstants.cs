namespace testSibers.Models.EntityTypes;

public static class RoleConstants
{
    public const string Supervisor = "Supervisor";
    public const string ProjectManager = "ProjectManager";
    public const string Employee = "Employee";
    
    public static RoleType MapToRoleType(this string? roleName)
    {
        return roleName switch
        {
            Supervisor => RoleType.Supervisor,
            ProjectManager => RoleType.ProjectManager,
            Employee => RoleType.Employee,
            _ => RoleType.Undefined
        };
    }
}