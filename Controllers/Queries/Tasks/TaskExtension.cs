using Task = testSibers.Models.Entities.Task;

namespace testSibers.Controllers.Queries.Tasks;

public static class TaskExtension
{
    //Фильтрация по приоритету
    public static IQueryable<Task> FilterByPriority(this IQueryable<Task> query, int? priority)
    {
        if (priority is not null)
        {
            query = query.Where(p => p.Priority == priority);
        }
        
        return query;
    }
    //Фильтрация по статусу
    public static IQueryable<Task> FilterByStatus(this IQueryable<Task> query, StatusType? status)
    {
        if (status is not null)
        {
            query = query.Where(p => p.Status == (Models.EntityTypes.StatusType)status);
        }
        
        return query;
    }
    //Сортировка
    public static IQueryable<Task> SortByProperties(this IQueryable<Task> query)
    {
        return query.OrderBy(p => p.Priority)
            .ThenBy(p=> p.Status)
            .ThenBy(p=>p.Id);
    }
    
}