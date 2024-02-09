using Microsoft.AspNetCore.Identity;

namespace testSibers.Models.Entities;

//Сущность сотрудника/пользователя
public class User : IdentityUser<Guid>
{
    //Имя
    public string FirstName { get; private set; }
    
    //Фамилия
    public string LastName { get; private set; }
    
    //Отчество
    public string MiddleName { get; private set; }
    
    //Почтовый адрес
    public string Email { get; private set; }
    
    //Список проектов сотрудника
    public IList<Project> Projects { get; private set; } = new List<Project>();
    
    //Список ролей
    public IList<Role> Roles { get; private set; } = new List<Role>();
    
    //Список refresh токенов
    public IList<RefreshToken> RefreshTokens { get; private set; } = new List<RefreshToken>();

    public User(string firstName, string lastName, string middleName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
    }
    
    public void UpdateUser(string firstName, string lastName, string middleName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
    }
    
}
