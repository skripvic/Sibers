using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testSibers.Models.Entities;
using testSibers.Models.EntityTypes;

namespace testSibers.Models;

//Класс для начального заполнения базы данных
public static class DataSeeder
{
     public static void SeedInitialData(this ModelBuilder builder)
    {
        var supervisorRoleId = new Guid("DB1FB1BE-3342-4233-8EA1-BA887CEE50FE");
        var projectManagerRoleId = new Guid("4E59E1FA-92E7-434C-B344-20C574486690");
        var employeeRoleId = new Guid("A96ABF16-CBAF-48CF-A245-068829F7D858");
        var supervisorId = new Guid("9F51B901-3F29-40F8-9AB7-037EDC99DB74");
        var projectManagerId = new Guid("56AD9457-B3E5-4F1A-9DF3-387B17C008F8");
        var employeeId = new Guid("7B336654-32C4-44EF-88A1-16E3CB1C2A6E");

        var passwordHasher = new PasswordHasher<User>();
        
        builder.Entity<Role>().HasData(new Role {Id = supervisorRoleId, Name = RoleConstants.Supervisor, NormalizedName = "SUPERVISOR"});
        builder.Entity<Role>().HasData(new Role {Id = projectManagerRoleId, Name = RoleConstants.ProjectManager, NormalizedName = "PROJECT MANAGER"});
        builder.Entity<Role>().HasData(new Role {Id = employeeRoleId, Name = RoleConstants.Employee, NormalizedName = "EMPLOYEE"});

        var supervisor = new User(
            "supervisorName", "lastName", "middleName", "supervisor@test.test")
        {
            UserName = "supervisor@test.test",
            NormalizedUserName = "SUPERVISOR@TEST.TEST",
            Id = supervisorId
        };
        supervisor.PasswordHash = passwordHasher.HashPassword(supervisor, "SupervisorPassword");
        supervisor.SecurityStamp = Guid.NewGuid().ToString();
        
        var projectManager = new User(
            "projectManagerName", "lastName", "middleName", "projectManager@test.test")
        {
            UserName = "projectManager@test.test",
            NormalizedUserName = "PROJECTMANAGER@TEST.TEST",
            Id = projectManagerId
        };
        projectManager.PasswordHash = passwordHasher.HashPassword(projectManager, "ProjectManagerPassword");
        projectManager.SecurityStamp = Guid.NewGuid().ToString();

        var employee = new User(
            "employeeName", "lastName", "middleName", "employee@test.test")
        {
            UserName = "employee@test.test",
            NormalizedUserName = "EMPLOYEE@TEST.TEST",
            Id = employeeId
        };
        employee.PasswordHash = passwordHasher.HashPassword(employee, "EmployeePassword");
        employee.SecurityStamp = Guid.NewGuid().ToString();
        
        builder.Entity<User>().HasData(supervisor);
        builder.Entity<User>().HasData(projectManager);
        builder.Entity<User>().HasData(employee);

        builder.Entity<UserRole>().HasData(new UserRole(supervisorId, supervisorRoleId));
        builder.Entity<UserRole>().HasData(new UserRole(projectManagerId, projectManagerRoleId));
        builder.Entity<UserRole>().HasData(new UserRole(employeeId, employeeRoleId));
        builder.Entity<UserRole>().HasData(new UserRole(supervisorId, employeeRoleId));
        builder.Entity<UserRole>().HasData(new UserRole(projectManagerId, employeeRoleId));
    }
}