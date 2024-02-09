using testSibers.Models.Entities;

namespace testSibers.Controllers.Queries.Projects;

public static class ProjectExtension
{
    //Фильтрация по временному промежутку
    public static IQueryable<Project> FilterByDateTime(this IQueryable<Project> query, DateTime? startDate, DateTime? endDate)
    {
        if (startDate is not null)
        {
            query = query.Where(p => p.StartDate >= startDate);
        }

        if (endDate is not null)
        {
            query = query.Where(p => p.EndDate <= endDate);
        }
        
        return query;
    }

    //Фильтрация по приоритету
    public static IQueryable<Project> FilterByPriority(this IQueryable<Project> query, int? priority)
    {
        if (priority is not null)
        {
            query = query.Where(p => p.Priority == priority);
        }
        
        return query;
    }

    //Сортировка
    public static IQueryable<Project> SortByProperties(this IQueryable<Project> query)
    {
        return query.OrderBy(p => p.Priority)
            .ThenBy(p=> p.EndDate)
            .ThenBy(p=> p.StartDate)
            .ThenBy(p=>p.Id);
    }
    
}