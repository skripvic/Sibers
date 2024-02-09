using testSibers.Controllers.Exceptions;
using testSibers.Models.EntityTypes;

namespace testSibers.Controllers.Commands.Projects.Validation;

//Валидация данных для создания или изменения данных проекта
public class ProjectUpdateCommandValidator
{
    public void ValidateOrThrow<TCommand>(TCommand command)
        where TCommand : IProjectUpdateCommand
    {
        var errors = new List<string>();

        // Проверяем название
        if (command.Name == null!
            || command.Name.Length < EntityConstants.Projects.Name.Min
            || command.Name.Length > EntityConstants.Projects.Name.Max)
        {
            errors.Add("Некорректное название");
        }

        // Проверяем комментарий
        if (command.ClientCompany == null!
            || command.ClientCompany.Length < EntityConstants.Projects.ClientCompany.Min
            || command.ClientCompany.Length > EntityConstants.Projects.ClientCompany.Max)
        {
            errors.Add("Некорректное название компании-заказчика");
        }
        
        // Проверяем комментарий
        if (command.ContractorCompany == null!
            || command.ContractorCompany.Length < EntityConstants.Projects.ContractorCompany.Min
            || command.ContractorCompany.Length > EntityConstants.Projects.ContractorCompany.Max)
        {
            errors.Add("Некорректный название компании-исполнителя");
        }

        // Проверяем значение приоритета
        if (command.Priority < EntityConstants.Projects.PriorityValues.Min
            || command.Priority > EntityConstants.Projects.PriorityValues.Max)
        {
            errors.Add("Некорректное значение приоритета");
        }
        
        Console.WriteLine(command.StartDate);
        // Проверяем дату начала
        if (command.StartDate <= EntityConstants.Projects.StartDateMin)
        {
            errors.Add("Некорректная дата начала");
        }
        
        // Проверяем дату начала
        if (command.EndDate <= EntityConstants.Projects.EndDateMin)
        {
            errors.Add("Некорректная дата конца");
        }

        if (command.StartDate > command.EndDate)
        {
            errors.Add("Дата начала не может быть позже даты конца");
        }

        if (errors.Count != 0)
        {
            throw new BadRequestException(string.Join("; ", errors));
        }
    }
}