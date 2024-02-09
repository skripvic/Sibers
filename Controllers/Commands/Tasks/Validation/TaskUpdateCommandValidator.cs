using testSibers.Controllers.Exceptions;
using testSibers.Models.EntityTypes;

namespace testSibers.Controllers.Commands.Tasks.Validation;

//Валидация данных для создания и изменения данных задачи
public class TaskUpdateCommandValidator
{
    public void ValidateOrThrow<TCommand>(TCommand command)
        where TCommand : ITaskUpdateCommand
    {
        var errors = new List<string>();

        // Проверяем название
        if (command.Name == null!
            || command.Name.Length < EntityConstants.Task.Name.Min
            || command.Name.Length > EntityConstants.Task.Name.Max)
        {
            errors.Add("Некорректное название");
        }

        // Проверяем комментарий
        if (command.Comment == null!
            || command.Comment.Length < EntityConstants.Task.Comment.Min
            || command.Comment.Length > EntityConstants.Task.Comment.Max)
        {
            errors.Add("Некорректный комментарий");
        }

        // Проверяем значение приоритета
        if (command.Priority < EntityConstants.Task.PriorityValues.Min
            || command.Priority > EntityConstants.Task.PriorityValues.Max)
        {
            errors.Add("Некорректное значение приоритета");
        }

        if (errors.Count != 0)
        {
            throw new BadRequestException(string.Join("; ", errors));
        }
    }
}