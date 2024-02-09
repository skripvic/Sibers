using testSibers.Controllers.Exceptions;
using testSibers.Models.EntityTypes;

namespace testSibers.Controllers.Commands.Users.Validation;

//Валидация данных для создания и изменения данных сотрудника
public class UserUpdateCommandValidator
{
    public void ValidateOrThrow<TCommand>(TCommand command)
        where TCommand : IUserUpdateCommand
    {
        var errors = new List<string>();

        // Проверяем имя
        if (command.FirstName == null!
            || command.FirstName.Length < EntityConstants.User.FirstName.Min
            || command.FirstName.Length > EntityConstants.User.FirstName.Max)
        {
            errors.Add("Некорректное имя");
        }

        // Проверяем фамилию
        if (command.LastName == null!
            || command.LastName.Length < EntityConstants.User.LastName.Min
            || command.LastName.Length > EntityConstants.User.LastName.Max)
        {
            errors.Add("Некорректная фамилия");
        }
        
        // Проверяем отчество
        if (command.MiddleName == null!
            || command.MiddleName.Length < EntityConstants.User.MiddleName.Min
            || command.MiddleName.Length > EntityConstants.User.MiddleName.Max)
        {
            errors.Add("Некорректное отчество");
        }
        
        // Проверяем почтовый адрес
        if (command.Email == null!
            || command.Email.Length < EntityConstants.User.Email.Min
            || command.Email.Length > EntityConstants.User.Email.Max)
        {
            errors.Add("Некорректный почтовый адрес");
        }
        
        if (errors.Count != 0)
        {
            throw new BadRequestException(string.Join("; ", errors));
        }
        
    }
    
}